using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    public partial class NavigationForm : Form
    {
        public NavigationForm()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 150); // координаты на экране
            InitializeComponent();
            this.FormClosing += NavigationForm_FormClosing;
            InitializeSidebar();
        }
        private Button button1, button2, button3, button4, button5;
        private Button currentButton;
        private Panel leftBorderPanel;
        private void NavigationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Проходим по всем открытым дочерним формам
            foreach (Form openForm in Application.OpenForms)
            {
                // Опционально: исключаете главную форму из закрытия
                if (openForm != this)
                {
                    openForm.Close();
                }
            }
        }
        private void InitializeSidebar()
        {
            panelSidebar.BackColor = Color.FromArgb(30, 30, 45);

            // Создание кнопок
            Button btnItems = CreateSidebarButton("Товары", 0, (s, e) => LoadFormInPanel(new ItemsForm()));
            Button btnDealers = CreateSidebarButton("Поставщики", 40, (s, e) => LoadFormInPanel(new DealersForm()));
            Button btnOrders = CreateSidebarButton("Заказы", 80, (s, e) => LoadFormInPanel(new OrdersForm()));
            Button btnUsers = CreateSidebarButton("Пользователи", 120, (s, e) => LoadFormInPanel(new UsersForm()));

            panelSidebar.Controls.AddRange(new Control[] { btnItems, btnDealers, btnOrders, btnUsers });
        }

        private Button CreateSidebarButton(string text, int top, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = panelSidebar.Width,
                Height = 40,
                Top = top,
                Left = 0,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(30, 30, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) =>
            {
                ActivateButton(btn);
                onClick.Invoke(s, e);
            };
            return btn;
        }
        
        private void ActivateButton(Button btn)
        {
            if (currentButton != null)
                currentButton.BackColor = Color.FromArgb(30, 30, 45);

            btn.BackColor = Color.FromArgb(60, 60, 90);
            currentButton = btn;

            // переместим полоску
            leftBorderPanel.Top = btn.Top;
            leftBorderPanel.Visible = true;
            leftBorderPanel.BringToFront();
        }

        private void LoadFormInPanel(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
