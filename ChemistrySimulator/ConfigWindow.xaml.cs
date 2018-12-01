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

namespace ChemistrySimulator
{
    /// <summary>
    /// ConfigWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private Window instance;
		private Beaker currentBeaker;

        public ConfigWindow(Window instance, Beaker beaker)
        {
            InitializeComponent();
            this.instance = instance;

			Loaded += ConfigWindowLoadedEvent;
            Closing += ConfigWindowClosedEvent;
			currentBeaker = beaker;
        }

		public void ConfigWindowLoadedEvent(object sender, EventArgs e)
		{
			int[] defaultConcentration = currentBeaker.getConcentrationRatio();
			int defaultMaxVolume = currentBeaker.getMaxVolume();

			// Can be abbreviated. use array to optimize those:
			HClConcentrate.Text = defaultConcentration[0].ToString();
			NaOHConcentrate.Text = defaultConcentration[1].ToString();
			KOHConcentrate.Text = defaultConcentration[2].ToString();
			maxBeakerVolume.Text = defaultMaxVolume.ToString();
		}

        public void ConfigWindowClosedEvent(object sender, EventArgs e)
        {
            instance.Show();
        }

		public void onOKBtnClickEvent(object sender, EventArgs e)
		{
			if (!(HClConcentrate.Text.Contains("-") ||
				NaOHConcentrate.Text.Contains("-") ||
				KOHConcentrate.Text.Contains("-")) ||
				standardVolume.Text.Contains("-") ||
				maxBeakerVolume.Text.Contains("-"))
			{
				try
				{
					currentBeaker.setConcentrationRatio(new int[3]
						{
							Convert.ToInt32(HClConcentrate.Text),
							Convert.ToInt32(NaOHConcentrate.Text),
							Convert.ToInt32(KOHConcentrate.Text)
						});

					currentBeaker.setStandardVolume(Convert.ToInt32(standardVolume.Text));
					currentBeaker.setMaxVolume(Convert.ToInt32(maxBeakerVolume.Text));
				}
				catch (FormatException)
				{
					MessageBox.Show("There's an invaild number somewhere. please check it out.", "Oops!");
				}
				catch (OverflowException)
				{
					MessageBox.Show("One of given number is too big. please check it out.", "Oops!");
				}
			}
			else
			{
				MessageBox.Show("Every number should be greater than 0.", "Oops!");
			}

			Close();
		}
    }
}
