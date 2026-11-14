using QLSV.Helpers;
using System.Drawing;
using QLSV.Services;
using System;
using System.Windows.Forms;

namespace QLSV.Forms.Finance
{
    public partial class frmThuHocPhi : Form
    {
        private readonly FeeService _feeService = new FeeService();

        // Giới hạn trên của ô nhập tiền khi không có công nợ
        private const decimal MAX_TIEN_MAC_DINH = 100000000000m;
        private int _qrRequestId;
        private bool _dangNapDuLieu;   // true khi đang gán số tiền từ công nợ: bỏ qua ValueChanged

        private bool _coQuyenThu;
        private bool _daTraCuuThanhCong;
        private decimal _conNoHienTai;

        // Mã SV / HK đã tra cứu thành công: lập phiếu luôn dùng đúng cặp này,
        // tránh trường hợp người dùng sửa ô text sau khi tra cứu rồi bấm Lập phiếu.
        private string _maSVDaTraCuu = "";
        private string _maHKDaTraCuu = "";

        public frmThuHocPhi()
        {
            InitializeComponent();
        }

        // Giữ lại các handler rỗng vì Designer có thể đang đăng ký sự kiện.
        // Nếu muốn xóa: xóa cả dòng "+= new EventHandler(...)" trong file .Designer.cs.
        private void lblHoTen_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblPhaiThu_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void XoaQR()
        {
            _qrRequestId++;
            if (picQR.Image != null)
            {
                picQR.Image.Dispose();
                picQR.Image = null;
            }
            lblTaiKhoan.Text = "";
            lblNoiDung.Text = "";
        }
        private void FrmThuHocPhi_Load(object sender, EventArgs e)
        {
            _coQuyenThu = SessionManager.HasPermission(MaChucNang.THU_HOC_PHI);
            ResetGiaoDien();

            txtMaSV.TextChanged += (s, ev) => ResetGiaoDien();
            txtMaHK.TextChanged += (s, ev) => ResetGiaoDien();
            // Đổi số tiền thu thì QR tự tạo lại theo số tiền mới.
            nudSoTienThu.ValueChanged += (s, ev) => { if (!_dangNapDuLieu) TaiQR(); };
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadCongNo(true);
        }
        // Tra cứu và hiển thị công nợ. Trả về true nếu thành công.
        private bool LoadCongNo(bool hienThongBaoLoi)
        {
            string maSV = txtMaSV.Text.Trim();
            string maHK = txtMaHK.Text.Trim();

            if (maSV.Length == 0 || maHK.Length == 0)
            {
                ResetGiaoDien();
                if (hienThongBaoLoi)
                    MessageBox.Show("Vui lòng nhập mã sinh viên và mã học kỳ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var r = _feeService.TinhHocPhi(maSV, maHK);

            if (!r.Success)
            {
                ResetGiaoDien();
                if (hienThongBaoLoi)
                    MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var hp = r.Data;

            lblHoTen.Text = hp.HoTen;
            lblTongTC.Text = hp.TongTinChi.ToString();
            lblPhaiThu.Text = hp.PhaiThu.ToString("N0") + " đ";
            lblDaThu.Text = hp.DaThu.ToString("N0") + " đ";
            lblConNo.Text = hp.ConNo.ToString("N0") + " đ";

            _maSVDaTraCuu = maSV;
            _maHKDaTraCuu = maHK;
            _conNoHienTai = hp.ConNo;
            _daTraCuuThanhCong = true;

            _dangNapDuLieu = true;
            if (hp.ConNo > 0)
            {
                // Đặt Maximum TRƯỚC rồi mới gán Value để không bị ngoại lệ
                nudSoTienThu.Maximum = hp.ConNo;
                nudSoTienThu.Value = hp.ConNo;
            }
            else
            {
                nudSoTienThu.Maximum = MAX_TIEN_MAC_DINH;
                nudSoTienThu.Value = 0;
            }
            _dangNapDuLieu = false;

            CapNhatTrangThaiNut();
            TaiQR();   // tên sinh viên đã hiện thì QR và thông tin chuyển khoản tự hiện theo
            return true;
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (!_coQuyenThu)
            {
                MessageBox.Show("Bạn không có quyền lập phiếu thu.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_daTraCuuThanhCong)
            {
                MessageBox.Show("Vui lòng tra cứu công nợ trước khi lập phiếu.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soTien = nudSoTienThu.Value;
            if (soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền thu lớn hơn 0.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soTien > _conNoHienTai)
            {
                MessageBox.Show("Số tiền thu không được vượt quá số còn nợ.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNguoiLap;
            if (SessionManager.IsLoggedIn)
            {
                maNguoiLap = SessionManager.CurrentUser.MaND;
            }
            else
            {
#if DEBUG
                maNguoiLap = 1; // chỉ dùng khi test trực tiếp, bỏ qua form Login
#else
                MessageBox.Show("Bạn chưa đăng nhập.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
#endif
            }

            var xacNhan = MessageBox.Show(
                $"Lập phiếu thu {soTien:N0} đ cho sinh viên {_maSVDaTraCuu} (học kỳ {_maHKDaTraCuu})?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            // Khóa nút trong lúc xử lý để tránh bấm đúp lập trùng phiếu
            btnLapPhieu.Enabled = false;
            try
            {
                var r = _feeService.LapPhieuThu(
                    _maSVDaTraCuu,
                    _maHKDaTraCuu,
                    soTien,
                    txtGhiChu.Text.Trim(),
                    maNguoiLap
                );

                if (r.Success)
                {
                    MessageBox.Show(r.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Lấy thông tin để in TRƯỚC khi tải lại công nợ
                    int maPhieu = r.Data;
                    string tenSV = lblHoTen.Text;
                    DateTime ngayLap = DateTime.Now;
                    txtGhiChu.Text = "";
                    LoadCongNo(true);

                    if (MessageBox.Show("Bạn có muốn in phiếu thu không?", "In phiếu",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var f = new QLSV.Forms.Report.frmInPhieuThu(
                                   maPhieu.ToString(), ngayLap, tenSV, soTien))
                        {
                            f.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(r.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lập phiếu thu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CapNhatTrangThaiNut();
            }
        }

        //>Đưa giao diện về trạng thái chưa tra cứu.
        private void ResetGiaoDien()
        {
            _daTraCuuThanhCong = false;
            _conNoHienTai = 0;
            _maSVDaTraCuu = "";
            _maHKDaTraCuu = "";

            lblHoTen.Text = "...";
            lblTongTC.Text = "0";
            lblPhaiThu.Text = "0 đ";
            lblDaThu.Text = "0 đ";
            lblConNo.Text = "0 đ";

            nudSoTienThu.Maximum = MAX_TIEN_MAC_DINH;
            nudSoTienThu.Value = 0;
            XoaQR();
            CapNhatTrangThaiNut();

        }

        //Chỉ bật nút Lập phiếu khi có quyền, đã tra cứu thành công và còn nợ
        private void CapNhatTrangThaiNut()
        {
            btnLapPhieu.Enabled = _coQuyenThu && _daTraCuuThanhCong && _conNoHienTai > 0;
        }


        // Thông tin tài khoản nhận tiền hiện trên màn hình.
        // PHẢI khớp với tài khoản mà VietQrHelper đang dùng để tạo QR: sửa lại cho đúng.
        private string ThongTinTaiKhoan()
        {
            return "SO_TAI_KHOAN - TEN_CHU_TAI_KHOAN - NGAN_HANG";
        }

        // Tạo QR cho số tiền đang nhập. Không hợp lệ thì chỉ xóa QR, không hiện hộp thoại.
        private async void TaiQR()
        {
            decimal soTien = nudSoTienThu.Value;
            if (!_daTraCuuThanhCong || _conNoHienTai <= 0 || soTien <= 0 || soTien > _conNoHienTai)
            {
                XoaQR();
                return;
            }

            XoaQR();   // xóa QR cũ và tăng mã yêu cầu để bỏ qua kết quả của lần gọi trước
            int id = _qrRequestId;
            string noiDung = VietQrHelper.TaoNoiDung(_maSVDaTraCuu, _maHKDaTraCuu);
            lblTaiKhoan.Text = "Tài khoản: " + ThongTinTaiKhoan();
            lblNoiDung.Text = "Nội dung CK: " + noiDung;

            try
            {
                Image img = await VietQrHelper.TaiQrAsync(soTien, noiDung);
                if (id != _qrRequestId || IsDisposed) { img.Dispose(); return; }
                if (picQR.Image != null) picQR.Image.Dispose();
                picQR.Image = img;
            }
            catch (Exception)
            {
                // Không có mạng: vẫn còn tài khoản và nội dung để chuyển khoản tay.
                if (id == _qrRequestId && !IsDisposed)
                    lblNoiDung.Text += "  (không tải được QR, kiểm tra mạng)";
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}