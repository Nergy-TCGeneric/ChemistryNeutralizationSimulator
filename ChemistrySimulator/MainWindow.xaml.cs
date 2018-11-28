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
using System.Windows.Media.Animation;

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

        // TODO: Text wraping required
        void renewBeakerStatus() {
            BeakerStatus.Content = defaultBeaker.getTotalBeakerVolume().ToString() + " mL";
        }

        void Beaker_MouseEnterEvent(object sender, MouseEventArgs e)
        {
            BeakerStatus.Content = "";
            for(int i=0;i<6;i++)
                BeakerStatus.Content += defaultBeaker.getComponentVolume(i).ToString() + " ";
        }

        void Beaker_MouseLeaveEvent(object sender, MouseEventArgs e)
        {
            renewBeakerStatus();
        }

        void HClBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            UserInputPrompt prompt = new UserInputPrompt("How Much?");

            // Every passed value(propmpt.userInputText) is proved convertible & positive
            if (prompt.ShowDialog() == true) {
                defaultBeaker.addBeakerComponent(ChemNotation.ion_H, Convert.ToSingle(prompt.userInputText));
                defaultBeaker.addBeakerComponent(ChemNotation.ion_Cl, Convert.ToSingle(prompt.userInputText));
            }
            renewBeakerStatus();
            defaultBeaker.neutralize(defaultBeaker);
        }

        void NaOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            UserInputPrompt prompt = new UserInputPrompt("How much?");

            if(prompt.ShowDialog() == true) {
                defaultBeaker.addBeakerComponent(ChemNotation.ion_Na, Convert.ToSingle(prompt.userInputText));
                defaultBeaker.addBeakerComponent(ChemNotation.ion_OH, Convert.ToSingle(prompt.userInputText));
            }
            renewBeakerStatus();
            defaultBeaker.neutralize(defaultBeaker);
        }

        void KOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e )
        {
            UserInputPrompt prompt = new UserInputPrompt("How much?");

            if(prompt.ShowDialog() == true) {
                defaultBeaker.addBeakerComponent(ChemNotation.ion_K, Convert.ToSingle(prompt.userInputText));
                defaultBeaker.addBeakerComponent(ChemNotation.ion_OH, Convert.ToSingle(prompt.userInputText));
            }
            renewBeakerStatus();
            defaultBeaker.neutralize(defaultBeaker);
        }

        private void showButtonClickEvent(object sender, EventArgs e)
        {
            showHideMenu("showSlidemenu", hideButton, showButton, slidemenu);
        }

        private void hideButtonClickEvent(object sender, EventArgs e)
        {
            showHideMenu("hideSlidemenu", hideButton, showButton, slidemenu);
        }

        private void showHideMenu(string storyboard, Button hideBtn, Button showBtn, StackPanel pnl)
        {
            Storyboard sb = Resources[storyboard] as Storyboard;
            sb.Begin(pnl);
            
            if(storyboard.Contains("show"))
            {
                hideBtn.Visibility = Visibility.Visible;
                showBtn.Visibility = Visibility.Hidden;
            }
            else if(storyboard.Contains("hide"))
            {
                hideBtn.Visibility = Visibility.Hidden;
                showBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
