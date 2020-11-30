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

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for BaoCaoUC.xaml
    /// </summary>
    public partial class BaoCaoUC : UserControl
    {
        public BaoCaoUC()
        {
            InitializeComponent();
        }

		private void Button_xuat_Click(object sender, RoutedEventArgs e)
		{
            try
            {

                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(pnlpnl, "Báo Cáo");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }

        }

        private void ComboBox_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{

		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
