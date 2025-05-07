using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
    partial class ItemsForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label10 = new Label();
            textBox7 = new TextBox();
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
            label1.Size = new Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "Item Name";
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 4;
            label2.Text = "Category";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(197, 86);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(168, 28);
            comboBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(197, 63);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 6;
            label3.Text = "Filter";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(416, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(588, 87);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(134, 27);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(384, 89);
            label4.Name = "label4";
            label4.Size = new Size(26, 20);
            label4.TabIndex = 9;
            label4.Text = "От";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(556, 90);
            label5.Name = "label5";
            label5.Size = new Size(28, 20);
            label5.TabIndex = 10;
            label5.Text = "До";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(416, 9);
            label6.Name = "label6";
            label6.Size = new Size(176, 60);
            label6.TabIndex = 11;
            label6.Text = "Товары";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, 127);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1000, 420);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 10);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 14;
            label7.Text = "Name";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(5, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(176, 27);
            textBox4.TabIndex = 15;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(208, 33);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(176, 27);
            textBox5.TabIndex = 16;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(409, 33);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(176, 27);
            textBox6.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(208, 7);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 18;
            label8.Text = "Price";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(409, 7);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 19;
            label9.Text = "Quantity";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(14, 11);
            button3.Name = "button3";
            button3.Size = new Size(112, 39);
            button3.TabIndex = 20;
            button3.Text = "Add";
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
            button4.Text = "Delete";
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
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(7, 547);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(619, 107);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 63);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 21;
            label10.Text = "Dealer Name";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(5, 77);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(176, 27);
            textBox7.TabIndex = 20;
            // 
            // ItemsForm
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
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "ItemsForm";
            Text = "Items";
            Load += Items_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // Настройка TrackBar


        //private void TrackBar1_Scroll(object sender, EventArgs e)
        //    {
        //        // Проверка, есть ли выделенная ячейка
        //        if (dataGridView1.CurrentCell != null)
        //        {
        //            // Установка значения из TrackBar в текущую ячейку
        //            dataGridView1.CurrentCell.Value = trackBar1.Value;
        //        }
        //    }

        #endregion

        private void button1_Click(Object sender, EventArgs e)
        {
            LoadFiltredData();

        }
        private void button4_Click(Object sender, EventArgs e)
        {
            DeleteItem();
        }
        private void button5_Click(Object sender, EventArgs e)
        {
            ViewDetails();
        }
        private void buttonBack_Click(Object sender, EventArgs e)
        {
            this.Owner.Location = this.Location;
            this.Owner.Show();
            this.Hide(); // Закрыть первую форму
            
        }
        private void button3_Click(Object sender, EventArgs e)
        {
            AddItem();

        }
        private List<Item> products;
        private void buttonViewDetails_Click(Object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
            }
        }


        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dataGridView1;
        private Label label7;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label8;
        private Label label9;
        private Button button3;
        private Button button4;
        private Button button5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label10;
        private TextBox textBox7;
    }
}