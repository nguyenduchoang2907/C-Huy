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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        string ConnectionString = "";
        //Biến Connection để kết nối CSDL
        SqlConnection Conn = new SqlConnection();
        //Biến chưa dữ liệu bảng hiện thời đang hiển thị trên Grid
        DataTable DataSource = null;
        public User()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Mở kết nối
                ConnectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối");
            }
            id.Text = ID_login.id_login.ToString();
            usename.Text = lay_username();
            hoten.Text = layhoten();
            email.Text = lay_email();
            phone.Text = lay_phone();

        }

        private string layhoten()
        {
            string hovaten;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            string tblStr1 = "select name from userss where login_id=@login_id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = tblStr1;
            var id = cmd.Parameters.AddWithValue("login_id", ID_login.id_login.ToString());
            hovaten = Convert.ToString(cmd.ExecuteScalar());
            Conn.Close();
            return hovaten;
        }
        private string lay_username()
        {
            string hovaten;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            string tblStr1 = "select username from dangnhap where login_id=@login_id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = tblStr1;
            var id = cmd.Parameters.AddWithValue("login_id", ID_login.id_login.ToString());
            hovaten = Convert.ToString(cmd.ExecuteScalar());
            Conn.Close();
            return hovaten;
        }
        private string lay_email()
        {
            string hovaten;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            string tblStr1 = "select email from userss where login_id=@login_id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = tblStr1;
            var id = cmd.Parameters.AddWithValue("login_id", ID_login.id_login.ToString());
            hovaten = Convert.ToString(cmd.ExecuteScalar());
            Conn.Close();
            return hovaten;
        }
        private string lay_phone()
        {
            string hovaten;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            string tblStr1 = "select phonenumber from userss where login_id=@login_id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = tblStr1;
            var id = cmd.Parameters.AddWithValue("login_id", ID_login.id_login.ToString());
            hovaten = Convert.ToString(cmd.ExecuteScalar());
            Conn.Close();
            return hovaten;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dangsach ds=new dangsach();
            this.Close();
            ds.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeXuat dx=new DeXuat();
            dx.ShowDialog();
        }
    }
  
}
