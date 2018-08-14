using LiveCharts;
using LiveCharts.Wpf;
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

namespace ERP.Control
{
    /// <summary>
    /// Interaction logic for NCRGraph.xaml
    /// </summary>
    public partial class NCRGraph : UserControl
    {
        public NCRGraph()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Internal",
                    Fill = internalColor,
                    Values = new ChartValues<int> { 10, 50, 39, 50, 67, 99, 80, 12, 3, 29, 100, 17 }
                },
                new ColumnSeries
                {
                    Title = "Extenal",
                    Fill= externalColor,
                    Values = new ChartValues<int> { 17, 100, 29,3,12,80,99,67,50,39,50,10 }
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

        private SolidColorBrush internalColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fec007"));
        private SolidColorBrush externalColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f34336"));
    }
}
