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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Forms
{
    public partial class UsersForm : Form, ISaveChanges
    {
        public UsersForm()
        {
            InitializeComponent();
            this.SizeChanged += Form_SizeChanged;

        }

        private void UsersForm_Load(object sender, EventArgs e)
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
                
            }
        }
        private void LoadData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new User(), dataGridView1);
            dbQuery.LoadData();
        }
        private void LoadFiltredData()
        {
            DataBaseQueries dbQuery = new DataBaseQueries(this, this, new User(), dataGridView1);
            dbQuery.LoadFiltredData(new System.Windows.Forms.ComboBox() { Text= ""}, 
                textBox1, new System.Windows.Forms.TextBox() { Text = "" }, 
                new System.Windows.Forms.TextBox() { Text = "" });
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
            if (dataGridView1.SelectedRows.Count > 0)
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
