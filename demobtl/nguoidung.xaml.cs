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
    /// Interaction logic for nguoidung.xaml
    /// </summary>
    public partial class nguoidung : Window
    {
        string ConnectionString = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;
        public nguoidung()
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
                NapDuLieuTuMayChu();
                danhsach.SelectionChanged += datagrid_SelectionChanged;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi");
            }
        }
        private void NapDuLieuTuMayChu()
        {
            danhsach.ItemsSource = null;
            if (conn.State != ConnectionState.Open) return;
            string sql = "SELECT userss.user_id, userss.login_id, userss.name, userss.email,userss.phonenumber, dangnhap.username, dangnhap.password " +
               "FROM userss " +
               "INNER JOIN dangnhap ON userss.login_id = dangnhap.login_id";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            danhsach.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private bool KiemTraLoginDaTonTai(string username)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM dangnhap WHERE username = @Username";
            command.Parameters.AddWithValue("@Username", username);

            int count = (int)command.ExecuteScalar();

            
            return count > 0;

        }

        private int LayIdDangnhap(string username)
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT login_id FROM dangnhap WHERE username = @Username";
            command.Parameters.AddWithValue("@Username", username);
            int loginId = (int)command.ExecuteScalar();
            return loginId;
        }
            
        private void themLogin()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO dangnhap(username,password) VALUES ('" + username.Text + "', '" + password.Text + "')";
            command.ExecuteNonQuery();
        }

        private void danhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void thêm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();

                bool logindaco = KiemTraLoginDaTonTai(username.Text);
                int loginId = -1;
                if (!logindaco)
                {
                    themLogin();
                    loginId = LayIdDangnhap(username.Text);
                }
                else
                {
                    loginId = LayIdDangnhap(username.Text);
                }

                if (loginId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin đăng nhập");
                    return;
                }

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO userss(login_id,name,email,phonenumber) VALUES (@loginId, @name, @email, @phone)";
                command.Parameters.AddWithValue("@loginId", loginId);
                command.Parameters.AddWithValue("@name", ten.Text);
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.ExecuteNonQuery();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tuKhoa = timkiem.Text;
            Timkiem(tuKhoa);
        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhsach.SelectedItem == null) return;

            DataRowView rowView = (DataRowView)danhsach.SelectedItem;
            id_user.Text = rowView[0].ToString();
            id_lg.Text = rowView[1].ToString();
            ten.Text = rowView[2].ToString();
            email.Text = rowView[3].ToString();
            phone.Text = rowView[4].ToString();
            username.Text = rowView[5].ToString();
            password.Text = rowView[6].ToString();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();

                bool logindaco = KiemTraLoginDaTonTai(username.Text);
                int loginId = -1;
                if (!logindaco)
                {
                    themLogin();
                    loginId = LayIdDangnhap(username.Text);
                }
                else
                {
                    loginId = LayIdDangnhap(username.Text);
                }

                if (loginId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin đăng nhập");
                    return;
                }

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update userss set login_id=@loginId, name=@name, email=@email, phonenumber=@phone where user_id=@userId";
                command.Parameters.AddWithValue("@loginId", id_lg.Text);
                command.Parameters.AddWithValue("@name", ten.Text);
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.Parameters.AddWithValue("@userId", id_user.Text);
                command.ExecuteNonQuery();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void xoaLogin()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "delete from userss where login_id= '" + id_lg.Text + "'";
            command.ExecuteNonQuery();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                bool logindaco = KiemTraLoginDaTonTai(username.Text);
                if (!logindaco)
                {
                    themLogin();
                }

                SqlCommand command = con.CreateCommand();
                command.CommandText = "delete from userss where user_id= @UserID";
                command.Parameters.AddWithValue("@UserID", id_user.Text);
                command.ExecuteNonQuery();
                NapDuLieuTuMayChu();

                con.Close();
            }
        }

        private void Timkiem(string tuKhoa = null)
        {
            danhsach.ItemsSource = null;
            if (conn.State != ConnectionState.Open) return;

            string sql = "SELECT userss.user_id, userss.login_id, userss.name, userss.email,userss.phonenumber, dangnhap.username, dangnhap.password " +
               "FROM userss " +
               "INNER JOIN dangnhap ON userss.login_id = dangnhap.login_id ";
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += "WHERE userss.name LIKE @TuKhoa";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
            }
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            danhsach.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void capnhat_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
        }

        private void quayve_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            conn.Close();
            this.Close();
            main.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainWindow main = new MainWindow();
            conn.Close();
            this.Close();
            main.ShowDialog();
        }
    }
}
