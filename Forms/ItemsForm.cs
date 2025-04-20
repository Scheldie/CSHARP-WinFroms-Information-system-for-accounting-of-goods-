using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.ApplicationServices;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1.Forms
{
    public partial class ItemsForm : Form, ISaveChanges 
    {
        public ItemsForm()
        {
            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;

        }

        private void Items_Load(object sender, EventArgs e)
        {
            LoadData();
            List<string> items = new List<string>
            {
                ""
            };
            Item item = new Item(Guid.NewGuid(), "zero", 0.0f, 0, 0.0f, "undefined");
            foreach (var prop in item.GetType().GetProperties())
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
            if (dataGridView1.SelectedRows.Count > 0)
            {

                string query = String.Format
                    ("SELECT dealer_name FROM dealer WHERE dealer_id = '{0}'",
                    SelectedRow("dealer_id"));
                string dealer_name = "";
                using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
                {
                    conn.Open();
                    var command = new NpgsqlCommand(query, conn);

                    try
                    {
                        using (var cmd = new NpgsqlCommand(String.Format
                            ("SELECT dealer_name FROM dealer WHERE dealer_id = '{0}'",
                            SelectedRow("dealer_id")), conn))
                        {
                            cmd.Parameters.AddWithValue("dealer_id", SelectedRow("dealer_id"));
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Обрабатываем результаты запроса
                                    dealer_name = reader["dealer_name"].ToString();
                                }
                            }
                        }

                        // Создаем DataTable для хранения данных

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
                //item_name, dealer_id, cost, count, rate, category
                Item item = new Item(Guid.Parse(SelectedRow("item_id").ToString()),
                    SelectedRow("item_name").ToString(),
                    (float)Convert.ToInt32(SelectedRow("cost")), Convert.ToInt32(SelectedRow("count")),
                (float)Convert.ToInt32(SelectedRow("rate")), dealer_name);
                Details form = new Details(item, this);
                
                form.Owner = this;
                form.Show();
            }

        }

        private void LoadData()
        {
            DataBaseQueries bdQuery = new DataBaseQueries(this, this, new Item(), this.dataGridView1);
            bdQuery.LoadData();
        }
        private void DeleteItem()
        {
            DataBaseQueries bdQuery = new DataBaseQueries(this, this, new Item(), this.dataGridView1);
            bdQuery.DeleteItem();
        }
        private void LoadFiltredData()
        {
            DataBaseQueries bdQuery = new DataBaseQueries(this, this, new Item(), this.dataGridView1);
            bdQuery.LoadFiltredData(this.comboBox2, textBox1, textBox2, textBox3);
        }
        private void AddItem()
        {
            // Строка подключения к вашей базе данных


            // SQL-запрос для выборки данных
            string Name = textBox4.Text;
            string price = textBox5.Text;
            string Quantity = textBox6.Text;
            float rate = 0.00f;
            string dealer = "208bafa0-27ab-4b55-9892-df0ab71f55a5";
            
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();

                try
                {
                    
                    using (var cmd = new NpgsqlCommand(String.Format(
                        "INSERT INTO item(item_name, dealer_id, cost, count, rate, category) " +
                        "VALUES ('{0}' , '{1}', '{2}', '{3}', '{4}', 'Ноутбуки')",
                        Name, dealer, price, Quantity, rate), conn))
                    {
                        cmd.Parameters.AddWithValue("item_name", Name);
                        cmd.Parameters.AddWithValue("dealer_id", dealer);
                        cmd.Parameters.AddWithValue("cost", price);
                        cmd.Parameters.AddWithValue("count", Quantity);
                        cmd.Parameters.AddWithValue("rate", rate);
                        cmd.Parameters.AddWithValue("сategory", "Ноутбуки");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
