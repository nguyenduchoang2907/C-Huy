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
using static System.Net.Mime.MediaTypeNames;

namespace demobtl
{
    /// <summary>
    /// Interaction logic for comment.xaml
    /// </summary>
    public partial class comment : Window
    {


        private string connectionString = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";


        private int bookid;
        private object image;

        public comment()
        {
            InitializeComponent();
            this.bookid = bookid;
        }

        private void btAddComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(connectionString))
                {
                    Conn.Open();
                    string query = "INSERT INTO comment( user_id, book_id, content) VALUES ( @userid, @bookid, @comment)";
                    using (SqlCommand command = new SqlCommand(query, Conn))
                    {
                        command.Parameters.AddWithValue("@userid", ID_login.id_login);
                        command.Parameters.AddWithValue("@bookid", aidibook.aydibook);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadBook(object sender, RoutedEventArgs e)
        {

            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";



            SqlConnection conn = new SqlConnection(connectionStr);
            string query = "SELECT book.title, category.name_category, author.author_name, book.trangthai, book.content, book.image FROM book JOIN category ON book.category_id = category.category_id JOIN author ON book.author_id = author.author_id WHERE book.book_id = @book_id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@book_id", bookid);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ten.Text = reader["title"].ToString();
                tacgia.Text = reader["author_name"].ToString();
                theloai.Text = reader["name_category"].ToString();
                tinhtrang.Text = reader["trangthai"].ToString();
            }
            reader.Close();
            conn.Close();
        }
    }
}