using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong5
{
    public partial class frmChatLieu : Form
    {
        public frmChatLieu()
        {
            InitializeComponent();
        }
        SqlConnection conn;

        private void frmChatLieu_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-78VRNVN\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //             MessageBox.Show("Mo ket noi thanh cong");

                string sql = "Select machatlieu, tenchatlieu from tblChatLieu";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mydata.Fill(dt);
                dataGridViewChatLieu.DataSource = dt;
                dataGridViewChatLieu.Columns[0].HeaderText = "ma chat lieu";
                dataGridViewChatLieu.Columns[1].HeaderText = "Ten chat lieu";
                dataGridViewChatLieu.Columns[0].Width = 100;
                dataGridViewChatLieu.Columns[1].Width = 300;

                dataGridViewChatLieu.AllowUserToAddRows = false;
                // Không cho phép sửa dữ liệu trực tiếp trên lưới
                dataGridViewChatLieu.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Boolean CheckOK()
        {
            if (txtMaCL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ma chat lieu");
                txtMaCL.Focus();
                return false;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten chat lieu");
                txtTenChatLieu.Focus();
                return false;
            }
            return true;
        }

        private void dataGridViewChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewChatLieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
            }
            else
            {
                txtMaCL.Text = dataGridViewChatLieu.CurrentRow.Cells[0].Value.ToString();
                txtTenChatLieu.Text = dataGridViewChatLieu.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckOK())
            {
                string MaChatLieu = txtMaCL.Text.Trim();
                string TenChatLieu = txtTenChatLieu.Text.Trim();

                string sql = "Insert tblChatLieu (machatlieu, tenchatlieu) values (N'" +
                    MaChatLieu + "' , N'" + TenChatLieu + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    command.ExecuteNonQuery();
                    string sql2 = "select * from tblChatLieu";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, conn);
                    DataTable tblChatLieu = new DataTable();
                    adapter.Fill(tblChatLieu);
                    dataGridViewChatLieu.DataSource = tblChatLieu;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
