using Npgsql;
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
        private void LoadFiltredData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Order(), dataGridView1);
            dbQuery.LoadFiltredData(comboBox2, textBox1, textBox2, textBox3);
        }
        private void DeleteOrder()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Order(), dataGridView1);
            dbQuery.DeleteItem();
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
        private void AddOrder()
        {
            // Строка подключения к вашей базе данных


            // SQL-запрос для выборки данных
            string fianl_cost = textBox4.Text;
            string items_quantity = textBox5.Text;
            string final_place = textBox6.Text;
            string user_id = "03dd7f26-0c2c-441e-a1f6-a0db6320db64";




            // Создаем соединение с базой данных
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();

                try
                {

                    // Открываем соединение
                    using (var cmd = new NpgsqlCommand(String.Format(
                        "INSERT INTO orders(user_id, final_cost, count, final_place) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}')",
                        user_id, fianl_cost, items_quantity, final_place), conn))
                    {
                        //cmd.Parameters.AddWithValue("is_superuser", "false");
                        //cmd.Parameters.AddWithValue("is_staff", "false");
                        //cmd.Parameters.AddWithValue("cost", price);
                        //cmd.Parameters.AddWithValue("count", Quantity);
                        //cmd.Parameters.AddWithValue("rate", rate);
                        //cmd.Parameters.AddWithValue("сategory", "Ноутбуки");

                        cmd.ExecuteNonQuery();
                    }

                    // Создаем DataTable для хранения данных

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            LoadData();
        }
        private object? SelectedRow(string text)
        {
            return dataGridView1.SelectedRows[0].Cells[text].Value;
        }
        private void ViewDetails()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                Order order = new Order(Guid.Parse(SelectedRow("order_id").ToString()), 
                    SelectedRow("user_id").ToString(), (float)Convert.ToDouble(SelectedRow("final_cost")), Convert.ToInt32(SelectedRow("count")),
                SelectedRow("final_place").ToString());
                Details form = new Details(order, this);

                form.Owner = this;
                form.Show();
            }

        }
    }
}
