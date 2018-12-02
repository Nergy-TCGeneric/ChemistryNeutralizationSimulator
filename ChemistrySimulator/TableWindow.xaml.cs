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
    /// TableWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TableWindow : Window
    {
        private static TableWindow instance = null;
        private int experimentCount;

        public static TableWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableWindow(MainWindow.Instance.getBeakerInstance());
                return instance;
            }
        }

        public TableWindow(Beaker beaker)
        {
            instance = this;
            Closed += closeEvent;
            InitializeComponent();
        }

        // Follow the order describled at 'ChemicalNotation' class.
        public void createTableCell(float[] ionAmount)
        {
            experimentCount++;
            ChemistryTable.Rows.Add(new TableRow());
            TableRow currentRow = ChemistryTable.Rows[ChemistryTable.Rows.Count - 1];

            // TODO: For readability, different background color for experimentCount rows are required.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(experimentCount.ToString()))));
            for(int i=0;i<ionAmount.Length;i++) {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ionAmount[i].ToString() + "N"))));
            }
        }

        private void closeEvent(object sender, EventArgs e) {
            instance = null;
        }
    }
}
