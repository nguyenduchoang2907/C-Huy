using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ConnectionString = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                conn.ConnectionString = ConnectionString;
                conn.Open();
                if (demo_tb.Text != "no_admin"){
                    QLND.Visibility = Visibility.Visible;
                    dangsach.Visibility = Visibility.Visible;
                }
                else{
                    QLND.Visibility = Visibility.Hidden;
                    dangsach.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void diendan_Click(object sender, RoutedEventArgs e)
        {
            theloai theloai = new theloai();
            
            this.Close();
            theloai.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            User user= new User();
            user.ShowDialog();
        }

        private void dangsach_Click(object sender, RoutedEventArgs e)
        {
            dangsach dang = new dangsach();
            
            this.Close();
            dang.ShowDialog();
        }

        private void timkiem_Click(object sender, RoutedEventArgs e)
        {
            Form_Search search=new Form_Search();
            
            this.Close();
            search.ShowDialog();
        }

      
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tamcam tamcam = new Tamcam();   
            tamcam.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form_Search fr=new Form_Search();
            fr.tb_cref.Text = tb_search.Text;
            fr.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {   
            nguoidung nd=new nguoidung();
            conn.Close();
            this.Close();
            nd.ShowDialog();
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Login login=new Login();
            conn.Close();
            this.Close();
            login.ShowDialog();
        }

        private void demo_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
