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
    /// Interaction logic for Form_Search.xaml
    /// </summary>
    public partial class Form_Search : Window
    {
        string Sqlstring = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;
        private bool isBookDialogOpen;

        public Book bookDialog { get; private set; }

        public Form_Search()
        {
            InitializeComponent();
        }
        private void Form_Search_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                //Sqlstring = @"Data Source=DESKTOP-O3MFBSE;Initial Catalog=DocSachCK;Integrated Security=True";
                Sqlstring = @"Data Source=bruh\sqlexpress;Initial Catalog=hocphannon;Integrated Security=True";
                conn.ConnectionString = Sqlstring;
                conn.Open();

                ip_cate();
                if (tb_cref.Text != null && tb_cref.Text != "Tìm kiếm")
                {
                    Data_Search.ItemsSource = null;
                    if (conn.State != ConnectionState.Open) return;
                    string SqlStr = "Select book_id,title,author_name,name_category,content from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id  and title like '%" + tb_cref.Text + "%' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    DataSource = dataSet.Tables[0];
                    Data_Search.DisplayMemberPath = "title";
                    Data_Search.ItemsSource = DataSource.DefaultView;
                }
                
                else if (tb_cref.Text == "Tìm kiếm")
                {
                    Napdulieu();
                }
                else
                {
                    Napdulieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex);
            }



        }
        private void Button_Search(object sender, RoutedEventArgs e)
        {
            //title
            if ((KeyWord_title.Text != null || KeyWord_title.Text != "") 
                && (KeyWord_author.Text == null || KeyWord_author.Text == "") 
                && (KeyWord_category.Text == null || KeyWord_category.Text == ""))
            {

                Search_single_title();
            }
            //category
            else if ((KeyWord_title.Text == null || KeyWord_title.Text == "") 
                && (KeyWord_author.Text == null || KeyWord_author.Text == "") 
                && (KeyWord_category.Text != null || KeyWord_category.Text != ""))
            {

                Search_single_category();
            }
            //author
            else if ((KeyWord_title.Text == null || KeyWord_title.Text == "") 
                && (KeyWord_author.Text != null || KeyWord_author.Text != "") 
                && (KeyWord_category.Text == null || KeyWord_category.Text == ""))
            {
                Search_single_author();
            }
            //title and category
            else if ((KeyWord_title.Text != null || KeyWord_title.Text != "") 
                && (KeyWord_author.Text == null || KeyWord_author.Text == "") 
                && (KeyWord_category.Text != null || KeyWord_category.Text != ""))
            {

                Search_Dou_tAc(KeyWord_title, KeyWord_category);
            }
            //author and category
            else if ((KeyWord_title.Text == null || KeyWord_title.Text == "") 
                && (KeyWord_author.Text != null || KeyWord_author.Text != "") 
                && (KeyWord_category.Text != null || KeyWord_category.Text != ""))
            {
                Search_Dou_aAc(KeyWord_author, KeyWord_category);
            }
            //author and title
            else if ((KeyWord_title.Text != null || KeyWord_title.Text != "") 
                && (KeyWord_author.Text != null || KeyWord_author.Text != "") 
                && (KeyWord_category.Text == null || KeyWord_category.Text == ""))
            {
                Search_Dou_aAt(KeyWord_author, KeyWord_title);
            }
            //all
            else
            {
                Data_Search.ItemsSource = null;
                string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and title like '%" + KeyWord_title.Text + "%' and (name_category like '%" + KeyWord_category.Text + "%' and (author_name like '%" + KeyWord_author.Text + "%'))";
                SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);


                Data_Search.DisplayMemberPath = "title";
                Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;

                Data_Search.SelectionChanged += Data_Search_SelectionChanged;
            }
        }

        private void Button_ShowAll(object sender, RoutedEventArgs e)
        {
            Napdulieu();
        }

        private void ip_cate()
        {
            List_category.ItemsSource = null;
            //if (conn.State != ConnectionState.Open) return;
            string SqlStr = "Select name_category from category ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            List_category.SelectedValuePath = "category_id";
            List_category.DisplayMemberPath = "name_category";
            List_category.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void Napdulieu()
        {
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }

        private void Search_single_title()
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and title like '%" + KeyWord_title.Text + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }
        private void Search_single_category()
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and name_category like '%" + KeyWord_category.Text + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }
        private void Search_single_author()
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and author_name like '%" + KeyWord_author.Text + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close() ;
        }
        private void Search_Dou_aAc(TextBox a, TextBox b)
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and author_name like '%" + a.Text + "%' and ( name_category like '%" + b.Text + "%')";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close() ;
        }
        private void Search_Dou_aAt(TextBox a, TextBox b)
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and author_name like '%" + a.Text + "%' and ( title like '%" + b.Text + "%')";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close() ;
        }
        private void Search_Dou_tAc(TextBox a, TextBox b)
        {
            conn.Open();
            Data_Search.ItemsSource = null;
            string SqlStr = "Select book_id,title,content,author_name,name_category from book,category,author where author.author_id=book.author_id and category.category_id=book.category_id and title like '%" + a.Text + "%' and ( name_category like '%" + b.Text + "%')";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Data_Search.SelectedValuePath = "book_id";
            Data_Search.DisplayMemberPath = "title";
            Data_Search.ItemsSource = dataSet.Tables[0].DefaultView;
            conn.Close() ;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            User us = new User();
            this.Close();
            us.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            conn.Close();
            this.Close();
            main.ShowDialog();
        }

        private void tl_Click(object sender, RoutedEventArgs e)
        {
            theloai theloai = new theloai();
            this.Close();
            theloai.ShowDialog();
        }

        private void dangxuat_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            conn.Close();
            this.Close();
            login.ShowDialog();
        }



        private void Data_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataRowView selectedRow = Data_Search.SelectedItem as DataRowView;

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

    }
}