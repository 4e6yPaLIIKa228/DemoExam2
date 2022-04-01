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
using Demo334.DataBase;
using Demo334.Pages;

namespace Demo334.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageInfo.xaml
    /// </summary>
    public partial class PageInfo : Page
    {
        public PageInfo()
        {
            InitializeComponent();

        }

        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            FrameWind.frmMain.Navigate(new Pages.PageInfoMaterial());
        }
    }
}
