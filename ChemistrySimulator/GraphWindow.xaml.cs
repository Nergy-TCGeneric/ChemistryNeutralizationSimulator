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
        private static GraphWindow instance = null;

        public static GraphWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new GraphWindow(MainWindow.Instance.getBeakerInstance());
                return instance;
            }
        }

        public GraphWindow(Beaker beaker)
        {
            instance = this;
            Closed += closeEvent;

            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                 new LineSeries
                 {
                     Title = "H+",
                     Values = new ChartValues<ObservableValue> { },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="Cl-",
                     Values = new ChartValues<ObservableValue> { },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="K+",
                     Values = new ChartValues<ObservableValue> { },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="Na+",
                     Values = new ChartValues<ObservableValue> { },
                     LineSmoothness = 0
                 },

                 new LineSeries
                 {
                     Title="OH-",
                     Values = new ChartValues<ObservableValue> { },
                     LineSmoothness = 0
                 }
            };

            // Notice. this should observe order as describled in 'chemical notation'
            Labels = new[] { "H+", "Cl-", "K+", "Na+", "OH-" };
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

        public void AddValue(int ChemNotation, float Value) {
            SeriesCollection[ChemNotation].Values.Add(new ObservableValue(Value));
        }

        private void closeEvent(object sender, EventArgs e) {
            instance = null;
        }
    }
}
