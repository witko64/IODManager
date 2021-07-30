using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IODManager
{
    /// <summary>
    /// Logika interakcji dla klasy frmKomorkiOrg.xaml
    /// </summary>
    ///
    public partial class frmKomorkiOrg : Window
    {
        private ObservableCollection<KomorkaOrg> listaKomorek = null;

        private void PrzygotujWiazanie()
        {
            listaKomorek = new ObservableCollection<KomorkaOrg>();
            // uruchomic SQL Reader
            // zaktualizaować elementy listaKomorek na podstawie SQL Readera
        }
        public frmKomorkiOrg()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void lstKomorkiOrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtFilter_TextChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
