using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsApp1.Entities;
using WinFormsApp1.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.docker
{
    internal class DataBaseQueries
    {
        private Form _form;
        private ISaveChanges _form_save;
        private IEntity entity;
        private DataGridView dataGridView;

        public DataBaseQueries(Form _form, ISaveChanges _form_save,
                                IEntity entity, DataGridView dataGridView)
        {
            this._form = _form;
            this._form_save = _form_save;
            this.entity = entity;
            this.dataGridView = dataGridView;
        }

        public void SaveChange() { SaveChanges(entity); }
        public void LoadData() { LoadData(dataGridView); }

        public void DeleteItem() { DeleteItem(dataGridView); }
        public void LoadFiltredData(System.Windows.Forms.ComboBox comboBox2,
            System.Windows.Forms.TextBox textBox1, System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3)
        {
            LoadFiltredData(dataGridView, comboBox2, textBox1, textBox2, textBox3);
        }
        private string TableName => (entity?.GetType()?.GetCustomAttributes()
                    ?.Where(x => x?.GetType()?.Name == "AliasAttribute")
                    ?.FirstOrDefault() as AliasAttribute)?.Alias;
        private string TableId => entity.GetType()
                     .GetProperties().Where(x => x.Name == "id")?.FirstOrDefault()?
                .GetCustomAttribute<AliasAttribute>()?.Alias;
        private string TableObjectName => entity.GetType()
                     .GetProperties().Where(x => x.Name == "name")?.FirstOrDefault()?
                .GetCustomAttribute<AliasAttribute>()?.Alias;

        private void SaveChanges(IEntity entity)
        {
            string updateQuery = "";
            if (entity.id != Guid.Empty)
            {
                var propertyCount = entity.GetType().GetProperties().Count();
                var counter = 0;
                updateQuery = $"UPDATE {TableName} SET ";
                foreach (var prop in entity.GetType().GetProperties())
                {

                    if (!prop.GetCustomAttributes().Any(
                    x => x.GetType().Name == "NonChangeAttribute") && counter < propertyCount - 2)
                        updateQuery += String.Format("{0} = '{1}',",
                            prop.GetCustomAttribute<AliasAttribute>()?.Alias, prop.GetValue(entity));
                    else if (!prop.GetCustomAttributes().Any(
                    x => x.GetType().Name == "NonChangeAttribute") && counter == propertyCount - 2)
                        updateQuery += String.Format("{0} = '{1}'",
                            prop.GetCustomAttribute<AliasAttribute>()?.Alias, prop.GetValue(entity));
                    counter++;

                }
                updateQuery += " WHERE " + entity.GetType()
                     .GetProperties().Where(x => x.Name == "id")?.FirstOrDefault()?
                .GetCustomAttribute<AliasAttribute>()?.Alias
                     + String.Format(" = '{0}'", entity.id.ToString());
                Console.WriteLine(updateQuery);
            }

            if (updateQuery != "")
            {

                using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
                using (var command = new NpgsqlCommand(updateQuery, conn))
                {

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            LoadData(dataGridView);

        }
        private void LoadData(DataGridView dataGridView1)
        {
            string query = String.Format("SELECT * FROM {0}", TableName);

            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                var command = new NpgsqlCommand(query, conn);
                try
                {
                    using (var cmd = new NpgsqlCommand(String.Format("SELECT * FROM {0}", TableName), conn))
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
        private void DeleteItem(DataGridView dataGridView1)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedId = dataGridView1.SelectedRows[0].Cells[TableId].Value;
                using (var connection = new NpgsqlConnection(DataBaseConnection.ConnectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(String.Format("DELETE FROM {0} WHERE {1} = '{2}'",
                        TableName, TableId, selectedId), connection))
                    {
                        command.Parameters.AddWithValue(TableId, selectedId);
                        command.ExecuteNonQuery();
                    }
                }
                //int id, const std::string& name, double price, int quantity, double rating)
            }
            LoadData();
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
                        && Double.TryParse(top, out double top1) && bottom1 < top1)
                        subquery1 = String.Format(" AND {0} > ", filter)
                            + bottom1 + String.Format("AND {0} < ", filter) + top1;
                    else if (Double.TryParse(bottom, out bottom1) &&
                        !Double.TryParse(top, out top1))
                        subquery1 = String.Format(" AND {0} > ", filter) + bottom1;
                    else if (Double.TryParse(top, out top1))
                        subquery1 = String.Format(" AND {0} < ", filter) + top1;
                }

            }
            return subquery1;
        }

        private void LoadFiltredData(DataGridView dataGridView1,
            System.Windows.Forms.ComboBox comboBox2, System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2, System.Windows.Forms.TextBox textBox3)
        {
            string subquery1 = FilterSubsQuery(textBox2.Text, textBox3.Text, comboBox2.Text);
            string query = String.Format("SELECT * FROM {0} WHERE {1} LIKE '%{2}%'",
                TableName, TableObjectName, textBox1.Text) + subquery1;
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                var command = new NpgsqlCommand(query, conn);

                try
                {
                    using (var cmd = new NpgsqlCommand(String.Format("SELECT * FROM {0} WHERE {1} LIKE '%{2}%'",
                        TableName, TableObjectName, textBox1.Text) + subquery1, conn))
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
    }
}
