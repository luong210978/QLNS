using System.Windows.Controls;

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for QuanLyNhapSachUC.xaml
    /// </summary>
    public partial class QuanLyNhapSachUC : UserControl
    {
        public QuanLyNhapSachUC()
        {
            InitializeComponent();
        }

		private void btnNhapKho_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            try
            {

                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(pnllnhapssach, "Nhập Sách");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

		private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            try
            {

                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(pnlchitiet, "Nhập Sách");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
	}
}