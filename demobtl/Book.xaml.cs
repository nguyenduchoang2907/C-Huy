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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Window
    {
        SqlConnection conn = new SqlConnection();
        private int bookid;
        public Book(int bookid)
        {
            InitializeComponent();
            this.bookid = bookid;


        }
        private void LoadBook(object sender, RoutedEventArgs e)
        {
            string connectionStr = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
            conn = new SqlConnection(connectionStr);
            string query = "SELECT book.title, category.name_category, author.author_name, book.trangthai, book.content " +
                   "FROM book " +
                   "INNER JOIN category ON book.category_id = category.category_id " +
                   "INNER JOIN author ON book.author_id = author.author_id " +
                   "WHERE book.book_id = @book_id";
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btDoc_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new doc(bookid);
            newWindow.ShowDialog();


            Close();
        }
        SqlCommand cmd = new SqlCommand();
        private void image_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = openFileDialog.Filter = "JPG files (*.jpg)|*.jpa|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(fileName);
                cmd.Parameters.AddWithValue("@ImageColumn", imageBytes);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd = new SqlCommand("INSERT INTO YourTable (ImageColumn) VALUES (@ImageColumn)", conn);
                cmd.Parameters.AddWithValue("@ImageColumn", imageBytes);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                DisplayImages();
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            
            this.Close();
            login.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            conn.Close();
            this.Close();
            main.ShowDialog();
        }

        /*
       private void DisplayImages()
       {
           listBox.Items.Clear();

           SqlCommand cmd = new SqlCommand("SELECT ImageColumn FROM YourTable", conn);
           conn.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               byte[] imageBytes = (byte[])reader["ImageColumn"];
               Image image = byteArrayToImage(imageBytes);
               listBox.Items.Add(image);
           }
           conn.Close();
       }

       private Image byteArrayToImage(byte[] byteArrayIn)
       {
           MemoryStream ms = new MemoryStream(byteArrayIn);
           Image returnImage = Image.FromStream(ms);
           return returnImage;
       }
       */

    }
}
/*
byte[] imageBytes = (byte[])reader["image"];
Image image = byteArrayToImage(imageBytes);
picture.Items.Add(image);*/
        
     