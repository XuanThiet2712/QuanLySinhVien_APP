namespace QLSV.Forms.Report
{
    partial class frmNhapDiem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLopHocPhan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvNhapDiem = new System.Windows.Forms.DataGridView();
            this.colSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý nhập điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn lớp học phần";
            // 
            // cboLopHocPhan
            // 
            this.cboLopHocPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHocPhan.DropDownWidth = 350;
            this.cboLopHocPhan.FormattingEnabled = true;
            this.cboLopHocPhan.Location = new System.Drawing.Point(39, 110);
            this.cboLopHocPhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLopHocPhan.Name = "cboLopHocPhan";
            this.cboLopHocPhan.Size = new System.Drawing.Size(491, 24);
            this.cboLopHocPhan.TabIndex = 2;
            this.cboLopHocPhan.SelectedIndexChanged += new System.EventHandler(this.cboLopHocPhan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Danh sách điểm sinh viên";
            // 
            // dgvNhapDiem
            // 
            this.dgvNhapDiem.AllowUserToAddRows = false;
            this.dgvNhapDiem.AllowUserToDeleteRows = false;
            this.dgvNhapDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhapDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhapDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSV,
            this.colHoTen,
            this.colCC,
            this.colGK,
            this.colCK,
            this.colTK,
            this.colChu,
            this.colHe4});
            this.dgvNhapDiem.Location = new System.Drawing.Point(38, 185);
            this.dgvNhapDiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNhapDiem.MultiSelect = false;
            this.dgvNhapDiem.Name = "dgvNhapDiem";
            this.dgvNhapDiem.RowHeadersVisible = false;
            this.dgvNhapDiem.RowHeadersWidth = 51;
            this.dgvNhapDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNhapDiem.Size = new System.Drawing.Size(977, 293);
            this.dgvNhapDiem.TabIndex = 4;
            this.dgvNhapDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapDiem_CellContentClick);
            this.dgvNhapDiem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapDiem_CellEndEdit);
            this.dgvNhapDiem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvNhapDiem_CellValidating);
            this.dgvNhapDiem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNhapDiem_DataError);
            // 
            // colSV
            // 
            this.colSV.DataPropertyName = "MaSV";
            this.colSV.HeaderText = "MSSV";
            this.colSV.MinimumWidth = 6;
            this.colSV.Name = "colSV";
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            // 
            // colCC
            // 
            this.colCC.DataPropertyName = "DiemCC";
            this.colCC.HeaderText = "CC";
            this.colCC.MinimumWidth = 6;
            this.colCC.Name = "colCC";
            // 
            // colGK
            // 
            this.colGK.DataPropertyName = "DiemGK";
            this.colGK.HeaderText = "GK";
            this.colGK.MinimumWidth = 6;
            this.colGK.Name = "colGK";
            // 
            // colCK
            // 
            this.colCK.DataPropertyName = "DiemCK";
            this.colCK.HeaderText = "CK";
            this.colCK.MinimumWidth = 6;
            this.colCK.Name = "colCK";
            // 
            // colTK
            // 
            this.colTK.DataPropertyName = "DiemTongKet";
            this.colTK.HeaderText = "Tổng kết";
            this.colTK.MinimumWidth = 6;
            this.colTK.Name = "colTK";
            // 
            // colChu
            // 
            this.colChu.DataPropertyName = "DiemChu";
            this.colChu.HeaderText = "Điểm chữ";
            this.colChu.MinimumWidth = 6;
            this.colChu.Name = "colChu";
            // 
            // colHe4
            // 
            this.colHe4.DataPropertyName = "Diem4";
            this.colHe4.HeaderText = "Hệ 4";
            this.colHe4.MinimumWidth = 6;
            this.colHe4.Name = "colHe4";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(38, 486);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 28);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu điểm";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Location = new System.Drawing.Point(170, 486);
            this.btnLichSu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(136, 28);
            this.btnLichSu.TabIndex = 6;
            this.btnLichSu.Text = "Lịch sử sửa điểm";
            this.btnLichSu.UseVisualStyleBackColor = true;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(337, 486);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 28);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvNhapDiem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboLopHocPhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmNhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhập điểm sinh viên";
            this.Load += new System.EventHandler(this.frmNhapDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLopHocPhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvNhapDiem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHe4;
    }
}