using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(324, 186);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(434, 43);
            textBox1.TabIndex = 0;
            textBox1.Text = "+7";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(324, 281);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(434, 43);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(324, 340);
            button1.Name = "button1";
            button1.Size = new Size(434, 64);
            button1.TabIndex = 2;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 163);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 3;
            label1.Text = "Номер телефона";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(324, 258);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1100, 740);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "LoginForm";
            Text = "Log In Form";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private void button1_Click(Object sender, EventArgs e)
        {
            try
            {
                if (Authorize(textBox1.Text, textBox2.Text))
                {
                    this.Hide(); // Закрыть первую форму
                    NavigationForm form = new NavigationForm();
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = this.Location;
                    form.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Ошибка: " + ex);
            }
        }

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label1;
        private Label label2;
    }
}
