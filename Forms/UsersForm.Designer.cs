using Npgsql;

namespace WinFormsApp1.Forms
{
    partial class UsersForm
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
            label6 = new Label();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
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
            label1.Size = new Size(108, 20);
            label1.TabIndex = 1;
            label1.Text = "Phone Number";
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
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(384, 10);
            label6.Name = "label6";
            label6.Size = new Size(308, 60);
            label6.TabIndex = 11;
            label6.Text = "Пользователи";
            // 
            // button2
            // 
            button2.Location = new Point(874, 31);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 12;
            button2.Text = "back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1000, 422);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(14, 11);
            button4.Name = "button4";
            button4.Size = new Size(230, 39);
            button4.TabIndex = 21;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = false;
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
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Location = new Point(661, 553);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 101);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "UsersForm";
            Text = "Dealers";
            Load += UsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void buttonBack_Click(Object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide(); // Закрыть первую форму

        }
        

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label6;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button5;
        private GroupBox groupBox1;
    }
}