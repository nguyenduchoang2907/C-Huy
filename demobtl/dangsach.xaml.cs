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
    /// Interaction logic for dangsach.xaml
    /// </summary>
    public partial class dangsach : Window
    {
        string ConnectionString = "";
        SqlConnection conn = new SqlConnection();
        DataTable DataSource = null;
        long SelectedID = 0;
        bool isNew = false;
        public dangsach()
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

            string sql = "SELECT book.title, category.name_category, author.author_name, book.content, book.book_id, book.category_id, book.author_id " +
               "FROM book " +
               "INNER JOIN category ON book.category_id = category.category_id " +
               "INNER JOIN author ON book.author_id = author.author_id ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            danhsach.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void thêm_Click(object sender, RoutedEventArgs e)
        {
            bool tacgiaDaCo = KiemTraTacGiaDaTonTai(tacgia.Text);
            bool theloaiDaCo = KiemTraTheLoaiDaTonTai(theloai.Text);
            if (!tacgiaDaCo)
            {
                themtacgia();
            }
            if (!theloaiDaCo)
            {
                themtheloai();
            }
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO book(author_id, category_id, title, content,image) VALUES ('" + id_tg.Text + "','" + id_tl.Text + "','" + ten.Text + "', '" + content.Text + "','" + image.Text + "')";
            command.ExecuteNonQuery();
            NapDuLieuTuMayChu();

            conn.Close();
        }

        private bool KiemTraTacGiaDaTonTai(string tenTacGia)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM author WHERE author_name = @TenTacGia";
            command.Parameters.AddWithValue("@TenTacGia", tenTacGia);

            int count = (int)command.ExecuteScalar();

            return count > 0;
        }

        private bool KiemTraTheLoaiDaTonTai(string tenTheLoai)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM category WHERE name_category = @TenTheLoai";
            command.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private int LayIdTacGia(string tenTacGia)
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT author_id FROM author WHERE author_name = @TenTacGia";
            command.Parameters.AddWithValue("@TenTacGia", tenTacGia);
            int authorId = (int)command.ExecuteScalar();
            return authorId;
        }

        private int LayIdTheLoai(string tenTheLoai)
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT category_id FROM category WHERE name_category = @TenTheLoai";
            command.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
            int categoryId = (int)command.ExecuteScalar();
            return categoryId;
        }
        private void themtacgia()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO author(author_name) VALUES ('" + tacgia.Text + "')";
            command.ExecuteNonQuery();
        }

        private void themtheloai()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO category(name_category) VALUES ('" + theloai.Text + "')";
            command.ExecuteNonQuery();
        }

        private void danhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void suatacgia()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO author(author_name) VALUES ('" + tacgia.Text + "')";
            command.ExecuteNonQuery();
        }
        private void sua_Click(object sender, RoutedEventArgs e)
        {
            bool tacgiaDaCo = KiemTraTacGiaDaTonTai(tacgia.Text);
            bool theloaiDaCo = KiemTraTheLoaiDaTonTai(theloai.Text);
            if (!tacgiaDaCo)
            {
                themtacgia();
            }
            if (!theloaiDaCo)
            {
                themtheloai();
            }
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "update book set author_id='" + id_tg.Text + "', category_id='" + id_tl.Text + "',title='" + ten.Text + "',content='" + content.Text + "', image='" + image.Text + "' where book_id='" + id_sach.Text + "'";
            command.ExecuteNonQuery();
            NapDuLieuTuMayChu();
        }

        private void xoatacgia()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "delete from autor where author_id= '" + id_tg.Text + "'";
            command.ExecuteNonQuery();
        }
        private void xoatheloai()
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "delete from category where book_id= '" + id_tl.Text + "'";
            command.ExecuteNonQuery();
        }
        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            bool tacgiaDaCo = KiemTraTacGiaDaTonTai(tacgia.Text);
            bool theloaiDaCo = KiemTraTheLoaiDaTonTai(theloai.Text);
            if (!tacgiaDaCo)
            {
                xoatacgia();
            }
            if (!theloaiDaCo)
            {
                xoatheloai();
            }
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "delete from book where book_id= '" + id_sach.Text + "'";
            command.ExecuteNonQuery();
            NapDuLieuTuMayChu();
        }

        private void capnhat_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
        }

        private void Timkiem(string tuKhoa = null)
        {
            danhsach.ItemsSource = null;
            if (conn.State != ConnectionState.Open) return;

            string sql = "SELECT book.title, category.name_category, author.author_name, book.content,book.book_id, book.category_id, book.author_id " +
               "FROM book " +
               "INNER JOIN category ON book.category_id = category.category_id " +
               "INNER JOIN author ON book.author_id = author.author_id ";
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += "WHERE book.title LIKE @TuKhoa";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tuKhoa = timkiem.Text;
            Timkiem(tuKhoa);
        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhsach.SelectedItem == null) return;

            DataRowView rowView = (DataRowView)danhsach.SelectedItem;
            ten.Text = (string)rowView[0];
            theloai.Text = (string)rowView[1];
            tacgia.Text = (string)rowView[2];
            content.Text = (string)rowView[3];
            id_sach.Text = rowView[4].ToString();
            id_tl.Text = rowView[5].ToString();
            id_tg.Text = rowView[6].ToString();
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
