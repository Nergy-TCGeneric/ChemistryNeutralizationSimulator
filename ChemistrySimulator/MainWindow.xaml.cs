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

namespace ChemistrySimulator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class MainWindow : Window
    {
        // For testing purpose. Using default instance instead
        Beaker defaultBeaker = new Beaker();

        public MainWindow()
        {
            InitializeComponent();
        }

        void renewBeakerStatus()
        {
            BeakerStatus.Content = defaultBeaker.getTotalBeakerVolume().ToString() + " mL";
        }

        // For testing purpose, 10 mL will be added. must take user's input through any possible methods

        void Beaker_MouseEnterEvent(object sender, MouseEventArgs e)
        {
            BeakerStatus.Content = "";
            for(int i=0;i<6;i++)
            {
                BeakerStatus.Content += defaultBeaker.getComponentVolume(i).ToString() + " ";
            }
        }

        void Beaker_MouseLeaveEvent(object sender, MouseEventArgs e)
        {
            renewBeakerStatus();
        }

        void HClBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            defaultBeaker.addBeakerComponent(ChemNotation.ion_H, 10);
            defaultBeaker.addBeakerComponent(ChemNotation.ion_Cl, 10);
            renewBeakerStatus();
        }

        void NaOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            defaultBeaker.addBeakerComponent(ChemNotation.ion_Na, 10);
            defaultBeaker.addBeakerComponent(ChemNotation.ion_OH, 10);
            renewBeakerStatus();
        }

        void KOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e )
        {
            defaultBeaker.addBeakerComponent(ChemNotation.ion_K, 10);
            defaultBeaker.addBeakerComponent(ChemNotation.ion_OH, 10);
            renewBeakerStatus();
        }
    }
}
