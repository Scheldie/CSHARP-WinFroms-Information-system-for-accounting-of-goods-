﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1.Forms
{
    public partial class ItemsForm : Form, ISaveChanges
    {
        public ItemsForm()
        {

            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;
            this.FormClosing += ItemsForm_FormClosing;
        }

        private void ItemsForm_FormClosing(object sender, FormClosingEventArgs e)
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
            if (dataGridView1.SelectedRows.Count > 0 && SelectedRow("item_id") != null)
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
            float price = float.Parse(textBox5.Text);
            int Quantity = int.Parse(textBox6.Text);
            float rate = 0.00f;
            Guid dealer = new Guid();

            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                conn.Open();

                try
                {
                    using (var cmd = new NpgsqlCommand("SELECT dealer_id FROM dealer WHERE dealer_name = @dealer_name", conn))
                    {
                        cmd.Parameters.AddWithValue("@dealer_name", textBox7.Text);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Обрабатываем результаты запроса
                                dealer = Guid.Parse(reader["dealer_id"].ToString());
                            }
                        }
                    }
                    if (dealer != new Guid())
                    {
                        using (var cmd = new NpgsqlCommand(String.Format(
                            "INSERT INTO item(item_name, dealer_id, cost, count, rate, category) " +
                            "VALUES (@item_name , @dealer_id, @cost, @count, @rate, 'Ноутбуки')"
                            ), conn))
                        {
                            cmd.Parameters.AddWithValue("@item_name", Name);
                            cmd.Parameters.AddWithValue("@dealer_id", dealer);
                            cmd.Parameters.AddWithValue("@cost", price);
                            cmd.Parameters.AddWithValue("@count", Quantity);
                            cmd.Parameters.AddWithValue("@rate", rate);


                            cmd.ExecuteNonQuery();
                        }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string query = @"SELECT *
                FROM item
                WHERE item_id NOT IN (
                    SELECT DISTINCT item_id
                    FROM ordered_item oi
                    JOIN orders AS o ON o.order_id = oi.order_id
                    WHERE o.date >= CURRENT_DATE - INTERVAL '3 months'
                );";

                using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
                {
                    conn.Open();
                    var command = new NpgsqlCommand(query, conn);
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
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
            else LoadData();
        }
    }
}
