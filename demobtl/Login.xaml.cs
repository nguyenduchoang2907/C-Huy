using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    
    public partial class Login : Window
    {
        string str = "";
        SqlConnection Conn = new SqlConnection();

        public Login()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                    str = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                    Conn.ConnectionString = str;
                Conn.Open();
            }
            catch
            {
                MessageBox.Show("Loi ket noi");
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mk = Encrypt.EncodeMD5(tb_Password.Password);
            string str = "Select username,password from dangnhap Where username= '" +tb_Username.Text+ "' and password= '" +mk + "' ";

            SqlDataAdapter adapter = new SqlDataAdapter(str, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (!AllowLogin()) return;

            ID_login.id_login = layid();

            MainWindow m = new MainWindow();

            string sr = sl_role();
            if (dataSet.Tables[0].Rows.Count >0)
            {
                if (sr == "admin")
                {
                    Conn.Close();   
                    this.Close();
                    m.ShowDialog();
                }
                else
                {
                    Conn.Close();
                    ID_login.id_login = layid();
                    this.Close();
                    m.demo_tb.Text = "no_admin";
                    m.ShowDialog();
                    
                }
               
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                tb_Username.Focus();
            }


        }

        private bool AllowLogin()
        {
            if (tb_Username.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin tài khoản");
                tb_Username.Focus();
                return false;
            }
            if (tb_Password.Password.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                tb_Password.Focus();
                return false;
            }
            return true;
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            Registry registry = new Registry();
            registry.ShowDialog();
        }

        private int layid()
        {
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            string tblStr1 = "select * from dangnhap where username=@tb_Username";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= Conn;
            cmd.CommandText=tblStr1;
            var id=cmd.Parameters.AddWithValue("@tb_Username",tb_Username.Text);
            int login_id = Convert.ToInt32(cmd.ExecuteScalar());
            Conn.Close();
            return login_id;
        }

        private string sl_role()
        {

            string hovaten;
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            string tblStr1 = "select role from dangnhap where login_id=@login_id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = tblStr1;
            var id = cmd.Parameters.AddWithValue("login_id", ID_login.id_login.ToString());
            hovaten = Convert.ToString(cmd.ExecuteScalar());
            Conn.Close();
            return hovaten;
        }
        
    }
}
