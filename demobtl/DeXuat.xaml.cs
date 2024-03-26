using dexuatsach;
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

namespace demobtl
{
    /// <summary>
    /// Interaction logic for DeXuat.xaml
    /// </summary>
    public partial class DeXuat : Window
    {
        public DeXuat()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }

        private List<listbook> GetProducts()
        {
            return new List<listbook>()
                {
                new listbook("Sách 1", "s1.jpg"),
                new listbook("Sách 2", "s2.jpg"),
                new listbook("Sách 3", "s4.jpg"),
                new listbook("Sách 4", "s5.jpg"),
                new listbook("Sách 5", "s3.jpg"),
                new listbook("Sách 6", "s6.jpg"),
                new listbook("Sách 7", "s7.jpg")
              };
        }
    }
}
