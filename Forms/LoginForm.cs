using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using WinFormsApp1.docker;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 150); // координаты на экране
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        
        private string GenerateHash(string text) => BCrypt.Net.BCrypt.HashPassword(text);
        private bool Authorize(string login, string password)
        {
            var salt = "$yj*94g=)";
            string query = String.Format("SELECT is_staff, is_superuser FROM " +
                "users WHERE phone_number = @phone_number AND hashed_password = @hashed_password");
            string is_staff = "";
            string is_superuser = "";
            using (var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                var command = new NpgsqlCommand(query, conn);
                command.Parameters.AddWithValue("@phone_number", ComputeSha256Hash(login+salt));
                command.Parameters.AddWithValue("@hashed_password", ComputeSha256Hash(password + salt));
                conn.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Обрабатываем результаты запроса
                            is_staff = reader["is_staff"].ToString();
                            is_superuser = reader["is_superuser"].ToString();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            if (is_superuser == "True") return true;
            else if (is_superuser == "False" && is_staff == "True") { DataBaseQueries.IsOperator = true; return true; }
            else return false;
        }
        public static string ComputeSha256Hash(string rawData)
        {
            // Создаем SHA256 объект
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в байты и получаем хеш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Конвертируем байты в шестнадцатеричную строку
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // "x2" — для шестнадцатеричного формата
                }
                return builder.ToString();
            }
        }

    }
}
