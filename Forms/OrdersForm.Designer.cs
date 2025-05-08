namespace WinFormsApp1.Forms
{
    partial class OrdersForm
    {
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label8 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            textBox7 = new TextBox();
            label3 = new Label();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Order Id";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(197, 31);
            button1.Name = "button1";
            button1.Size = new Size(168, 29);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(229, 82);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(403, 82);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(134, 27);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, 86);
            label4.Name = "label4";
            label4.Size = new Size(26, 20);
            label4.TabIndex = 9;
            label4.Text = "От";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 87);
            label5.Name = "label5";
            label5.Size = new Size(28, 20);
            label5.TabIndex = 10;
            label5.Text = "До";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(384, 10);
            label6.Name = "label6";
            label6.Size = new Size(166, 60);
            label6.TabIndex = 11;
            label6.Text = "Заказы";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1000, 407);
            dataGridView1.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 0);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 18;
            label8.Text = "Items";
            label8.Click += label8_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(14, 11);
            button3.Name = "button3";
            button3.Size = new Size(112, 39);
            button3.TabIndex = 20;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(132, 11);
            button4.Name = "button4";
            button4.Size = new Size(112, 39);
            button4.TabIndex = 21;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Location = new Point(14, 56);
            button5.Name = "button5";
            button5.Size = new Size(230, 39);
            button5.TabIndex = 22;
            button5.Text = "View Details";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Location = new Point(661, 553);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 101);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 25;
            label2.Text = "Final Place";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 23);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(176, 81);
            textBox5.TabIndex = 16;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(209, 18);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(176, 27);
            textBox6.TabIndex = 24;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 538);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(617, 110);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(416, 0);
            label9.Name = "label9";
            label9.Size = new Size(141, 20);
            label9.TabIndex = 27;
            label9.Text = "User Phone Number";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(416, 18);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(176, 27);
            textBox7.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 6;
            label3.Text = "Filter";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 82);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(168, 28);
            comboBox2.TabIndex = 5;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "OrdersForm";
            Text = "Orders";
            Load += OrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void buttonBack_Click(Object sender, EventArgs e)
        {
            this.Owner.Location = this.Location;
            this.Owner.Show();
            this.Hide(); // Закрыть первую форму

        }
        private void button5_Click(Object sender, EventArgs e)
        {
            ViewDetails();

        }
        private void button3_Click(Object sender, EventArgs e)
        {
            string userId = textBox7.Text.Trim();
            string finalPlaceText = textBox6.Text.Trim();
            string input = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(finalPlaceText) || string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!int.TryParse(finalPlaceText, out int finalPlace))
            {
                MessageBox.Show("Неверное значение в поле 'Место'.");
                return;
            }

            var items = new List<(Guid, int)>();
            try
            {
                var entries = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var entry in entries)
                {
                    var parts = entry.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 2)
                        throw new Exception("Неверный формат: " + entry);

                    Guid itemId = Guid.Parse(parts[0]);
                    int quantity = int.Parse(parts[1]);
                    items.Add((itemId, quantity));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка разбора ввода: " + ex.Message);
                return;
            }

            CreateOrder(userId, finalPlace, items);
            
        }
        private void button4_Click(Object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 
                && dataGridView1.SelectedRows[0].Cells["order_id"].Value.ToString() != "")
            CancelOrder(dataGridView1.SelectedRows[0].Cells["order_id"].Value.ToString());

        }
        private void button1_Click(Object sender, EventArgs e)
        {
            LoadFilteredData();

        }
        

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dataGridView1;
        private Label label8;
        private Button button3;
        private Button button4;
        private Button button5;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox5;
        private TextBox textBox6;
        private GroupBox groupBox2;
        private Label label3;
        private ComboBox comboBox2;
        private Label label9;
        private TextBox textBox7;
    }
}