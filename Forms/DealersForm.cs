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
using WinFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Forms
{
    public partial class DealersForm : Form, ISaveChanges
    {
        public DealersForm()
        {
            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;

        }

        private void Dealers_Load(object sender, EventArgs e)
        {
            LoadData();

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
            // Строка подключения к вашей базе данных


            // SQL-запрос для выборки данных
            string query = "SELECT * FROM dealer";

            // Создаем соединение с базой данных
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();
                var command = new NpgsqlCommand(query, conn);

                try
                {
                    // Открываем соединение
                    using (var cmd = new NpgsqlCommand("SELECT * FROM dealer", conn))
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Добавляем новую колонку для номера записи
                        DataColumn indexColumn = new DataColumn("Index", typeof(int));
                        dataTable.Columns.Add(indexColumn);

                        // Заполняем колонку индексами
                        int index = 1;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["Index"] = index++;
                        }

                        // Привязываем данные к DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Перемещаем колонку индекса на самое левое место
                        dataGridView1.Columns["Index"].DisplayIndex = 0;
                    }

                    // Создаем DataTable для хранения данных

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void AddDealer()
        {
            // Строка подключения к вашей базе данных


            // SQL-запрос для выборки данных
            string Name = textBox4.Text;
            string url = textBox5.Text;
            float rate = 0.00f;

            // Создаем соединение с базой данных
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();

                try
                {
                    // Открываем соединение
                    using (var cmd = new NpgsqlCommand(String.Format(
                        "INSERT INTO dealer (rate, dealer_name, url) VALUES ('{0}' ,'{1}', '{2}')", 
                        rate, Name, url), conn))
                    {
                        cmd.Parameters.AddWithValue("rate", rate);
                        cmd.Parameters.AddWithValue("dealer_name", Name);
                        cmd.Parameters.AddWithValue("url", url);
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

                Dealer user = new Dealer(Guid.Parse(SelectedRow("dealer_id").ToString()),
                    SelectedRow("dealer_name").ToString(), SelectedRow("url").ToString(),
                    (float)Convert.ToDouble(SelectedRow("rate")));
                Details form = new Details(user, this);

                form.Owner = this;
                form.Show();
            }

        }
    }
}
