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
using System.Windows.Threading;
using Demo334.DataBase;
using Demo334.Pages;

namespace Demo334.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddMaterial.xaml
    /// </summary>
    public partial class PageAddMaterial : Page
    {
        public PageAddMaterial()
        {
            InitializeComponent();
            CmbMat.SelectedValuePath = "ID";
            CmbMat.DisplayMemberPath = "Title";
            CmbMat.ItemsSource = Connect.conn.MaterialType.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Material material = new Material()
                {
                    Title = TxbTitle.Text,
                    Cost = Convert.ToDecimal(TxbCount.Text),
                    MinCount = Convert.ToDouble(TxbMinColl.Text),
                    CountInPack = Convert.ToInt32(TxbCountInPack.Text),
                    CountInStock = Convert.ToDouble(TxbInYpacobka.Text),
                    Unit = TxbUnit.Text,
                    Description = TxbComment.Text,
                    Image = TxbImg.Text,
                    MaterialTypeID = (int)CmbMat.SelectedValue,
            };
                Connect.conn.Material.Add(material);
                Connect.conn.SaveChanges();
                MessageBox.Show("22");
                }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }

        } 
    }
}
