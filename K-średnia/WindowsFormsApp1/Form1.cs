using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<double> x1 = new List<double>();
        List<double> x2 = new List<double>();
        Chart chart = new Chart();
        ChartArea chartarea = new ChartArea("GlownyObszar");
        Series PointSeries = new Series("MojePunkty");
        Random rnd = new Random();
        List<Center_point> center_points = new List<Center_point>();
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeChart(List<double> x1, List<double> x2 , string count_center)
        {
            List<int> memory_numebers = new List<int>();
            List<double[]> memory_colors = new List<double[]>();
            if (int.TryParse(count_center, out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    var randoms_numer = rnd.Next(0,x1.Count);
                    while (memory_numebers.Contains(randoms_numer)) // randoms numebers with date x1 and x2
                    {
                        randoms_numer = rnd.Next(0, x1.Count);
                    }
                    while (true)
                    {
                        bool check_rgb = true; // check rgb for color Center_point color to ensure there are no duplicates.
                        var R = rnd.Next(30, 256);
                        var B = rnd.Next(30, 256);
                        var G = rnd.Next(30, 256);
                        for(int j=0; j < memory_colors.Count; j++)
                        {
                            if (memory_colors[j][0] ==R && memory_colors[j][1] ==B && memory_colors[j][2] == G)
                            {
                                check_rgb = false; 
                                break;
                            }
                        }
                        if(check_rgb)
                        {
                            memory_numebers.Add(randoms_numer);
                            memory_colors.Add(new double[]{R, B, G});
                            Center_point point = new Center_point(x1[randoms_numer], x2[randoms_numer], R, B, G);
                            center_points.Add(point);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    var randoms_numer = rnd.Next(0, x1.Count);
                    while (memory_numebers.Contains(randoms_numer))
                    {
                        randoms_numer = rnd.Next(0, x1.Count);
                    }
                    while (true)
                    {
                        bool check_rgb = true; // check rgb for color Center_point color to ensure there are no duplicates.
                        var R = rnd.Next(50, 236);
                        var B = rnd.Next(50, 236);
                        var G = rnd.Next(50, 236);
                        for (int j = 0; j < memory_colors.Count; j++)
                        {
                            if (memory_colors[j][0] == R && memory_colors[j][1] == B && memory_colors[j][2] == G)
                            {
                                check_rgb = false;
                                break;
                            }
                        }
                        if (check_rgb)
                        {
                            memory_numebers.Add(randoms_numer);
                            memory_colors.Add(new double[] { R, B, G });
                            Center_point point = new Center_point(x1[randoms_numer], x2[randoms_numer], R, B, G);
                            center_points.Add(point);
                            break;
                        }
                    }
                }
            }
            chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart.Location = new Point(10, 10);
            chart.Size = new Size(450, 400);
            this.Controls.Add(chart);
            chartarea.AxisX.Title = "Oś X (X1)";
            chartarea.AxisY.Title = "Oś Y (X2)";
            chart.ChartAreas.Add(chartarea);
            PointSeries.ChartArea = "GlownyObszar";

            PointSeries.ChartType = SeriesChartType.Point;
            PointSeries.MarkerStyle = MarkerStyle.Circle;
            PointSeries.MarkerSize = 5;
            chart.Series.Add(PointSeries);
            for (int i = 0; i < x1.Count; i++)
            {
                int index = PointSeries.Points.AddXY(x1[i], x2[i]);
                PointSeries.Points[index].Color = Color.Black;
            }
            for (int i = 0; i < center_points.Count; i++)
            {
                int index = PointSeries.Points.AddXY(center_points[i].Get_x1(), center_points[i].Get_x2());
                PointSeries.Points[index].Color = Color.Red;
            }

        }
        private void Load_csv()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false };
            using (var reader = new StreamReader("spiralka.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Foo>().ToList();
                foreach (var record in records)
                {
                    ListViewItem item = new ListViewItem(record.x.ToString(CultureInfo.InvariantCulture));
                    item.SubItems.Add(record.y.ToString(CultureInfo.InvariantCulture));
                    Date.Items.Add(item);
                    if (double.TryParse(record.x, NumberStyles.Any, CultureInfo.InvariantCulture, out double result_x1))
                    {
                        x1.Add(result_x1);
                    }
                    if (double.TryParse(record.y, NumberStyles.Any, CultureInfo.InvariantCulture, out double result_x2))
                    {
                        x2.Add(result_x2);
                    }
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List_Divergence.Items.Add("euklidesowa");
            List_Divergence.Items.Add("manhattan");
            List_Divergence.Items.Add("Czebyszewa");
            List_Divergence.Items.Add("Minkowskiego");
            List_Divergence.SelectedIndex = 0;
            Date.View = View.Details;
            Date.Columns.Add("X1", 75);
            Date.Columns.Add("X2", 75);
            Load_csv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeChart(x1, x2 , Center_points_Count.Text);
            label2.Visible = false;
            Center_points_Count.Visible = false;
            button1.Visible = false;
            label3.Visible = true;
            numeric_iter.Visible = true;
            Start_grouping.Visible = true;
            List_Divergence.Visible = true;
            label5.Visible = true;
            ResualGroupsitera.Visible = true;
            label7.Visible = true;
            checkcreateChart.Visible = true;
        }
        private double Measure_distance(Center_point point, double x1, double x2)
        {
            if(List_Divergence.Text == "euklidesowa")
            {
                return Euklidesowa(point, x1, x2);
            }
            else if (List_Divergence.Text == "manhattan")
            {
                return manhattan(point, x1, x2);
            }
            else if (List_Divergence.Text == "Czebyszewa")
            {
                return Czebyszewa(point, x1, x2);
            }
            else if (List_Divergence.Text == "Minkowskiego")
            {
                return Minkowskiego(point, x1, x2, Count_mink.Text);
            }
            return 0;
        }
        private void Center_points_Count_ValueChanged(object sender, EventArgs e)
        {

        }
        private void InitializeChartafterAlgorithm()
        {
            PointSeries.Points.Clear();
            for (int i = 0; i < center_points.Count; i++)
            {
                int index = PointSeries.Points.AddXY(center_points[i].Get_x1(), center_points[i].Get_x2());
                PointSeries.Points[index].Color = Color.Red;
                var own_point = center_points[i].Get_Own_points();
                for (int j = 0; j < own_point.Count; j++)
                {
                    int index1 = PointSeries.Points.AddXY(x1[own_point[j]], x2[own_point[j]]);
                    PointSeries.Points[index1].Color = center_points[i].SeriesColor;
                }
            }

        }
        private void Start_grouping_Click(object sender, EventArgs e)
        {
            Algorithm_K_center_groups(numeric_iter.Text, ResualGroupsitera.Text);
            InitializeChartafterAlgorithm();
            Start_grouping.Visible = false;
        }
        private double Euklidesowa(Center_point point,double x1,double x2)
        {
            return Math.Sqrt(Math.Pow(x1 - point.Get_x1(), 2) + Math.Pow(x2 - point.Get_x2(), 2));
        }
        private double manhattan(Center_point point, double x1, double x2)
        {
            return Math.Abs(x1 - point.Get_x1())- Math.Abs(x2 - point.Get_x2());
        }
        private double Czebyszewa(Center_point point, double x1, double x2)
        {
            return Math.Max(Math.Abs(x1 - point.Get_x1()), Math.Abs(x2 - point.Get_x2()));
        }
        private double Minkowskiego(Center_point point, double x1, double x2, string Mink)
        {
         if(int.TryParse(Mink,  out int mink)) {
            if (mink < 0)
            {
                mink = 1;
            }
            return Math.Pow(Math.Pow(Math.Abs(x1 - point.Get_x1()), mink) - Math.Pow(Math.Abs(x2 - point.Get_x2()), mink), 1 / mink);
          }
          return Math.Pow(Math.Pow(Math.Abs(x1 - point.Get_x1()), 1) - Math.Pow(Math.Abs(x2 - point.Get_x2()), 1), 1 / 1);
        }
        private void Algorithm_K_center_groups(string count_itera, string result)
        {
            var text = "";
            if (int.TryParse(count_itera, out int itera))
            {
                for (var i = 0; i < itera; i++)
                {
                    foreach (Center_point center in center_points)
                    {
                        center.Remove_points();
                    }
                    var M = x1.Count;
                    for (int s = 0; s < M; s++)
                    {
                        var u = Measure_distance(center_points[0], x1[s], x2[s]);
                        var index_group = 0;

                        for (var j = 1; j < center_points.Count; j++)
                        {
                            var min = Measure_distance(center_points[j], x1[s], x2[s]);
                            if (u > min)
                            {
                                u = min;
                                index_group = j;
                            }
                        }
                        center_points[index_group].Add_point(s);
                    }
                    for (int j = 0; j < center_points.Count; j++)
                    {
                        var X_gr = center_points[j].Get_Own_points();
                        if (X_gr.Count == 0)
                        {
                            continue;
                        }
                        double x1_suma = 0;
                        double x2_suma = 0;
                        foreach (var X in X_gr)
                        {
                            x1_suma += x1[X];
                            x2_suma += x2[X];
                        }
                        center_points[j].Update_Center_point(x1_suma, x2_suma);
                    }
                    if ((i % int.Parse(result) == 0 || i == itera - 1))
                    {
                        var numer_itera_numer = 0;
                        if (i == 0)
                        {
                            numer_itera_numer = 1;
                        }
                        else if (i == itera - 1)
                        {
                            numer_itera_numer = itera;
                        }
                        else
                        {
                            numer_itera_numer = i;
                        }
                        text += $"Numer itera:{numer_itera_numer}\n";
                        listsDategroup.Items.Add($"Wykonany iteracji: {i}");
                        var numer_groups = 1;
                        foreach (Center_point center in center_points)
                        {
                            List<int> points = center.Get_Own_points();
                            listsDategroup.Items.Add($"Numer groupy: {numer_groups}");
                            listsDategroup.Items.Add($"Numer grupy: {numer_groups}");

                            if (points.Count == 0)
                            {
                                listsDategroup.Items.Add("Grupa nie zawiera punktów.");
                                numer_groups++;
                                continue;
                            }

                            var min = points[0];
                            var max = points[0];
                            for (int j = 0; j < points.Count; j++)
                            {
                                if (min > points[j])
                                {
                                    min = points[j];
                                }
                                if (max < points[j])
                                {
                                    max = points[j];
                                }
                            }
                            listsDategroup.Items.Add($"Środe wartość:\n [{center.Get_x1()},{center.Get_x2()}] \n " +
                                $"Liczba próbke:\n {points.Count}\n" +
                                $"maksymalna wartość\n x:{x1[max]},y:{x2[max]}\n minimalna wartość\n x:{x1[min]},y:{x2[min]}\n");
                            text +=
                                $"Numer grupy:{numer_groups}\n" +
                                $"Środe wartość:\n [{center.Get_x1()},{center.Get_x2()}] \n " +
                                $"Liczba próbke:\n {points.Count}\n" +
                                $"maksymalna wartość\n x:{x1[max]},y:{x2[max]}\n minimalna wartość\n x:{x1[min]},y:{x2[min]}\n";
                            numer_groups++;
                        }
                        listsDategroup.Visible = true;
                        label6.Visible = true;
                        if (checkcreateChart.Checked == true)
                        {
                            Chart chart1 = new Chart();
                            chart1.Dock = DockStyle.Fill;

                            ChartArea chartarea1 = new ChartArea("GlownyObszar");
                            chart1.ChartAreas.Add(chartarea1);

                            Series PointSeries1 = new Series("MojePunkty") { ChartType = SeriesChartType.Point };
                            chart1.Series.Add(PointSeries1);

                            PointSeries1.Points.Clear();

                            for (int k = 0; k < center_points.Count; k++)
                            {
                                int index = PointSeries1.Points.AddXY(center_points[k].Get_x1(), center_points[k].Get_x2());
                                PointSeries1.Points[index].Color = Color.Red;
                                var own_point = center_points[k].Get_Own_points();
                                for (int j = 0; j < own_point.Count; j++)
                                {
                                    int index1 = PointSeries1.Points.AddXY(x1[own_point[j]], x2[own_point[j]]);
                                    PointSeries1.Points[index1].Color = center_points[k].SeriesColor;
                                }
                            }

                            Form oknoWykresu = new Form();
                            if (i == 0)
                            {
                                oknoWykresu.Text = $"Wykres po iteracji 1";
                            }
                            else if (i == itera - 1)
                            {
                                oknoWykresu.Text = $"Wykres po iteracji {itera}";
                            }
                            else
                            {
                                oknoWykresu.Text = $"Wykres po iteracji {i}";
                            }


                            oknoWykresu.Width = 800;
                            oknoWykresu.Height = 600;
                            oknoWykresu.Controls.Add(chart1);
                            oknoWykresu.ShowDialog();
                        }
                    }
                }
                File.Delete("result.txt");
                File.WriteAllText("result.txt", text); // save result with function Algorithm_K_center_groups to file  to make copying possible result
            }
            else
            {
                for (var i = 0; i < 10; i++)
                {
                    foreach (Center_point center in center_points)
                    {
                        center.Remove_points();
                    }
                    var M = x1.Count;
                    for (int s = 0; s < M; s++)
                    {
                        var u = Measure_distance(center_points[0], x1[s], x2[s]);
                        var index_group = 0;

                        for (var j = 1; j < center_points.Count; j++)
                        {
                            var min = Measure_distance(center_points[j], x1[s], x2[s]);
                            if (u > min)
                            {
                                u = min;
                                index_group = j;
                            }
                        }
                        center_points[index_group].Add_point(s);
                    }
                    for (int j = 0; j < center_points.Count; j++)
                    {
                        var X_gr = center_points[j].Get_Own_points();
                        if (X_gr.Count == 0)
                        {
                            continue;
                        }
                        double x1_suma = 0;
                        double x2_suma = 0;
                        foreach (var X in X_gr)
                        {
                            x1_suma += x1[X];
                            x2_suma += x2[X];
                        }
                        center_points[j].Update_Center_point(x1_suma, x2_suma);
                    }
                    if ((i % int.Parse(result) == 0 || i == itera - 1))
                    {
                        listsDategroup.Items.Add($"Wykonany iteracji {i}");
                        var numer_groups = 1;
                        foreach (Center_point center in center_points)
                        {
                            var numer_itera_numer = 0;
                            if (i == 0)
                            {
                                numer_itera_numer = 1;
                            }
                            else if (i == 10 - 1)
                            {
                                numer_itera_numer = 10;
                            }
                            else
                            {
                                numer_itera_numer = i;
                            }
                            text += $"Numer itera:{numer_itera_numer}\n";
                            List<int> points = center.Get_Own_points();
                            listsDategroup.Items.Add($"Numer groupy: {numer_groups}");
                            if (points.Count == 0)
                            {
                                listsDategroup.Items.Add("Grupa nie zawiera punktów.");
                                numer_groups++;
                                continue;
                            }
                            var min = points[0];
                            var max = points[0];
                            for (int j = 0; j < points.Count; j++)
                            {
                                if (min > points[j])
                                {
                                    min = points[j];
                                }
                                if (max < points[j])
                                {
                                    max = points[j];
                                }
                            }
                            listsDategroup.Items.Add($"Środe wartość:\n [{center.Get_x1()},{center.Get_x2()}] \n " +
                                $"Liczba próbke:\n {points.Count}\n" +
                                $"maksymalna wartość\n x:{x1[max]},y:{x2[max]}\n minimalna wartość\n x:{x1[min]},y:{x2[min]}\n");

                            text +=
                                $"Numer grupy:{numer_groups}\n" +
                                $"Środe wartość:\n [{center.Get_x1()},{center.Get_x2()}] \n " +
                                $"Liczba próbke:\n {points.Count}\n" +
                                $"maksymalna wartość\n x:{x1[max]},y:{x2[max]}\n minimalna wartość\n x:{x1[min]},y:{x2[min]}\n";
                            numer_groups++;
                        }
                        listsDategroup.Visible = true;
                        label6.Visible = true;
                        if (checkcreateChart.Checked == true)
                        {
                            Chart chart1 = new Chart();
                            chart1.Dock = DockStyle.Fill;

                            ChartArea chartarea1 = new ChartArea("GlownyObszar");
                            chart1.ChartAreas.Add(chartarea1);

                            Series PointSeries1 = new Series("MojePunkty") { ChartType = SeriesChartType.Point };
                            chart1.Series.Add(PointSeries1);

                            PointSeries1.Points.Clear();

                            for (int k = 0; k < center_points.Count; k++)
                            {
                                int index = PointSeries1.Points.AddXY(center_points[k].Get_x1(), center_points[k].Get_x2());
                                PointSeries1.Points[index].Color = Color.Red;
                                var own_point = center_points[k].Get_Own_points();
                                for (int j = 0; j < own_point.Count; j++)
                                {
                                    int index1 = PointSeries1.Points.AddXY(x1[own_point[j]], x2[own_point[j]]);
                                    PointSeries1.Points[index1].Color = center_points[k].SeriesColor;
                                }
                            }

                            Form oknoWykresu = new Form();
                            if (i == 0)
                            {
                                oknoWykresu.Text = $"Wykres po iteracji 1";
                            }
                            else if (i == 10 - 1)
                            {
                                oknoWykresu.Text = $"Wykres po iteracji {10}";
                            }
                            else
                            {
                                oknoWykresu.Text = $"Wykres po iteracji {i}";
                            }
                            oknoWykresu.Width = 800;
                            oknoWykresu.Height = 600;
                            oknoWykresu.Controls.Add(chart1);
                            oknoWykresu.ShowDialog();
                        }
                    }
                }
                File.Delete("result.txt");
                File.WriteAllText("result.txt", text); // save result with function Algorithm_K_center_groups to file  to make copying possible result
            }
        }

        private void List_Divergence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List_Divergence.Text ==  "Minkowskiego")
            {
                Count_mink.Visible = true;
                label4.Visible = true;
            }
            else
            {
                Count_mink.Visible = false;
                label4.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numeric_iter_ValueChanged(object sender, EventArgs e)
        {
            ResualGroupsitera.Maximum = (int)numeric_iter.Value;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
    public class Foo
    {
        [Index(0)]
        public string x { get; set; }
        [Index(1)]
        public string y { get; set; }
    }
    public class Center_point { 
        private double x1 { get; set; }
        private double x2 { get; set; }
        private List<int> Own_points { get; set; } = new List<int>();
        public System.Drawing.Color SeriesColor;
        public Center_point(double x1,double x2,int R,int G,int B)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.SeriesColor = System.Drawing.Color.FromArgb(R, G, B);

        }
        public double Get_x1()
        {
            return x1;
        }
        public double Get_x2() {
            return x2;
        }
        public void Add_point(int index)
        {
            Own_points.Add(index);
        }
        public List<int> Get_Own_points()
        {
            return Own_points;
        }
        public void Update_Center_point(double x1,double x2)
        {
            this.x1 = x1/ Own_points.Count;
            this.x2 = x2 / Own_points.Count;
        }
        public void Remove_points() {
            Own_points.Clear();
        }
    }
}
