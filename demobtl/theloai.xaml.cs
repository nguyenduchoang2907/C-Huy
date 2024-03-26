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
using System.IO;

namespace demobtl
{

    /// <summary>
    /// Interaction logic for theloai.xaml
    /// </summary>
    public partial class theloai : Window
    {
        private bool isBookDialogOpen = false;
        private Book bookDialog;
        string ConnectionString = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;

        public theloai()
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
                LoadListBox();
                LoadCategoryComboBox();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi");
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadListBox();

        }
        private void LoadCategoryComboBox()
        {
            combodm.ItemsSource = null;
            if (conn.State != ConnectionState.Open) return;
            string sql = "Select * from category";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            combodm.SelectedValuePath = "category_id";
            combodm.DisplayMemberPath = "name_category";
            combodm.ItemsSource = dataTable.DefaultView;
        }

        private void LoadListBox()
        {
            listbook.ItemsSource = null;
            int id_cate = (int)combodm.SelectedIndex + 1;
            if (conn.State != ConnectionState.Open) return;
            string query = "SELECT book.book_id, book.title, book.content, category.name_category, author.author_name " +
               "FROM book " +
               "INNER JOIN category ON book.category_id = category.category_id " +
               "INNER JOIN author ON book.author_id = author.author_id " +
               "WHERE book.category_id = @category_id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.SelectCommand.Parameters.AddWithValue("@category_id", id_cate);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);



            dataTable.Columns.Add("TitleAuthor", typeof(string), "title + ' - ' + author_name");

            listbook.ItemsSource = dataTable.DefaultView;
            listbook.SelectedValuePath = "id_book";
            listbook.DisplayMemberPath = "TitleAuthor";


            listbook.SelectionChanged += ListBox_SelectionChanged;
        }

        public class Books
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Category { get; set; }
            public string Author { get; set; }
        }
        private Books GetSelectedBook(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                string title = selectedRow["title"] as string;
                string content = selectedRow["content"] as string;
                string category = selectedRow["name_category"] as string;
                string author = selectedRow["author_name"] as string;

                return new Books()
                {
                    Title = title,
                    Content = content,
                    Category = category,
                    Author = author
                };
            }
            return null;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = listbook.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                string title = selectedRow["title"] as string;
                string content = selectedRow["content"] as string;
                string category = selectedRow["name_category"] as string;
                string author = selectedRow["author_name"] as string;

                int bookid = (int)selectedRow["book_id"];

                if (isBookDialogOpen)
                {
                    bookDialog.Close();
                }

                bookDialog = new Book(bookid);
                bookDialog.ShowDialog();
                isBookDialogOpen = true;
            }
        }



        private void Book_Closed(object sender, EventArgs e)
        {
            bookDialog = null;
            isBookDialogOpen = false;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
        }

        private void tl_Click(object sender, RoutedEventArgs e)
        {
            theloai theloai = new theloai();
            theloai.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void dangxuat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form_Search fr = new Form_Search();
            fr.tb_cref.Text = tb_search.Text;
            this.Close();
            fr.ShowDialog();

        }
    }
}