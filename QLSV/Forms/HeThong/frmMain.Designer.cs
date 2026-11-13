namespace QLSV.Forms.HeThong
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNganh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLopSinhHoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHocKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHocVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLopHocPhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyHocPhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiChinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuHocPhi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBieuDo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.inDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuyenCuaToi = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuHocVu,
            this.mnuTaiChinh,
            this.mnuBaoCao,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMatKhau,
            this.mnuQuanLyNguoiDung,
            this.mnuPhanQuyen,
            this.mnuCauHinh,
            this.toolStripSeparator1,
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(88, 26);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(245, 26);
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuQuanLyNguoiDung
            // 
            this.mnuQuanLyNguoiDung.Name = "mnuQuanLyNguoiDung";
            this.mnuQuanLyNguoiDung.Size = new System.Drawing.Size(245, 26);
            this.mnuQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.mnuQuanLyNguoiDung.Click += new System.EventHandler(this.mnuQuanLyNguoiDung_Click);
            // 
            // mnuPhanQuyen
            // 
            this.mnuPhanQuyen.Name = "mnuPhanQuyen";
            this.mnuPhanQuyen.Size = new System.Drawing.Size(245, 26);
            this.mnuPhanQuyen.Text = "Phân quyền";
            this.mnuPhanQuyen.Click += new System.EventHandler(this.mnuPhanQuyen_Click);
            // 
            // mnuCauHinh
            // 
            this.mnuCauHinh.Name = "mnuCauHinh";
            this.mnuCauHinh.Size = new System.Drawing.Size(245, 26);
            this.mnuCauHinh.Text = "Cấu hình kết nối CSDL";
            this.mnuCauHinh.Click += new System.EventHandler(this.mnuCauHinh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(245, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(245, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhoa,
            this.mnuNganh,
            this.mnuLopSinhHoat,
            this.mnuSinhVien,
            this.mnuGiangVien,
            this.mnuMonHoc,
            this.mnuHocKy});
            this.mnuDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(94, 26);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuKhoa
            // 
            this.mnuKhoa.Name = "mnuKhoa";
            this.mnuKhoa.Size = new System.Drawing.Size(224, 26);
            this.mnuKhoa.Text = "Khoa";
            this.mnuKhoa.Click += new System.EventHandler(this.mnuKhoa_Click);
            // 
            // mnuNganh
            // 
            this.mnuNganh.Name = "mnuNganh";
            this.mnuNganh.Size = new System.Drawing.Size(224, 26);
            this.mnuNganh.Text = "Ngành";
            this.mnuNganh.Click += new System.EventHandler(this.mnuNganh_Click);
            // 
            // mnuLopSinhHoat
            // 
            this.mnuLopSinhHoat.Name = "mnuLopSinhHoat";
            this.mnuLopSinhHoat.Size = new System.Drawing.Size(224, 26);
            this.mnuLopSinhHoat.Text = "Lớp sinh hoạt";
            this.mnuLopSinhHoat.Click += new System.EventHandler(this.mnuLopSinhHoat_Click);
            // 
            // mnuSinhVien
            // 
            this.mnuSinhVien.Name = "mnuSinhVien";
            this.mnuSinhVien.Size = new System.Drawing.Size(224, 26);
            this.mnuSinhVien.Text = "Sinh viên";
            this.mnuSinhVien.Click += new System.EventHandler(this.mnuSinhVien_Click);
            // 
            // mnuGiangVien
            // 
            this.mnuGiangVien.Name = "mnuGiangVien";
            this.mnuGiangVien.Size = new System.Drawing.Size(224, 26);
            this.mnuGiangVien.Text = "Giảng viên";
            this.mnuGiangVien.Click += new System.EventHandler(this.mnuGiangVien_Click);
            // 
            // mnuMonHoc
            // 
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Size = new System.Drawing.Size(224, 26);
            this.mnuMonHoc.Text = "Môn học";
            this.mnuMonHoc.Click += new System.EventHandler(this.mnuMonHoc_Click);
            // 
            // mnuHocKy
            // 
            this.mnuHocKy.Name = "mnuHocKy";
            this.mnuHocKy.Size = new System.Drawing.Size(224, 26);
            this.mnuHocKy.Text = "Học kỳ";
            this.mnuHocKy.Click += new System.EventHandler(this.mnuHocKy_Click);
            // 
            // mnuHocVu
            // 
            this.mnuHocVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLopHocPhan,
            this.mnuDangKyHocPhan,
            this.mnuNhapDiem});
            this.mnuHocVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHocVu.Name = "mnuHocVu";
            this.mnuHocVu.Size = new System.Drawing.Size(71, 26);
            this.mnuHocVu.Text = "Học vụ";
            // 
            // mnuLopHocPhan
            // 
            this.mnuLopHocPhan.Name = "mnuLopHocPhan";
            this.mnuLopHocPhan.Size = new System.Drawing.Size(224, 26);
            this.mnuLopHocPhan.Text = "Lớp học phần";
            this.mnuLopHocPhan.Click += new System.EventHandler(this.mnuLopHocPhan_Click);
            // 
            // mnuDangKyHocPhan
            // 
            this.mnuDangKyHocPhan.Name = "mnuDangKyHocPhan";
            this.mnuDangKyHocPhan.Size = new System.Drawing.Size(224, 26);
            this.mnuDangKyHocPhan.Text = "Đăng ký học phần";
            this.mnuDangKyHocPhan.Click += new System.EventHandler(this.mnuDangKyHocPhan_Click);
            // 
            // mnuNhapDiem
            // 
            this.mnuNhapDiem.Name = "mnuNhapDiem";
            this.mnuNhapDiem.Size = new System.Drawing.Size(224, 26);
            this.mnuNhapDiem.Text = "Nhập điểm";
            this.mnuNhapDiem.Click += new System.EventHandler(this.mnuNhapDiem_Click);
            // 
            // mnuTaiChinh
            // 
            this.mnuTaiChinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThuHocPhi});
            this.mnuTaiChinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTaiChinh.Name = "mnuTaiChinh";
            this.mnuTaiChinh.Size = new System.Drawing.Size(85, 26);
            this.mnuTaiChinh.Text = "Tài chính";
            // 
            // mnuThuHocPhi
            // 
            this.mnuThuHocPhi.Name = "mnuThuHocPhi";
            this.mnuThuHocPhi.Size = new System.Drawing.Size(224, 26);
            this.mnuThuHocPhi.Text = "Thu học phí";
            this.mnuThuHocPhi.Click += new System.EventHandler(this.mnuThuHocPhi_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBangDiem,
            this.mnuBieuDo,
            this.mnuBaoCaoDoanhThu,
            this.inDoanhThuToolStripMenuItem});
            this.mnuBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(164, 26);
            this.mnuBaoCao.Text = "Báo cáo và thống kê";
            // 
            // mnuBangDiem
            // 
            this.mnuBangDiem.Name = "mnuBangDiem";
            this.mnuBangDiem.Size = new System.Drawing.Size(224, 26);
            this.mnuBangDiem.Text = "Bảng điểm";
            this.mnuBangDiem.Click += new System.EventHandler(this.mnuBangDiem_Click);
            // 
            // mnuBieuDo
            // 
            this.mnuBieuDo.Name = "mnuBieuDo";
            this.mnuBieuDo.Size = new System.Drawing.Size(224, 26);
            this.mnuBieuDo.Text = "Biểu đồ thống kê";
            this.mnuBieuDo.Click += new System.EventHandler(this.mnuBieuDo_Click);
            // 
            // mnuBaoCaoDoanhThu
            // 
            this.mnuBaoCaoDoanhThu.Name = "mnuBaoCaoDoanhThu";
            this.mnuBaoCaoDoanhThu.Size = new System.Drawing.Size(224, 26);
            this.mnuBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            this.mnuBaoCaoDoanhThu.Click += new System.EventHandler(this.mnuBaoCaoDoanhThu_Click);
            // 
            // inDoanhThuToolStripMenuItem
            // 
            this.inDoanhThuToolStripMenuItem.Name = "inDoanhThuToolStripMenuItem";
            this.inDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.inDoanhThuToolStripMenuItem.Text = "In Doanh Thu";
            this.inDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.inDoanhThuToolStripMenuItem_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuyenCuaToi});
            this.mnuTroGiup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(81, 26);
            this.mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuQuyenCuaToi
            // 
            this.mnuQuyenCuaToi.Name = "mnuQuyenCuaToi";
            this.mnuQuyenCuaToi.Size = new System.Drawing.Size(224, 26);
            this.mnuQuyenCuaToi.Text = "Quyền của tôi";
            this.mnuQuyenCuaToi.Click += new System.EventHandler(this.mnuQuyenCuaToi_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1082, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(151, 20);
            this.lblNguoiDung.Text = "toolStripStatusLabel1";
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanQuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoa;
        private System.Windows.Forms.ToolStripMenuItem mnuNganh;
        private System.Windows.Forms.ToolStripMenuItem mnuLopSinhHoat;
        private System.Windows.Forms.ToolStripMenuItem mnuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuGiangVien;
        private System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuHocVu;
        private System.Windows.Forms.ToolStripMenuItem mnuLopHocPhan;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyHocPhan;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuThuHocPhi;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuQuyenCuaToi;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBieuDo;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoDoanhThu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;

        private System.Windows.Forms.ToolStripMenuItem inDoanhThuToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem mnuHocKy;

    }
}