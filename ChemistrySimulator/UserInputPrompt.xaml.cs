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
    /// UserInputPrompt.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserInputPrompt : Window
    {
        public UserInputPrompt(string defaultQuestion, int defaultAnswer = 0)
        {
            InitializeComponent();
            question.Content = defaultQuestion;
            userInput.Text = defaultAnswer.ToString();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            userInput.SelectAll();
            userInput.Focus();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            float p = 0;
            if (float.TryParse(userInput.Text, out p))
                if(p > 0)
                    this.DialogResult = true;
                else
                    MessageBox.Show("Number should be greater than 0.", "Oops!");
            else
                MessageBox.Show("You must enter number, not strings.", "Oops!");
        }

        public string userInputText
        {
            get { return userInput.Text; }
        }

    }
}
