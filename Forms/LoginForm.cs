using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System.Data;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private string GenerateHash(string text) => BCrypt.Net.BCrypt.HashPassword(text);
        private bool Authorize(string login, string password)
        {
            string query = String.Format("SELECT hash_password FROM admin_users WHERE phone_number = '{0}'", login);
            string password_hash = "";
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                var command = new NpgsqlCommand(query, conn);
                try
                {
                    using (var cmd = new NpgsqlCommand(String.Format("SELECT hash_password FROM admin_users WHERE phone_number = '{0}'",
                        login), conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Обрабатываем результаты запроса
                            password_hash = reader["hash_password"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            return BCrypt.Net.BCrypt.Verify(password, password_hash);
        }

    }
}
