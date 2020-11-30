using System.Windows.Controls;

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for QuanLyHoaDonUC.xaml
    /// </summary>
    public partial class QuanLyHoaDonUC : UserControl
    {
        public QuanLyHoaDonUC()
        {
            InitializeComponent();
        }

        private void InHoaDon_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
			
				this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(pnlCTHD, "Hóa đơn");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }

        }
    }
}