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
            panelMain = new Panel();
            panelSidebar = new Panel();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(180, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(942, 740);
            panelMain.TabIndex = 1;
            panelMain.Paint += panelMain_Paint;
            // 
            // panelSidebar
            // 
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(180, 740);
            panelSidebar.TabIndex = 0;
            //
            // leftBorderPanel
            //
            leftBorderPanel = new Panel();
            leftBorderPanel.Size = new Size(5, 40);
            leftBorderPanel.BackColor = Color.Cyan;
            panelSidebar.Controls.Add(leftBorderPanel);
            // 
            // NavigationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 740);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Name = "NavigationForm";
            Text = "Навигация";
            ResumeLayout(false);
        }

        #endregion


        private Panel panelMain;
        private Panel panelSidebar;
    }
}