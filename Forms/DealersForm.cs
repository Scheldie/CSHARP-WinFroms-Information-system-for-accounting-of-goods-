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
            List<string> items = new List<string>
            {
                ""
            };
            Dealer dealer = new Dealer();
            foreach (var prop in dealer.GetType().GetProperties())
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
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Dealer(), dataGridView1);
            dbQuery.LoadData();
        }
        private void LoadFiltredData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Dealer(), dataGridView1);
            dbQuery.LoadFiltredData(comboBox2, textBox1, textBox2, textBox3);
        }
        private void DeleteDealer()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new Dealer(), dataGridView1);
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
