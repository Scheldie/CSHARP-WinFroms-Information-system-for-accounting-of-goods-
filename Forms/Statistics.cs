using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Forms
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            LoadStatistics();
            LoadDailyCharts();
            LoadTopItemsChart();
            LoadMonthlyRevenueChart();
            LoadCustomerAcquisitionChart();
            LoadOrdersAndRevenueChart();

        }

        private void OrderStatistics_Load(object sender, EventArgs e)
        {

        }

        private int selectedMonth => cmbMonth.SelectedIndex + 1;
        private void LoadStatistics()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();

                // Количество заказов и сумма
                NpgsqlCommand cmd1 = new NpgsqlCommand(@"
                    SELECT COUNT(*) AS OrderCount, SUM(count) AS TotalSum
                    FROM orders
                    WHERE EXTRACT(MONTH FROM orders.date) = @month 
                    AND EXTRACT(YEAR FROM date) = EXTRACT(YEAR FROM current_date)", conn);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);

                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    lblOrderCount.Text = "Заказов: " + reader1["OrderCount"].ToString();
                    lblTotalSum.Text = "Количество товаров в заказах: " + reader1["TotalSum"].ToString();
                }
                reader1.Close();

                // Популярный товар
                NpgsqlCommand cmd2 = new NpgsqlCommand(@"
                    SELECT ordered_item.item_id, SUM(ordered_item.count) AS total_quantity
                    FROM ordered_item
                    JOIN orders ON orders.order_id = ordered_item.order_id
                    WHERE EXTRACT(MONTH FROM orders.date) = @month
                    AND EXTRACT(YEAR FROM orders.date) = EXTRACT(YEAR FROM current_date)
                    GROUP BY ordered_item.item_id
                    ORDER BY total_quantity DESC
                    LIMIT 1", conn);
                cmd2.Parameters.AddWithValue("@month", selectedMonth);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    // Get the item_id from the most popular item
                    Guid itemId = (Guid)reader2["item_id"];
                    int totalQuantity = Int32.Parse(reader2["total_quantity"].ToString());

                    // Close the reader before executing the next command
                    reader2.Close();

                    // Command to get the item name
                    NpgsqlCommand cmd3 = new NpgsqlCommand(@"
                        SELECT item_name
                        FROM item 
                        WHERE item_id = @item_id", conn);
                    cmd3.Parameters.AddWithValue("@item_id", itemId);

                    NpgsqlDataReader reader3 = cmd3.ExecuteReader();

                    if (reader3.Read())
                    {
                        lblPopularItem.Text = $"Топ товар: {reader3["item_name"]} (Кол-во: {totalQuantity})";
                    }
                    reader3.Close();
                }
                else
                {
                    reader2.Close();
                }
                // Популярный товар
                NpgsqlCommand cmd4 = new NpgsqlCommand(@"
                    SELECT AVG(final_cost) AS average_order_cost
                    FROM orders
                    WHERE EXTRACT(MONTH FROM date) = @month
                    AND EXTRACT(YEAR FROM date) = EXTRACT(YEAR FROM current_date)", conn);
                cmd4.Parameters.AddWithValue("@month", selectedMonth);
                NpgsqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    lblAVGSum.Text = "Средняя сумма заказа: " + Math.Round(Double.Parse(reader4["average_order_cost"].ToString()), 2) + " руб.";
                    
                }
                reader4.Close();
            }
        }
        private void LoadOrdersAndRevenueChart()
        {
            chartUnion.Series.Clear();
            chartUnion.ChartAreas[0].AxisX.Title = "Месяц";
            chartUnion.ChartAreas[0].AxisY.Title = "Количество заказов / Выручка";
            chartUnion.ChartAreas[0].AxisX.Interval = 1;

            var ordersSeries = new Series("Заказы")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                IsValueShownAsLabel = true
            };

            var revenueSeries = new Series("Выручка")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.OrangeRed,
                IsValueShownAsLabel = true,
                YAxisType = AxisType.Secondary
            };

            using var conn = new NpgsqlConnection(DataBaseConnection.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT EXTRACT(MONTH FROM date) AS month, COUNT(*)::float AS value, 'Заказы' AS type
                FROM orders
                WHERE EXTRACT(YEAR FROM date) = EXTRACT(YEAR FROM CURRENT_DATE)
                GROUP BY month

                UNION

                SELECT EXTRACT(MONTH FROM date), SUM(final_cost), 'Выручка'
                FROM orders
                WHERE EXTRACT(YEAR FROM date) = EXTRACT(YEAR FROM CURRENT_DATE)
                GROUP BY EXTRACT(MONTH FROM date)
                ORDER BY month;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            var monthLabels = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            while (reader.Read())
            {
                int month = Convert.ToInt32(reader["month"]);
                double value = Convert.ToDouble(reader["value"]);
                string type = reader["type"].ToString();
                string label = monthLabels[month - 1];

                if (type == "Заказы")
                    ordersSeries.Points.AddXY(label, value);
                else if (type == "Выручка")
                    revenueSeries.Points.AddXY(label, value);
            }

            chartUnion.Series.Add(ordersSeries);
            chartUnion.Series.Add(revenueSeries);
        }

        private void LoadDailyCharts()
        {

            chartDailyStats.Series.Clear();
            chartDailyStats.ChartAreas[0].AxisX.Title = "Дни";
            chartDailyStats.ChartAreas[0].AxisY.Title = "Кол-во заказов";

            Series orderSeries = new Series("Заказы")
            {
                ChartType = SeriesChartType.Column
            };

            using (NpgsqlConnection conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"
                    SELECT EXTRACT(DAY FROM date) AS Day, COUNT(*) AS Count
                    FROM orders
                    WHERE EXTRACT(MONTH FROM orders.date) = @month
                    AND EXTRACT(YEAR FROM date) = EXTRACT(YEAR FROM current_date)
                    GROUP BY EXTRACT(DAY FROM date)
                    ORDER BY Day", conn);
                cmd.Parameters.AddWithValue("@month", selectedMonth);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int day = Convert.ToInt32(reader["Day"]);
                    int count = Convert.ToInt32(reader["Count"]);
                    orderSeries.Points.AddXY(day, count);
                }
                reader.Close();
            }

            chartDailyStats.Series.Add(orderSeries);
        }

        private void LoadTopItemsChart()
        {

            chartTopItems.Series.Clear();
            chartTopItems.Titles.Clear();
            chartTopItems.ChartAreas[0].AxisX.Title = "Товары";
            chartTopItems.ChartAreas[0].AxisY.Title = "Процент от всех продаж (%)";

            chartTopItems.ChartAreas[0].AxisY.Minimum = 0;
            chartTopItems.ChartAreas[0].AxisY.LabelStyle.Format = "P2"; // P2 = 2 знака после запятой
            chartTopItems.ChartAreas[0].AxisY.Interval = chartTopItems.ChartAreas[0].AxisY.Maximum/10; // шаг — 10%
            
            // Подстройка отображения осей
            var chartArea = chartTopItems.ChartAreas[0];
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45; // Наклон подписей
            chartArea.AxisX.LabelStyle.IsStaggered = false;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.LabelStyle.Format = "P2"; // проценты
            chartArea.RecalculateAxesScale(); // пересчёт масштаба


            // Очистка легенд и добавление заново
            chartTopItems.Legends.Clear();
            chartTopItems.Legends.Add(new Legend("Топ-10 товаров месяца") { Enabled = false });

            Series series = new Series("Популярность товаров")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            double maxPercent = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();

                // Получаем общее количество всех заказанных товаров
                int totalOrdered = 0;
                using (var totalCmd = new NpgsqlCommand(@"
                    SELECT SUM(ordered_item.count) FROM ordered_item
                    JOIN orders ON orders.order_id = ordered_item.order_id
                    WHERE EXTRACT(MONTH FROM orders.date) = @month
                    AND EXTRACT(YEAR FROM orders.date) = EXTRACT(YEAR FROM current_date)", conn))
                {
                    totalCmd.Parameters.AddWithValue("@month", selectedMonth);
                    var result = totalCmd.ExecuteScalar();
                    totalOrdered = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }

                

                // Получаем количество по каждому товару
                var cmd = new NpgsqlCommand(@"
                    SELECT item.item_name, SUM(ordered_item.count) AS Qty
                    FROM ordered_item
                    JOIN orders ON orders.order_id = ordered_item.order_id
                    JOIN item ON item.item_id = ordered_item.item_id
                    WHERE EXTRACT(MONTH FROM orders.date) = @month
                      AND EXTRACT(YEAR FROM orders.date) = EXTRACT(YEAR FROM current_date)
                    GROUP BY item.item_name
                    ORDER BY Qty DESC
                    LIMIT 10", conn);
                cmd.Parameters.AddWithValue("@month", selectedMonth);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string itemName = reader["item_name"].ToString();
                    int count = Convert.ToInt32(reader["Qty"]);
                    double percent = (double)count / totalOrdered;
                    if (percent > maxPercent)
                        maxPercent = percent;
                    series.Points.AddXY(itemName, percent);
                    series.Points.Last().Label = $"{Math.Round(percent*100, 2)}%";
                }
            }

            chartTopItems.ChartAreas[0].AxisY.Maximum = maxPercent+0.1; // если значения малые
            chartTopItems.Series.Add(series);
        }
        private void LoadMonthlyRevenueChart()
        {
            var months = new List<string>();
            months.AddRange(new string[] {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            });
            chartMonthlyRevenue.Series.Clear();
            chartMonthlyRevenue.ChartAreas[0].AxisX.Title = "Месяц";
            chartMonthlyRevenue.ChartAreas[0].AxisY.Title = "Выручка";

            Series revenueSeries = new Series("Выручка")
            {
                ChartType = SeriesChartType.Doughnut
            };

            using (NpgsqlConnection conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                NpgsqlCommand total = new NpgsqlCommand(@"
                    SELECT SUM(final_cost) AS TotalRevenue
                    FROM orders
                    WHERE EXTRACT(YEAR FROM date) =  EXTRACT(YEAR FROM current_date)
                    ", conn);
                var result = total.ExecuteScalar();
                var totalOrdered = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                NpgsqlCommand cmd = new NpgsqlCommand(@"
                    SELECT EXTRACT(MONTH FROM date) AS Month, SUM(final_cost) AS TotalRevenue
                    FROM orders
                    WHERE EXTRACT(YEAR FROM date) =  EXTRACT(YEAR FROM current_date)
                    GROUP BY Month
                    ORDER BY Month
                    ", conn);
                
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int month = Convert.ToInt32(reader["Month"]);
                    decimal revenue = Convert.ToDecimal(reader["TotalRevenue"]);
                    revenueSeries.Points.AddXY(months[month-1], revenue);
                    revenueSeries.Points.Last().Label = $"{Math.Round(revenue,0)} рублей \n {Math.Round(
                        (double)revenue / totalOrdered * 100, 2)}% , {months[month - 1]}";
                    revenueSeries.Points.Last().LabelAngle = -30;
                }
                reader.Close();
            }

            chartMonthlyRevenue.Series.Add(revenueSeries);
        }

        private void LoadCustomerAcquisitionChart()
        {
            chartCustomerAcquisition.Series.Clear();
            chartCustomerAcquisition.ChartAreas[0].AxisX.Title = "Месяц";
            chartCustomerAcquisition.ChartAreas[0].AxisY.Title = "Новые клиенты";

            Series acquisitionSeries = new Series("Новые клиенты")
            {
                ChartType = SeriesChartType.Column
            };

            using (NpgsqlConnection conn = new NpgsqlConnection(DataBaseConnection.ConnectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"
                    SELECT EXTRACT(MONTH FROM registered_at) AS Month, COUNT(*) AS NewCustomers
                    FROM users
                    WHERE EXTRACT(YEAR FROM registered_at) = EXTRACT(YEAR FROM current_date)
                    AND is_active = true AND is_superuser = false AND is_staff = false
                    GROUP BY Month
                    ORDER BY Month
                    ", conn);
                cmd.Parameters.AddWithValue("@month", selectedMonth);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int month = Convert.ToInt32(reader["Month"]);
                    int newCustomers = Convert.ToInt32(reader["NewCustomers"]);
                    acquisitionSeries.Points.AddXY(month, newCustomers);
                }
                reader.Close();
            }

            chartCustomerAcquisition.Series.Add(acquisitionSeries);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageTopItems)
            {
                LoadTopItemsChart();
            }
            else if (tabControl.SelectedTab == tabPageDaily)
            {
                LoadDailyCharts();
            }
            else if (tabControl.SelectedTab == tabPageMonthlyRevenue)
            {
                LoadMonthlyRevenueChart();
            }
            else if (tabControl.SelectedTab == tabPageCustomerAcquisition)
            {
                LoadCustomerAcquisitionChart();
            }
            else if (tabControl.SelectedTab == tabPageOrdersAndRevenue)
            {
                LoadOrdersAndRevenueChart();
            }

        }
        private void Statistics_Load(object sender, EventArgs e)
        {

        }
        private void Statistics2_Load(object sender, EventArgs e)
        {

        }

        private void TabPageDaily_Click(object sender, EventArgs e)
        {
            LoadDailyCharts();

        }
        private void TabPageTopItems_Click(object sender, EventArgs e)
        {
            LoadTopItemsChart();
        }
        private void BtnLoadStats_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadDailyCharts();
            LoadTopItemsChart();
        }

        private void Statistics_Load_1(object sender, EventArgs e)
        {

        }

        private void Statistics_Load_2(object sender, EventArgs e)
        {

        }

        private void Statistics_Load_3(object sender, EventArgs e)
        {

        }
    }
}
