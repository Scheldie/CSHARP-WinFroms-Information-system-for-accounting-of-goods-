using System.Reflection;
using System.Xml.Linq;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Forms
{
    partial class Details
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(512, 223);
            button1.Name = "button1";
            button1.Size = new Size(117, 29);
            button1.TabIndex = 0;
            button1.Text = "Save Changes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 280);
            Controls.Add(button1);
            Name = "Details";
            Text = "Details";
            Load += Details_Load;
            ResumeLayout(false);
        }

        #endregion
        private void button1_Click(Object sender, EventArgs e)
        {
            
            foreach (var control in this.Controls)
            {
                string updatedData;
                if (control.GetType() == typeof(TextBox))
                {
                    updatedData = (control as TextBox).Text;
                    if (_entity.GetType().GetProperty((control as TextBox).Name)
                        .PropertyType == typeof(Guid))
                    {
                        _entity.GetType().GetProperty((control as TextBox).Name)
                        .SetValue(_entity, Guid.Parse(updatedData));
                    }
                    else
                    {
                        _entity.GetType().GetProperty((control as TextBox).Name)
                            .SetValue(_entity, Convert.ChangeType(
                                updatedData, _entity.GetType().GetProperty(
                                    (control as TextBox).Name).PropertyType));
                    }
                }
                
            }
            form1.SaveChanges(_entity);
            this.Close();
        }

        private Button button1;
    }
}