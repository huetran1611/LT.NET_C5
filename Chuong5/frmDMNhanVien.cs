using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chuong5
{
    public partial class frmDMNhanVien : Form
    {
        public frmDMNhanVien()
        {
            InitializeComponent();
        }

        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                loadDataToGridView();
                txtMaNhanVien.Enabled = false;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void loadDataToGridView()
        {
             
            string sql = "Select * from tblNhanVien";
            DataTable dt = DAO.LoadDataToTable(sql);
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].HeaderText = "Ma nhan vien";
            dataGridView.Columns[1].HeaderText = "Ten nhan vien";
            dataGridView.Columns[2].HeaderText = "Gioi Tinh";
            // viet tiep cho cac cot con lai
            dataGridView.AllowUserToAddRows = false;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Khog co du lieu de hien thi");
                return;
            }
            txtMaNhanVien.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtTenNhanVien.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            mskDienThoai.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            mskNgaySinh.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtDiaChi.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();

            if (dataGridView.CurrentRow.Cells[2].Value.ToString().ToUpper() == "NAM")
                chkGioiTinh.Checked = true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }
        private void clear()
        {
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            chkGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
            mskNgaySinh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckData())
                return;
            string gioitinh;
            if (chkGioiTinh.Checked)
                gioitinh = "Nam";
            else gioitinh = "Nu";


            string sql = "Insert tblNhanVien (MaNhanVien, TenNhanVien," +
                "GioiTinh, Ngayinh, DienThoai )" +
                " values ('" + txtMaNhanVien.Text + "', N'" +
                txtTenNhanVien.Text + "', '" + gioitinh + "',' " +
                DAO.getSQLdateFromText(mskNgaySinh.Text) + "', '" +
                mskDienThoai.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(sql,DAO.con );
            sqlCommand.ExecuteNonQuery();
            loadDataToGridView();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;

        }


        private bool CheckData()
        {
            if (txtMaNhanVien.Text.Trim() =="")
            { MessageBox.Show("Khong duoc detrong ma nhan vien");
                txtMaNhanVien.Focus();
                return false;
            }
            if (txtTenNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Khong duoc de trong ten nhan vien");
                txtTenNhanVien.Focus();
                return false;
            }
            // Laan luot kiem tra het cac thanh phan
            return true;
        }

    }
}
