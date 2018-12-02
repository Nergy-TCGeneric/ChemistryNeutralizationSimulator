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

        private static MainWindow instance = null;

        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindow();
                return instance;
            }
        }

        public MainWindow()
        {
            instance = this;
            Closed += windowCloseEvent;
            InitializeComponent();
        }

        public Beaker getBeakerInstance() {
            return defaultBeaker;
        }

        // TODO: Text wraping required
        private void renewBeakerStatus() {
            BeakerStatus.Content = defaultBeaker.getTotalBeakerVolume().ToString() + " mL";
        }

        private void linkToGraph() {
            for (int i = 0; i < 5; i++)
                GraphWindow.Instance.AddValue(i, defaultBeaker.getComponentVolume(i));
        }

        private void linkToTable() {
            TableWindow.Instance.createTableCell(new float[5] { defaultBeaker.getComponentVolume(ChemNotation.ion_Cl),
                                                                defaultBeaker.getComponentVolume(ChemNotation.ion_Na),
                                                                defaultBeaker.getComponentVolume(ChemNotation.ion_K),
                                                                defaultBeaker.getComponentVolume(ChemNotation.H2O),
                                                                defaultBeaker.getTotalBeakerVolume() });
        }

        private void Beaker_MouseEnterEvent(object sender, MouseEventArgs e)
        {
            BeakerStatus.Content = "";
            for(int i=0;i<6;i++)
                BeakerStatus.Content += defaultBeaker.getComponentVolume(i).ToString() + " ";
        }

        private void Beaker_MouseLeaveEvent(object sender, MouseEventArgs e)
        {
            renewBeakerStatus();
        }

        private void HClBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            UserInputPrompt prompt = new UserInputPrompt("How Much?");

			try
			{
				// Every passed value(propmpt.userInputText) is proved convertible & positive
				if (prompt.ShowDialog() == true) {
					defaultBeaker.addBeakerComponent(ChemNotation.ion_Cl, Convert.ToSingle(prompt.userInputText));
				}
			}
			catch (OverflowException)
			{
				MessageBox.Show("Number is too big!", "Oops!");
			}

            renewBeakerStatus();
            defaultBeaker.neutralize(defaultBeaker);
        }

        private void NaOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            UserInputPrompt prompt = new UserInputPrompt("How much?");

			try
			{
				if (prompt.ShowDialog() == true) {
					defaultBeaker.addBeakerComponent(ChemNotation.ion_Na, Convert.ToSingle(prompt.userInputText));
				}
			}

			catch (OverflowException)
			{
				MessageBox.Show("Number is too big!", "Oops!");
			}

            renewBeakerStatus();
            defaultBeaker.neutralize(defaultBeaker);
        }

        private void KOHBeaker_LeftMouseDownEvent(object sender, MouseButtonEventArgs e )
        {
            UserInputPrompt prompt = new UserInputPrompt("How much?");

			try
			{
				if (prompt.ShowDialog() == true) {
					defaultBeaker.addBeakerComponent(ChemNotation.ion_K, Convert.ToSingle(prompt.userInputText));
				}
			}
			catch (OverflowException)
			{
				MessageBox.Show("Number is too big!", "Oops!");
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

        private void verifiedButtonClickEvent(object sender, EventArgs e)
        {
            linkToGraph();
            linkToTable();
            GraphWindow.Instance.Show();
            TableWindow.Instance.Show();
        }

        private void clearButtonClickEvent(object sender, EventArgs e)
        {
            defaultBeaker.resetBeaker();
            renewBeakerStatus();
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

        // Use singleton to prevent unnecessary memory use
        private void graphButtonClickEvent(object sender, EventArgs e)
        {
            GraphWindow.Instance.Show();
        }
        
        private void tableButtonClickEvent(object sender, EventArgs e)
        {
            TableWindow.Instance.Show();
        }

        private void configButtonClickEvent(object sender, EventArgs e)
        {
            ConfigWindow config = new ConfigWindow(this, defaultBeaker);
            config.Show();
            this.Hide();
        }

        private void helpButtonClickEvent(object sender, EventArgs e)
        {
            helpWindow help = new helpWindow();
            help.Show();
        }

        private void windowCloseEvent(object sender, EventArgs e) {
            instance = null;
        }
    }
}
