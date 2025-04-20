using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    partial class NavigationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(254, 85);
            button1.Name = "button1";
            button1.Size = new Size(513, 75);
            button1.TabIndex = 0;
            button1.Text = "Товары";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(254, 200);
            button2.Name = "button2";
            button2.Size = new Size(513, 75);
            button2.TabIndex = 1;
            button2.Text = "Поставщики";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(254, 312);
            button3.Name = "button3";
            button3.Size = new Size(513, 75);
            button3.TabIndex = 2;
            button3.Text = "Заказы";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(254, 428);
            button4.Name = "button4";
            button4.Size = new Size(513, 75);
            button4.TabIndex = 3;
            button4.Text = "Пользователи";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // NavigationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "NavigationForm";
            Text = "Navigation Form";
            Load += NavigationForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private void button1_Click(Object sender, EventArgs e)
        {
            this.Hide(); // Закрыть первую форму
            ItemsForm form = new ItemsForm();
            form.Owner = this;
            form.Show();
        }
        private void button2_Click(Object sender, EventArgs e)
        {
            this.Hide(); // Закрыть первую форму
            DealersForm form = new DealersForm();
            form.Owner = this;
            form.Show();
        }
        private void button3_Click(Object sender, EventArgs e)
        {
            this.Hide(); // Закрыть первую форму
            OrdersForm form = new OrdersForm();
            form.Owner = this;
            form.Show();
        }
        private void button4_Click(Object sender, EventArgs e)
        {
            this.Hide(); // Закрыть первую форму
            UsersForm form = new UsersForm();
            form.Owner = this;
            form.Show();
        }

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}