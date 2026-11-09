using QLSV.Data;
using QLSV.Helpers;
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

namespace QLSV.Forms.HeThong
{
    public partial class frmKhoa : Form
    {
        //Tầng Form chỉ đọc với Service.Tạo 1 lần dùng cả form. 
        private readonly KhoaService _svc = new KhoaService();

        //   true  = đang nhập khoa MỚI  (bấm Thêm sẽ gọi ThemMoi)
        //   false = đang SỬA khoa có sẵn (bấm Lưu sẽ gọi Luu)
        private bool _dangThem = true;

        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            //Kiểm tra quyền. HasPermission trả true/false.
            //Không có quyền QL_KHOA thì 3 nút bị mờ (chỉ xem được).
            bool coQuyen = SessionManager.HasPermission(MaChucNang.QL_KHOA);
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = coQuyen;

            SetupGrid();   //Khai báo các cột của lưới
            LoadData();    //Đổ dữ liệu từ CSDL lên lưới
            LamMoi();      //Đưa các ô nhập về trạng thái trống
        }

        private void SetupGrid()
        {

            dgvKhoa.AutoGenerateColumns = false;   // Tắt chế độ tự sinh cột.
            dgvKhoa.Columns.Clear();               // Xóa cột cũ (tránh bị nhân đôi nếu gọi lại).
            // Cột 1: Mã Khoa (Chiếm 30% độ rộng).
            dgvKhoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKhoa",
                HeaderText = "Mã Khoa",
                FillWeight = 30
            });

            // Cột 2: Tên Khoa (Chiếm 70% độ rộng)
            dgvKhoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenKhoa",
                HeaderText = "Tên Khoa",
                FillWeight = 70
            });


        }

        //Lấy danh sách khoa từ Service và hiện lên lưới
        private void LoadData()
        {
            dgvKhoa.DataSource = _svc.GetAll();
        }

        //Xóa trắng ô nhập, quay về chế độ "thêm mới"
        private void LamMoi()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtMaKhoa.ReadOnly = false;   //Cho phép gõ mã (khi sửa thì khóa lại, xem bên dưới)
            _dangThem = true;
            txtMaKhoa.Focus();            //Đưa con trỏ chuột nhấp nháy vào ô mã
        }

        //Người dùng bấm vào một dòng: đổ dòng đó lên ô nhập để sửa
        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bấm vào dòng tiêu đề thì RowIndex = -1: bỏ qua.
            if (e.RowIndex < 0) return;

            // DataBoundItem là đối tượng Khoa gắn với dòng đó. "as" ép kiểu
            // (sai kiểu thì ra null thay vì báo lỗi).
            Khoa k = dgvKhoa.Rows[e.RowIndex].DataBoundItem as Khoa;
            if (k == null) return;

            txtMaKhoa.Text = k.MaKhoa;
            txtTenKhoa.Text = k.TenKhoa;
            txtMaKhoa.ReadOnly = true;   // Mã là khóa chính, không cho đổi khi sửa
            _dangThem = false;           // Từ giờ bấm Lưu = SỬA
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Gom dữ liệu từ ô nhập thành 1 đối tượng. Trim() cắt khoảng trắng đầu/cuối.
            var k = new Khoa { MaKhoa = txtMaKhoa.Text.Trim(), TenKhoa = txtTenKhoa.Text.Trim() };

            Result r =  _svc.ThemMoi(k); //_dangThem ? _svc.Luu(k) :

            HienThongBao(r);

            //Thành công thì tải lại lưới và xóa ô nhập. Thất bại thì giữ nguyên để sửa.
            if (r.Success) 
            { 
                LoadData(); 
                LamMoi(); 
            }
        }
        

        // Làm mới = xóa ô nhập + tải lại lưới từ CSDL
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); LoadData(); }

        //Bấm Lưu: gom dữ liệu trên màn hình, giao cho Service xử lý
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var k = new Khoa
            {
                MaKhoa = txtMaKhoa.Text.Trim(),
                TenKhoa = txtTenKhoa.Text.Trim()
            };

            // Tự động điều hướng: Đang thêm thì gọi ThemMoi, đang chọn dòng dưới bảng thì gọi Luu
            Result r =  _svc.Luu(k); //: _svc.ThemMoi(k);

            HienThongBao(r);

            // Xử lý xong thành công -> Tải lại lưới + Tự động xóa trống Form để sẵn sàng nhập tiếp
            if (r.Success)
            {
                LoadData();
                LamMoi();

            }
        }

        //Bấm Xóa: hỏi lại cho chắc rồi gọi Service
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Chưa chọn khoa nào (ô mã trống) thì nhắc và thoát.
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Hãy chọn khoa cần xóa.", "Thông báo");
                return;
            }

            
            if (MessageBox.Show("Xóa khoa " + txtMaKhoa.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            // Service sẽ kiểm tra "khoa còn ngành thì chặn".
            Result r = _svc.Xoa(txtMaKhoa.Text.Trim());
            HienThongBao(r);
            if (r.Success) 
            { 
                LoadData(); 
                LamMoi(); 
            }
        }

        //Hiện kết quả của Service: biểu tượng (i) nếu OK, cảnh báo nếu lỗi
        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
