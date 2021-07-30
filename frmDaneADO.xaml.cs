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

namespace IODManager
{
    /// <summary>
    /// Logika interakcji dla klasy DaneADO.xaml
    /// </summary>
    public partial class FrmDaneADO : Window
    {
        private MainWindow mainWindow = null;
        private ADO adm = null;

        public FrmDaneADO() //konstruktor
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        public FrmDaneADO(MainWindow mainWin) //przeciążony konstrutor
        {
            InitializeComponent();
            mainWindow = mainWin;
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            adm = new ADO("", "", "", "", "","","","","");
            adm.GetADOData(1);
            frmDaneADO.DataContext = adm;
        }

  
        //  Roważyć przeniesienie validacji danych ADO.CS
       
        private void btnClick_Save_Data(object sender, RoutedEventArgs e)
        {
            if (adm.ValidateData() == true) 
            {
                if (adm.IsNew)
                {
                    adm.AddADOData();
                }
                else
                {
                    adm.UpdateADOData(1);
                }
                frmDaneADO.Close();
            }
            else
            {
                MessageBox.Show("Bład w danych");
            }
            
        }
    }
}
