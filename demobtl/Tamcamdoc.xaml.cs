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
using System.Xml.Linq;

namespace demobtl
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    /// <summary>
    /// Interaction logic for Tamcamdoc.xaml
    /// </summary>
    public partial class Tamcamdoc : Window
    {
        string ConnectionString = "";
        //Biến Connection để kết nối CSDL
        SqlConnection Conn = new SqlConnection();
        //Biến chưa dữ liệu bảng hiện thời đang hiển thị trên Grid
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;

        List<string> listName;
        public Tamcamdoc()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Mở kết nối đến CSDL
            // Cấu trúc xâu kết nối:
            // Data Source=<đường dẫn máy chủ SQL>; nếu là máy hiện hành có thể đại diện bằng dấu chấm (.). 
            // nếu có instance name thì thêm tên sau dấu chấm cách bởi \.
            // VD: .\MSSQLSERVER
            // Initial Catalog=<tên cơ sở dữ liệu>;
            // VD: Initial Catalog=BanHangdb; tên CSDL là BanHangdb
            listName = new List<string>() { "chương 1", "chương 2" };
            chapterCombo.ItemsSource = listName;
            try
            {
                //Mở kết nối    
                ConnectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                //if (Conn.State == ConnectionState.Open)
                //    MessageBox.Show("Mở kết nối thành công.");
                //else
                //    MessageBox.Show("Lỗi khi mở kết nối");

                //Nạp dữ liệu hiện có của bảng Phân loại hàng hóa
                //lên DataGrid

                NapDuLieuTuMayChu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối");
            }

        }

        private void NapDuLieuTuMayChu()
        {
            if (Conn.State != ConnectionState.Open) return;

            string SqlStr = "Select * from tamcam";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataSource = dataSet.Tables[0];
        }


        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ban co chac la muon thoat khoi chuong trinh nay hay khong?",
                            "Xac nhan dung chuong trinh",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                this.Close();
            }
        }

        private void chapterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btSangBinhLuan_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new comment();
            newWindow.ShowDialog();

            // Close this window
            Close();
        }

        private void btBatDau_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
