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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace ChemistrySimulator
{
    /// <summary>
    /// GraphWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GraphWindow : Window
    {
        public GraphWindow(Beaker beaker)
        {
            InitializeComponent();

            // How to update those observable values?
            var ion_H = new ObservableValue(0);
            var ion_Cl = new ObservableValue(0);
            var ion_K = new ObservableValue(0);
            var ion_Na = new ObservableValue(0);
            var ion_OH = new ObservableValue(0);

            SeriesCollection = new SeriesCollection
            {
                // Need to figure out how to update chemicals' values..
                 new LineSeries
                 {
                     Title = "H+",
                     Values = new ChartValues<ObservableValue> { ion_H },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="Cl-",
                     Values = new ChartValues<ObservableValue> { ion_Cl },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="K+",
                     Values = new ChartValues<ObservableValue> { ion_K },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="Na+",
                     Values = new ChartValues<ObservableValue> { ion_Na },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="OH-",
                     Values = new ChartValues<ObservableValue> { ion_OH },
                     LineSmoothness = 0
                 }
            };

            // Notice. this should observe order as describled in 'chemical notation'
            Labels = new[] { "H+", "Cl-", "K+", "Na+", "OH-" };
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

    }
}
