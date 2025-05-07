using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.docker;
using WinFormsApp1.Entities;
using WinFormsApp1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1.Forms
{
    public partial class UsersForm : Form, ISaveChanges
    {
        public UsersForm()
        {
            
            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;

            this.FormClosing += UsersForm_FormClosing;

        }
        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Проходим по всем открытым дочерним формам
            foreach (Form openForm in System.Windows.Forms.Application.OpenForms)
            {
                // Опционально: исключаете главную форму из закрытия
                if (openForm != this)
                {
                    openForm.Close();
                }
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (DataBaseQueries.IsOperator)
            {
                groupBox1.Visible = false;

            }

        }
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            // Проверяем, если высота формы увеличилась
            if (this.ClientSize.Height > 706) // Замените 400 на исходную высоту формы
            {
                // Сместите GroupBox вниз, например, на 10 пикселей
                groupBox1.Location = new System.Drawing.Point(groupBox1.Location.X, Convert.ToInt32(this.ClientSize.Height * 0.8));
                
            }
        }
        private void LoadData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new User(), dataGridView1);
            dbQuery.LoadData();
        }
        private void LoadFiltredData()
        {
            if (textBox1.Text == "") { LoadData(); return; }
            var salt = "$yj*94g=)";
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("SELECT * FROM users WHERE phone_number = @phone_number", conn))
                    {
                        cmd.Parameters.AddWithValue("@phone_number", LoginForm.ComputeSha256Hash(textBox1.Text+salt));
                        using (var reader = cmd.ExecuteReader())
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при выборке записей с фильтрацией. Ошибка: " + ex.Message);
                }
            }
        }
        private void DeleteUser()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new User(), dataGridView1);
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
        
        private object? SelectedRow(string text)
        {
            return dataGridView1.SelectedRows[0].Cells[text].Value;
        }
        private void ViewDetails()
        {
            if (dataGridView1.SelectedRows.Count > 0 && SelectedRow("user_id") != null)
            {

                User user = new User(Guid.Parse(SelectedRow("user_id").ToString()),
                    SelectedRow("first_name").ToString(), SelectedRow("last_name").ToString(),
                    Convert.ToBoolean(SelectedRow("is_superuser")), Convert.ToBoolean(SelectedRow("is_staff")),
                    Convert.ToBoolean(SelectedRow("is_active")), Convert.ToDateTime(SelectedRow("last_signed_at")),
                    Convert.ToDateTime(SelectedRow("registered_at")), SelectedRow("phone_number").ToString()
                    );
                Details form = new Details(user, this);

                form.Owner = this;
                form.Show();
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
