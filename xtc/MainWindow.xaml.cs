using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using Microsoft.Research.DynamicDataDisplay.Charts;

namespace xtc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int curvecount = 0;

        List<Point> Spoint;
        List<Point> edgepoint;

        Point FD; //наихудшая вершина
        Point FG; //наилудшая вершина

        List<double> Fj; //список значений функции в точках N

        void DrawGraph(List<Point> p)
        {
            double[] x = new double[p.Count];
            double[] y = new double[p.Count];

            for (int i = 0; i < p.Count; i++)
            {
                x[i] = p[i].x;
                y[i] = p[i].y;
            }

            // Create data sources:
            var xDataSource = x.AsXDataSource();
            var yDataSource = y.AsYDataSource();

            CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            // adding graph to plotter
            plotter.AddLineGraph(compositeDataSource,
                Colors.Goldenrod,
                3,
                "Sine");

            // Force evertyhing plotted to be visible
            plotter.FitToView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Spoint = new List<Point>();
            edgepoint = new List<Point>();

            double x, y, g1 = 0, h1 = 15, g2 = 0, h2 = 8, r1, r2;
            Random rand = new Random();
            bool isrightpoint = false;

            for (int i = 0; i < 4; i++)
            {
                r1 = rand.NextDouble();
                r2 = rand.NextDouble();

                x = g1 + r1 * (h1 - g1);
                y = g2 + r2 * (h2 - g2);

                if (x + y > 12)
                {
                    isrightpoint = true;
                }
                else
                    isrightpoint = false;

                Spoint.Add(new Point(x, y, isrightpoint));

            }

            for (int i = 0; i < 4; i++)
            {
                while (!Spoint[i].right)
                {
                    r1 = rand.NextDouble();
                    r2 = rand.NextDouble();
                    x = g1 + r1 * (h1 - g1);
                    y = g2 + r2 * (h2 - g2);
                    if (x + y > 12)
                    {
                        isrightpoint = true;
                        Spoint[i].right = true;
                    }
                    else
                        isrightpoint = false;

                    Spoint[i].x = x;
                    Spoint[i].y = y;

                }
            }

            for (int i = 0; i < 15; i++)
                edgepoint.Add(new Point(i, 12 - i, true));

            DrawGraph(edgepoint);
        }


    }
}
