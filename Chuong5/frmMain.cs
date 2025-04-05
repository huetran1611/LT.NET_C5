using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong5
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DAO.Connect();
                MessageBox.Show("Mo ket noi thanh cong toi csdl");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
        }

        private void dMNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmNhanVien = new frmDMNhanVien();
            frmNhanVien.ShowDialog();
        }
    }
}
