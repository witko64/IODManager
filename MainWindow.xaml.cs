using System.Windows;


namespace IODManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Logout(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Koniec pracy, do widzenia");
            this.Close();
        }

        private void MenuItem_Pomoc(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Przycisk Pomoc");
        }

        private void MenuItem_FrmDaneADO(object sender, RoutedEventArgs e)
        {
            Window window = new FrmDaneADO();
            window.ShowDialog();
        }
        private void MenuItem_FrmKomórkiOrg(object sender, RoutedEventArgs e)
        {
            Window frmKomOrg = new frmKomorkiOrg();
            frmKomOrg.ShowDialog();
        }

    }
}
