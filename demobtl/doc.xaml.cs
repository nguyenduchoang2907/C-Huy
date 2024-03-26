/*using System;
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
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;

namespace demobtl
{

    /// <summary>
    /// Interaction logic for Tamcamdoc.xaml
    /// </summary>
    public partial class doc : Window
    {
        private int bookid;

        public doc(int bookid)
        {
            InitializeComponent();
            this.bookid = bookid;
        }

        private void doc_loaded(object sender, RoutedEventArgs e)
        {
            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);
            //string query = "SELECT TenChuong FROM Chapters WHERE book_id = @book_id ORDER BY ChuongID ASC";
            string query = "SELECT ChuongID,TenChuong FROM Chapters WHERE book_id = @book_id ORDER BY ChuongID ASC";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@book_id", bookid);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                ChapterComboBox.Items.Add(reader[0].ToString());

                ten.Text = reader["TenChuong"].ToString();
            }


            reader.Close();
            conn.Close();

        }

        private void btSangBinhLuan_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new comment();
            newWindow.ShowDialog();

            // Close this window
            Close();
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



        private void ChapterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);
            string query = "SELECT NoiDungChuong FROM Chapters WHERE ChuongID = @chapter_id";
            SqlCommand command = new SqlCommand(query, conn);
            int chapterId = ChapterComboBox.SelectedIndex;
            command.Parameters.AddWithValue("@chapter_id", chapterId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ChapterContentTextBox.Text = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
        }




        private void btDG_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new danhgia();
            newWindow.ShowDialog();
            // Close this window
            Close();
        }
    }
}
*/

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
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;

namespace demobtl
{

    /// <summary>
    /// Interaction logic for Tamcamdoc.xaml
    /// </summary>
    public partial class doc : Window
    {
        private int bookid;

        public doc(int bookid)
        {
            InitializeComponent();
            this.bookid = bookid;
        }

        private void doc_loaded(object sender, RoutedEventArgs e)
        {
            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);
            string query = "SELECT ChuongID,TenChuong FROM Chapters WHERE book_id = @book_id ORDER BY ChuongID ASC";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@book_id", bookid);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                ChapterComboBox.Items.Add(reader[1].ToString());
                aidibook.aydibook = bookid;

            }


            reader.Close();
            conn.Close();

        }

        private void btSangBinhLuan_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new comment();
            newWindow.ShowDialog();
            // Close this window
            
            Close();
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



        private void ChapterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);
            string query = "SELECT NoiDungChuong,TenChuong FROM Chapters WHERE ChuongID = @chapter_id";
            SqlCommand command = new SqlCommand(query, conn);
            int chapterId = ChapterComboBox.SelectedIndex + 1;
            command.Parameters.AddWithValue("@chapter_id", chapterId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ChapterContentTextBox.Text = reader.GetString(0);

                ten.Text = reader["TenChuong"].ToString();
            }
            reader.Close();
            conn.Close();
        }




        private void btDG_Click(object sender, RoutedEventArgs e)
        {
            danhgia newWindow = new danhgia();
            newWindow.ShowDialog();
            
            // Close this window
            Close();
        }

    }
}
