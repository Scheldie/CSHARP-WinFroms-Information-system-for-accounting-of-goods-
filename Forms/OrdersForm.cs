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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Forms
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;

        }

        private void OrdersForm_Load(object sender, EventArgs e)
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
            string query = "SELECT * FROM orders";

            // Создаем соединение с базой данных
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();
                var command = new NpgsqlCommand(query, conn);

                try
                {
                    // Открываем соединение
                    using (var cmd = new NpgsqlCommand("SELECT * FROM orders", conn))
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
    }
}
