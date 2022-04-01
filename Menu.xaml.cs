
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
using Demo334.DataBase;
using Demo334.Pages;

namespace Demo334
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            Connect.conn = new MaterialsShop();
            FrameWind.frmMain = FrmMain;
            FrmMain.NavigationService.Navigate(new Pages.PageInfo());


            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameWind.frmMain.Navigate(new Menu());
        }
    } 
}
