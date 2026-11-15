using QLSV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Forms.Report
{
    public partial class frmLichSuDiem : Form
    {
        private readonly int _maDK;
        private readonly DiemService _service = new DiemService();
        public frmLichSuDiem(int maDK)
        {
            InitializeComponent();
            _maDK = maDK;
        }
        private void frmLichSuDiem_Load(object sender, EventArgs e)
        {
            try
            {
                dgvLichSu.AutoGenerateColumns = false;
                dgvLichSu.DataSource =_service.GetLichSuSuaDiem(_maDK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
