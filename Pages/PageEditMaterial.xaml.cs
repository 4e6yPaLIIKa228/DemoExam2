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
    /// Логика взаимодействия для PageEditMaterial.xaml
    /// </summary>
    public partial class PageEditMaterial : Page
    {
        public PageEditMaterial(Material material)
        {
            InitializeComponent();
            CmbMat.SelectedIndex = material.MaterialTypeID - 5;
            CmbMat.SelectedValuePath = "ID";
            CmbMat.DisplayMemberPath = "Title";
            CmbMat.ItemsSource = Connect.conn.MaterialType.ToList();

            MaterialObject.ID = material.ID;
            TxbTitle.Text = material.Title;
            //CmbMat.Text = Convert.ToString(material.MaterialType);
            TxbImg.Text = Convert.ToString(material.Image);
            TxbCount.Text = Convert.ToString(material.Cost);
            TxbMinColl.Text = Convert.ToString(material.MinCount);
            TxbCountInPack.Text = Convert.ToString(material.CountInPack);
            TxbInYpacobka.Text = Convert.ToString(material.CountInStock);
            TxbUnit.Text = Convert.ToString(material.Unit);
            TxbComment.Text = Convert.ToString(material.Description);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
                IEnumerable<Material> materials = Connect.conn.Material.Where(x => x.ID == MaterialObject.ID).AsEnumerable().
                    Select(x =>
                    {     
                        bool resultTitl = int.TryParse(CmbMat.SelectedValue.ToString(), out int id4);
                        x.Title = TxbTitle.Text;
                        x.Cost = Convert.ToDecimal(TxbCount.Text);
                        x.MinCount = Convert.ToDouble(TxbMinColl.Text);
                        x.CountInPack = Convert.ToInt32(TxbCountInPack.Text);
                        x.CountInStock = Convert.ToDouble(TxbInYpacobka.Text);
                        x.Unit = TxbUnit.Text;
                        x.Description = TxbComment.Text;
                        x.Image = TxbImg.Text;
                        x.MaterialTypeID = (int)CmbMat.SelectedValue;
                        return x;
                    });
                foreach (Material mat in materials)
                {
                    Connect.conn.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                }
                Connect.conn.SaveChanges();
                MessageBox.Show("Данные сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.udateinfo = 1;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
