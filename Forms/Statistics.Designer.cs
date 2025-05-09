using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1.Forms
{
    partial class Statistics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.Label lblTotalSum;
        private System.Windows.Forms.Label lblPopularItem;
        private System.Windows.Forms.Label lblAVGSum;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDaily;
        private System.Windows.Forms.TabPage tabPageTopItems;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopItems;
        private System.Windows.Forms.TabPage tabPageMonthlyRevenue;
        private System.Windows.Forms.TabPage tabPageCustomerAcquisition;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthlyRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCustomerAcquisition;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnLoadStats;
        private System.Windows.Forms.TabPage tabPageOrdersAndRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUnion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbMonth = new ComboBox();
            this.cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMonth.Location = new Point(30, 15);
            this.cmbMonth.Size = new Size(150, 30);
            this.cmbMonth.Items.AddRange(new string[] {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            });
            this.cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            this.Controls.Add(this.cmbMonth);

            this.btnLoadStats = new Button();
            this.btnLoadStats.Text = "Загрузить";
            this.btnLoadStats.Location = new Point(200, 15);
            this.btnLoadStats.Size = new Size(100, 30);
            this.btnLoadStats.Click += new EventHandler(this.BtnLoadStats_Click);
            this.Controls.Add(this.btnLoadStats);

            this.lblOrderCount = new System.Windows.Forms.Label();
            this.lblTotalSum = new System.Windows.Forms.Label();
            this.lblPopularItem = new System.Windows.Forms.Label();
            this.lblAVGSum = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDaily = new System.Windows.Forms.TabPage();
            this.tabPageTopItems = new System.Windows.Forms.TabPage();
            this.tabPageMonthlyRevenue = new System.Windows.Forms.TabPage();
            this.tabPageCustomerAcquisition = new System.Windows.Forms.TabPage();
            this.tabPageOrdersAndRevenue = new System.Windows.Forms.TabPage();
            this.chartDailyStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopItems = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMonthlyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCustomerAcquisition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUnion = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.tabControl.SuspendLayout();
            this.tabPageDaily.SuspendLayout();
            this.tabPageTopItems.SuspendLayout();
            this.tabPageMonthlyRevenue.SuspendLayout();
            this.tabPageCustomerAcquisition.SuspendLayout();
            this.tabPageOrdersAndRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerAcquisition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUnion)).BeginInit();
            this.SuspendLayout();

            // lblOrderCount
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderCount.Location = new System.Drawing.Point(30, 50);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(160, 23);
            this.lblOrderCount.Text = "Заказов: загрузка...";

            // lblTotalSum
            this.lblTotalSum.AutoSize = true;
            this.lblTotalSum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalSum.Location = new System.Drawing.Point(30, 80);
            this.lblTotalSum.Name = "lblTotalSum";
            this.lblTotalSum.Size = new System.Drawing.Size(155, 23);
            this.lblTotalSum.Text = "Сумма: загрузка...";

            // lblPopularItem
            this.lblPopularItem.AutoSize = true;
            this.lblPopularItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPopularItem.Location = new System.Drawing.Point(30, 110);
            this.lblPopularItem.Name = "lblPopularItem";
            this.lblPopularItem.Size = new System.Drawing.Size(215, 23);
            this.lblPopularItem.Text = "Популярный товар: ...";

            // lblAVGSum
            this.lblAVGSum.AutoSize = true;
            this.lblAVGSum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAVGSum.Location = new System.Drawing.Point(30, 140);
            this.lblAVGSum.Name = "lblAVGSum";
            this.lblAVGSum.Size = new System.Drawing.Size(215, 23);
            this.lblAVGSum.Text = "Средний чек: ...";

            // tabControl
            this.tabControl.Controls.Add(this.tabPageDaily);
            this.tabControl.Controls.Add(this.tabPageTopItems);
            this.tabControl.Controls.Add(this.tabPageMonthlyRevenue);
            this.tabControl.Controls.Add(this.tabPageCustomerAcquisition);
            this.tabControl.Controls.Add(this.tabPageOrdersAndRevenue);
            this.tabControl.Location = new System.Drawing.Point(30, 200);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(800, 500);
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            // tabPageDaily
            this.tabPageDaily.Controls.Add(this.chartDailyStats);
            this.tabPageDaily.Location = new System.Drawing.Point(4, 29);
            this.tabPageDaily.Name = "tabPageDaily";
            this.tabPageDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDaily.Size = new System.Drawing.Size(792, 467);
            this.tabPageDaily.Text = "По дням";
            this.tabPageDaily.UseVisualStyleBackColor = true;

            // tabPageTopItems
            this.tabPageTopItems.Controls.Add(this.chartTopItems);
            this.tabPageTopItems.Location = new System.Drawing.Point(4, 29);
            this.tabPageTopItems.Name = "tabPageTopItems";
            this.tabPageTopItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTopItems.Size = new System.Drawing.Size(792, 467);
            this.tabPageTopItems.Text = "Топ товары";
            this.tabPageTopItems.UseVisualStyleBackColor = true;

            // tabPageMonthlyRevenue
            this.tabPageMonthlyRevenue.Controls.Add(this.chartMonthlyRevenue);
            this.tabPageMonthlyRevenue.Location = new System.Drawing.Point(4, 29);
            this.tabPageMonthlyRevenue.Name = "tabPageMonthlyRevenue";
            this.tabPageMonthlyRevenue.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthlyRevenue.Size = new System.Drawing.Size(792, 467);
            this.tabPageMonthlyRevenue.Text = "Ежемесячная выручка";
            this.tabPageMonthlyRevenue.UseVisualStyleBackColor = true;

            // tabPageCustomerAcquisition
            this.tabPageCustomerAcquisition.Controls.Add(this.chartCustomerAcquisition);
            this.tabPageCustomerAcquisition.Location = new System.Drawing.Point(4, 29);
            this.tabPageCustomerAcquisition.Name = "tabPageCustomerAcquisition";
            this.tabPageCustomerAcquisition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomerAcquisition.Size = new System.Drawing.Size(792, 467);
            this.tabPageCustomerAcquisition.Text = "Приобретение клиентов";
            this.tabPageCustomerAcquisition.UseVisualStyleBackColor = true;

            // tabPageOrdersAndRevenue
            this.tabPageOrdersAndRevenue.Controls.Add(this.chartUnion);
            this.tabPageOrdersAndRevenue.Location = new System.Drawing.Point(4, 29);
            this.tabPageOrdersAndRevenue.Name = "tabPageOrdersAndRevenue";
            this.tabPageOrdersAndRevenue.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrdersAndRevenue.Size = new System.Drawing.Size(792, 467);
            this.tabPageOrdersAndRevenue.Text = "Заказы и выручка";
            this.tabPageOrdersAndRevenue.UseVisualStyleBackColor = true;

            // chartDailyStats
            this.chartDailyStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDailyStats.Location = new System.Drawing.Point(3, 3);
            this.chartDailyStats.Name = "chartDailyStats";
            this.chartDailyStats.Size = new System.Drawing.Size(786, 461);
            this.chartDailyStats.TabIndex = 0;
            this.chartDailyStats.Text = "chart1";
            this.chartDailyStats.ChartAreas.Add(new ChartArea());

            // chartTopItems
            this.chartTopItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTopItems.Location = new System.Drawing.Point(3, 3);
            this.chartTopItems.Name = "chartTopItems";
            this.chartTopItems.Size = new System.Drawing.Size(786, 461);
            this.chartTopItems.TabIndex = 1;
            this.chartTopItems.Text = "chart2";
            this.chartTopItems.ChartAreas.Add(new ChartArea());

            // chartMonthlyRevenue
            this.chartMonthlyRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMonthlyRevenue.Location = new System.Drawing.Point(3, 3);
            this.chartMonthlyRevenue.Name = "chartMonthlyRevenue";
            this.chartMonthlyRevenue.Size = new System.Drawing.Size(786, 461);
            this.chartMonthlyRevenue.TabIndex = 2;
            this.chartMonthlyRevenue.Text = "chartMonthlyRevenue";
            this.chartMonthlyRevenue.ChartAreas.Add(new ChartArea());

            // chartCustomerAcquisition
            this.chartCustomerAcquisition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCustomerAcquisition.Location = new System.Drawing.Point(3, 3);
            this.chartCustomerAcquisition.Name = "chartCustomerAcquisition";
            this.chartCustomerAcquisition.Size = new System.Drawing.Size(786, 461);
            this.chartCustomerAcquisition.TabIndex = 3;
            this.chartCustomerAcquisition.Text = "chartCustomerAcquisition";
            this.chartCustomerAcquisition.ChartAreas.Add(new ChartArea());

            // chartUnion
            this.chartUnion.Location = new System.Drawing.Point(3, 3);
            this.chartUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartUnion.Name = "chartUnion";
            this.chartUnion.TabIndex = 4;
            this.chartUnion.Text = "chartUnion";
            this.chartUnion.ChartAreas.Add(new ChartArea("MainArea"));
            this.chartUnion.Size = new System.Drawing.Size(786, 461);

            // OrderStatistics
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 650);
            this.Controls.Add(this.lblPopularItem);
            this.Controls.Add(this.lblTotalSum);
            this.Controls.Add(this.lblOrderCount);
            this.Controls.Add(this.lblAVGSum);
            this.Controls.Add(this.tabControl);
            this.Name = "OrderStatistics";
            this.Text = "Статистика заказов";

            this.tabControl.ResumeLayout(false);
            this.tabPageDaily.ResumeLayout(false);
            this.tabPageTopItems.ResumeLayout(false);
            this.tabPageMonthlyRevenue.ResumeLayout(false);
            this.tabPageCustomerAcquisition.ResumeLayout(false);
            this.tabPageOrdersAndRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerAcquisition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUnion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

