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
    /// Логика взаимодействия для PageInfoMaterial.xaml
    /// </summary>
    public partial class PageInfoMaterial : Page
    {
        MaterialsShop db = new MaterialsShop();
        int no = 1;
        public PageInfoMaterial()
        {
            InitializeComponent();
            UpdateData();

            Load();
            Update();

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += UpdateData;
            //timer.Start();
        }

        void Load()
        {
            List<Material> list = new List<Material>();
            List<Material> nList = new List<Material>();

            int k = no;
            list = Connect.conn.Material.ToList();
            nList = new List<Material>(list.GetRange(k * 16 - 15, 15));
            mat.ItemsSource = nList;

            
            //list = db.Material.Where(c => c.MaterialTypeID == mt.ID).ToList();
            //nList = new List<Material>(list.GetRange(k * 15 - 14, 15));
            //if (nList.Count > k * 15 - 14) mat.ItemsSource = nList;
            //else mat.ItemsSource = list.GetRange(k * 15 - 14, nList.Count);

        }

        void Update()
        {
            if (Connect.udateinfo == 1)
            {
                Load();
            }
        }
        private void Bwd(object sender, MouseButtonEventArgs e)
        {
            if (no == 1) return;
            no--;
            if (mat.ItemsSource is null) return;
            Load();
        }

        private void SelPg(object sender, MouseButtonEventArgs e)
        {
            TextBlock snd = sender as TextBlock;
            if (no != Convert.ToInt32(snd.Text)) no = Convert.ToInt32(snd.Text);
            else return;
            Load();
        }

        //void CheckImg(object sender, MouseEventArgs e)
        //{
        //    foreach (var sp in mat.Items.OfType<StackPanel>())
        //    {
        //        foreach (var img in sp.Children.OfType<Image>())
        //        {
        //            for (int i = 0; i < 26; i++)
        //            {
        //                num = i;
        //                fullpath = fld + fName + num.ToString() + ext;
        //                gf.UriSource = new Uri(fullpath);
        //                MessageBox.Show(fullpath);
        //                if (img.Source != gf) img.Source = new BitmapImage(new Uri("\\materials\\picture.png"));
        //            }
        //        }
        //    }
        //}

        void Fwd(object sender, MouseEventArgs m)
        {
            no++;
            if (mat.ItemsSource is null) return;
            Load();
        }

        private void Selector(object sender, SelectionChangedEventArgs e)
        {

            Load();

        }



        public void UpdateData()
        {
            //var AllMaterials = Connect.conn.Material.ToList();
            //mat.ItemsSource = AllMaterials;
            //mat.ItemsSource = Connect.conn.Material.Where(x => x.Title.StartsWith(teBox.Text) || x.Description.StartsWith(teBox.Text)).ToList();
        }

        private void teBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            mat.ItemsSource = db.Material.Where(x => x.Title.StartsWith(teBox.Text) || x.Description.StartsWith(teBox.Text)).ToList();
        }

        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {
            FrameWind.frmMain.Navigate(new PageEditMaterial((sender as Button).DataContext as Material));
            Load();
        }

        private void BtDell_Click(object sender, RoutedEventArgs e)
        {
           
            int Inv = ((Material)((Control)sender).DataContext).ID;
            var DelSub = db.Material.Where(m => m.ID == Inv).Single();
            db.Material.Remove(DelSub);
            db.SaveChanges();
            Load();
            
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameWind.frmMain.Navigate(new PageAddMaterial());
            Load();
        }
    }
}
 