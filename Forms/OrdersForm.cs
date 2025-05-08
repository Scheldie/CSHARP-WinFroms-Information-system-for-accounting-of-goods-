using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.docker;
using WinFormsApp1.Entities;
using WinFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Forms
{
    public partial class OrdersForm : Form, ISaveChanges
    {
        public OrdersForm()
        {

            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;
            this.FormClosing += OrdersForm_FormClosing;
        }

        private void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Проходим по всем открытым дочерним формам
            foreach (Form openForm in Application.OpenForms)
            {
                // Опционально: исключаете главную форму из закрытия
                if (openForm != this)
                {
                    openForm.Close();
                }
            }
        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadData();
            List<string> items = new List<string>
            {
                ""
            };
            Order order = new Order();
            foreach (var prop in order.GetType().GetProperties())
            {
                if (prop.GetCustomAttributes().Any(x => x.GetType().Name == "FilterableAttribute"))
                {
                    items.Add(prop.GetCustomAttribute<AliasAttribute>().Alias);
                }
            }
            comboBox2.DataSource = items;
            if (DataBaseQueries.IsOperator)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

            }

        }
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            // Проверяем, если высота формы увеличилась
            if (this.ClientSize.Height > 706) // Замените 400 на исходную высоту формы
            {
                // Сместите GroupBox вниз, например, на 10 пикселей
                groupBox1.Location = new System.Drawing.Point(groupBox1.Location.X, Convert.ToInt32(this.ClientSize.Height * 0.8));
                groupBox2.Location = new System.Drawing.Point(groupBox2.Location.X, Convert.ToInt32(this.ClientSize.Height * 0.8));
            }
        }
        private void LoadData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Order(), dataGridView1);
            dbQuery.LoadData();
        }
        private string FilterSubsQuery(string bottom, string top, string filter)
        {

            string subquery1 = "";
            if (filter != "" &&
                (bottom != "" || top != ""))
            {
                if (filter != "")
                {
                    if (Double.TryParse(bottom, out double bottom1)
                        && Double.TryParse(top, out double top1) && bottom1 - top1 < -1e-6)
                        subquery1 = String.Format(" AND {0} >= ", filter)
                            + bottom1 + String.Format(" AND {0} <= ", filter) + top1;
                    else if (Double.TryParse(bottom, out bottom1)
                        && Double.TryParse(top, out top1) && Math.Abs(bottom1 - top1) < 1e-6)
                        subquery1 = String.Format(" AND {0} = ", filter)
                            + bottom1;
                    else if (Double.TryParse(bottom, out bottom1) &&
                        !Double.TryParse(top, out top1))
                        subquery1 = String.Format(" AND {0} >= ", filter) + bottom1;
                    else if (Double.TryParse(top, out top1) &&
                        !Double.TryParse(bottom, out bottom1))
                        subquery1 = String.Format(" AND {0} <= ", filter) + top1;
                }

            }
            return subquery1;
        }
        private void LoadFilteredData()
        {
            Guid name = Guid.NewGuid();
            Guid.TryParse(textBox1.Text, out name);
            string query;
            string subquery1 = FilterSubsQuery(textBox2.Text, textBox3.Text, comboBox2.Text);
            if (textBox1.Text != "") query = String.Format("SELECT * FROM orders WHERE order_id = @filter",
                textBox1.Text) + subquery1;
            else if (textBox1.Text == "" && subquery1.Length > 4)
                query = String.Format("SELECT * FROM orders WHERE ") + subquery1.Substring(4);
            else
                query = String.Format("SELECT * FROM orders");
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                var command = new NpgsqlCommand(query, conn);
                command.Parameters.AddWithValue("@filter", name);
                try
                {

                    using (var reader = command.ExecuteReader())
                    {

                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        DataColumn indexColumn = new DataColumn("Index", typeof(int));
                        dataTable.Columns.Add(indexColumn);

                        int index = 1;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["Index"] = index++;
                        }
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["Index"].DisplayIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при выборке записей с фильтрацией. Ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteOrder()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Order(), dataGridView1);
            dbQuery.DeleteItem();
        }
        private void CancelOrder(string orderId)
        {

            using var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand("CALL cancel_order(@order_id)", conn);
            cmd.Parameters.AddWithValue("@order_id", Guid.Parse(orderId));

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Заказ успешно отменён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка отмены заказа:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        public void SaveChanges(IEntity entity)
        {
            save_changes(entity);
        }
        private void save_changes(IEntity entity)
        {
            DataBaseQueries bdQuery = new DataBaseQueries(this, this, entity, this.dataGridView1);
            bdQuery.SaveChange();

        }
        public void CreateOrder(string userId, int finalPlace, List<(Guid itemId, int quantity)> items)
        {
            var salt = "$yj*94g=)";
            var user_id = "";
            using var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString);
            conn.Open();
            using (var command = new NpgsqlCommand("SELECT user_id FROM users WHERE phone_number = @phone_number", conn))
            {
                command.Parameters.AddWithValue("@phone_number", LoginForm.ComputeSha256Hash(userId + salt));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Обрабатываем результаты запроса
                        user_id = reader["user_id"].ToString();
                    }
                }
            }

            using var cmd = new NpgsqlCommand("CALL create_order(@user_id, @final_place, @item_info)", conn);

            cmd.Parameters.AddWithValue("@user_id", Guid.Parse(user_id));
            cmd.Parameters.AddWithValue("@final_place", NpgsqlTypes.NpgsqlDbType.Integer, finalPlace);

            // Сформировать массив строк типа item_id:количество
            var itemInfoArray = items.Select(i => $"{i.itemId}:{i.quantity}").ToArray();
            cmd.Parameters.AddWithValue("@item_info", NpgsqlTypes.NpgsqlDbType.Array | 
                NpgsqlTypes.NpgsqlDbType.Text, itemInfoArray);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Заказ успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка создания заказа:\n{ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        
        private object? SelectedRow(string text)
        {
            return dataGridView1.SelectedRows[0].Cells[text].Value;
        }
        private void ViewDetails()
        {
            if (dataGridView1.SelectedRows.Count > 0 && SelectedRow("order_id") != null)
            {

                Order order = new Order(Guid.Parse(SelectedRow("order_id").ToString()),
                    SelectedRow("user_id").ToString(), (float)Convert.ToDouble(SelectedRow("final_cost")), Convert.ToInt32(SelectedRow("count")),
                SelectedRow("final_place").ToString());
                Details form = new Details(order, this);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(this.Location.X + this.Width / 4, this.Location.Y + this.Height / 4);
                form.Owner = this;
                form.Show();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
