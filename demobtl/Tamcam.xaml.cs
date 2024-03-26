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
using System.Windows.Shapes;

namespace demobtl
{
    /// <summary>
    /// Interaction logic for Tamcam.xaml
    /// </summary>
    public partial class Tamcam : Window
    {
        string ConnectionString = "";
        //Biến Connection để kết nối CSDL
        SqlConnection Conn = new SqlConnection();
        //Biến chưa dữ liệu bảng hiện thời đang hiển thị trên Grid
        DataTable DataSource = null;
        //DataTable DataSource;
        long SelectedID = 0;
        bool isNew = false;
        public Tamcam()
        {
            InitializeComponent();
        }

        private void Window2_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                //Mở kết nối
                ConnectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();

                dgBook.ItemsSource = null;
                if (Conn.State != ConnectionState.Open) return;

                string SqlStr = "Select top 1 * from book";
                SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                DataSource = dataSet.Tables[0];

                dgBook.ItemsSource = DataSource.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối");
            }

        }





        private void btBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            danhgia danhgia = new danhgia();
            danhgia.ShowDialog();
        }

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void btDG_Click(object sender, RoutedEventArgs e)
        {
           /* SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-O3MFBSE;Initial Catalog=DocSach;Integrated Security=True");
            try
            {
                conn.Open();
                string sql = "Select * from book order by book_id offset 1 rows fetch next 1 rows only";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    Window7 window = new Window7();
                    window.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
*/
        }

    }
}
