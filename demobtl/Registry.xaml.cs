using System;
using System.Collections.Generic;
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
    /// Interaction logic for Registry.xaml
    /// </summary>
    
    public partial class Registry : Window
    {
        String str = "";
        SqlConnection Conn = new SqlConnection();
        public Registry()
        {
            InitializeComponent();
        }


        private void register_Click(object sender, RoutedEventArgs e)
        {
            string str = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();

            String tblStr = "INSERT INTO userss (login_id, name, email, phonenumber, avata) VALUES (@login_id, @name, @email, @phone, @avata)";
            SqlCommand cmd = new SqlCommand(tblStr, Conn);
            cmd.Parameters.AddWithValue("@name", tb_Name.Text);
            cmd.Parameters.AddWithValue("@email", tb_Email.Text);
            cmd.Parameters.AddWithValue("@phone", tb_Phone.Text);
            cmd.Parameters.AddWithValue("@avata", 1);

            int login_id = Create_account(str);
            cmd.Parameters.AddWithValue("@login_id", login_id);

            cmd.ExecuteNonQuery();

            Conn.Close();
            this.Close();
        }
        private int Create_account(string str)
        {
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            String tblStr1 = "Insert Into dangnhap (username, password) values (@username, @password); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(tblStr1, Conn);
            command.Parameters.AddWithValue("@username", tb_username.Text);
            command.Parameters.AddWithValue("@password", Encrypt.EncodeMD5(tb_password.Text));
            int login_id = Convert.ToInt32(command.ExecuteScalar());
            Conn.Close();

            return login_id;
        }


    }
}