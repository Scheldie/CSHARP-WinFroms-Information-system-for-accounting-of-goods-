using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Forms
{
    public partial class Details : Form
    {
        private IEntity _entity;
        private ISaveChanges form1;
        public Details(IEntity entity, ISaveChanges form)
        {
            InitializeComponent();
            _entity = entity;
            this.Text = _entity.GetEntityName();
            CreateDynamicControls();
            form1 = form;
        }
        private void CreateDynamicControls()
        {
            int y = 10;
            foreach (var prop in _entity.GetType().GetProperties())
            {
                Label label = new Label
                {
                    Text = prop.Name,
                    Location = new Point(10, y)
                };
                this.Controls.Add(label);
                bool enable = false;
                var attrs = prop.GetCustomAttributes(true);
                if (attrs.Any(x => x.GetType().Name == "NonChangeAttribute")) enable = true;
                TextBox textBox = new TextBox
                {
                    Location = new Point(150, y),
                    Width = 400,
                    Text = prop.GetValue(_entity)?.ToString(),
                    ReadOnly = enable
                };
                textBox.Tag = prop; // Сохраняем свойство в теге для дальнейшего использования
                this.Controls.Add(textBox);

                y += 30; // Увеличиваем координату y для следующего элемента
            }
        }

        private void Details_Load(object sender, EventArgs e)
        {

        }
    }
}
