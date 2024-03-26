using System;
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
    /// Interaction logic for danhgia.xaml
    /// </summary>
    /// 


    
    
    public partial class danhgia : Window
    {
        //string ConnectionString = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;
        private string connectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";


        private int bookid;

        public danhgia()
        {
            InitializeComponent();
            this.bookid = bookid;
        }


        private void danhgia_loaded(object sender, RoutedEventArgs e)
        {

            cmbDG.Items.Add("1");
            cmbDG.Items.Add("2");
            cmbDG.Items.Add("3");
            cmbDG.Items.Add("4");
            cmbDG.Items.Add("5");

            try
            {

                string ConnectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";

                conn.ConnectionString = ConnectionString;
                conn.Open();
                NapDuLieuTuMayChu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi");
            }
        }

        private void NapDuLieuTuMayChu()
        {
            dgDG.ItemsSource = null;
            if (conn.State != ConnectionState.Open) return;

            string sql = "SELECT  review.review_id,review.rating,book.title, review.comment from review,book where review.book_id=book.book_id and review.book_id='"+aidibook.aydibook+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dgDG.ItemsSource = dataSet.Tables[0].DefaultView;
        }


        private void cmbDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDG.SelectedItem == null) return;
            DataRowView rowView = (DataRowView)dgDG.SelectedItem;
            cmbDG.SelectedIndex = (int)rowView[0];
            txtBL.Text = (string)rowView[1];
        }

        private void btLuu_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(connectionString))
                {
                    Conn.Open();
                    string query = "INSERT INTO review( user_id, book_id, rating, comment) VALUES ( @userid, @bookid, @rating, @comment)";

                    using (SqlCommand command = new SqlCommand(query, Conn))
                    {
                        //command.Parameters.AddWithValue("@reviewid", txtR.Text);
                        command.Parameters.AddWithValue("@userid", ID_login.id_login-1);
                        command.Parameters.AddWithValue("@bookid", aidibook.aydibook);
                        //command.Parameters.AddWithValue("@rating", Convert.ToInt32(((ComboBoxItem)cmbDG.SelectedItem).Content));
                        command.Parameters.AddWithValue("@rating", Convert.ToInt32(cmbDG.SelectedItem));
                        command.Parameters.AddWithValue("@comment", txtBL.Text);

                        int kq = command.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Luu thanh cong");
                        }
                        else
                        {
                            MessageBox.Show("Luu that bai");
                        }
                    }
                    NapDuLieuTuMayChu();
                    dgDG.SelectionChanged += dgDG_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btThoat_Click_1(object sender, RoutedEventArgs e)
        {
            Thoat();
        }

        private void Thoat()
        {
            if (MessageBox.Show("Ban co chac la muon thoat khoi chuong trinh nay hay khong?",
                            "Xac nhan dung chuong trinh",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }

}