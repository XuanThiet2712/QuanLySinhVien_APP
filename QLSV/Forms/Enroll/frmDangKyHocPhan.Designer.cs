namespace QLSV.Forms.Enroll
{
    partial class frmDangKyHocPhan
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
            this.lblTinChi = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.btnTai = new System.Windows.Forms.Button();
            this.gbLopMo = new System.Windows.Forms.GroupBox();
            this.dgvLopMo = new System.Windows.Forms.DataGridView();
            this.gbDaDK = new System.Windows.Forms.GroupBox();
            this.dgvDaDangKy = new System.Windows.Forms.DataGridView();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuyDK = new System.Windows.Forms.Button();
            this.gbLopMo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMo)).BeginInit();
            this.gbDaDK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Học kỳ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTinChi
            // 
            this.lblTinChi.AutoSize = true;
            this.lblTinChi.BackColor = System.Drawing.SystemColors.Control;
            this.lblTinChi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTinChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinChi.Location = new System.Drawing.Point(524, 18);
            this.lblTinChi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTinChi.Name = "lblTinChi";
            this.lblTinChi.Size = new System.Drawing.Size(131, 15);
            this.lblTinChi.TabIndex = 2;
            this.lblTinChi.Text = "Đã đăng ký: 0 tín chỉ";
            // 
            // cboHocKy
            // 
            this.cboHocKy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(341, 13);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(154, 21);
            this.cboHocKy.TabIndex = 3;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(111, 11);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(146, 20);
            this.txtMaSV.TabIndex = 4;
            this.txtMaSV.TextChanged += new System.EventHandler(this.txtMaSV_TextChanged);
            // 
            // btnTai
            // 
            this.btnTai.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTai.Location = new System.Drawing.Point(446, 391);
            this.btnTai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTai.Name = "btnTai";
            this.btnTai.Size = new System.Drawing.Size(74, 37);
            this.btnTai.TabIndex = 5;
            this.btnTai.Text = "Xem";
            this.btnTai.UseVisualStyleBackColor = false;
            this.btnTai.Click += new System.EventHandler(this.btnTai_Click);
            // 
            // gbLopMo
            // 
            this.gbLopMo.Controls.Add(this.dgvLopMo);
            this.gbLopMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLopMo.Location = new System.Drawing.Point(26, 64);
            this.gbLopMo.Margin = new System.Windows.Forms.Padding(2);
            this.gbLopMo.Name = "gbLopMo";
            this.gbLopMo.Padding = new System.Windows.Forms.Padding(2);
            this.gbLopMo.Size = new System.Drawing.Size(748, 160);
            this.gbLopMo.TabIndex = 6;
            this.gbLopMo.TabStop = false;
            this.gbLopMo.Text = "Lớp học phần đang mở";
            // 
            // dgvLopMo
            // 
            this.dgvLopMo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopMo.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvLopMo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLopMo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopMo.Location = new System.Drawing.Point(2, 14);
            this.dgvLopMo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLopMo.Name = "dgvLopMo";
            this.dgvLopMo.ReadOnly = true;
            this.dgvLopMo.RowHeadersWidth = 51;
            this.dgvLopMo.RowTemplate.Height = 24;
            this.dgvLopMo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopMo.Size = new System.Drawing.Size(744, 144);
            this.dgvLopMo.TabIndex = 7;
            this.dgvLopMo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLopMo_CellContentClick);
            // 
            // gbDaDK
            // 
            this.gbDaDK.Controls.Add(this.dgvDaDangKy);
            this.gbDaDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDaDK.Location = new System.Drawing.Point(26, 242);
            this.gbDaDK.Margin = new System.Windows.Forms.Padding(2);
            this.gbDaDK.Name = "gbDaDK";
            this.gbDaDK.Padding = new System.Windows.Forms.Padding(2);
            this.gbDaDK.Size = new System.Drawing.Size(748, 145);
            this.gbDaDK.TabIndex = 8;
            this.gbDaDK.TabStop = false;
            this.gbDaDK.Text = "Lớp học phần đã đăng ký";
            // 
            // dgvDaDangKy
            // 
            this.dgvDaDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaDangKy.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDaDangKy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDaDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaDangKy.Location = new System.Drawing.Point(2, 14);
            this.dgvDaDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDaDangKy.Name = "dgvDaDangKy";
            this.dgvDaDangKy.ReadOnly = true;
            this.dgvDaDangKy.RowHeadersWidth = 51;
            this.dgvDaDangKy.RowTemplate.Height = 24;
            this.dgvDaDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaDangKy.Size = new System.Drawing.Size(744, 129);
            this.dgvDaDangKy.TabIndex = 7;
            this.dgvDaDangKy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDaDangKy_CellContentClick);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(556, 389);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(74, 37);
            this.btnDangKy.TabIndex = 9;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnHuyDK
            // 
            this.btnHuyDK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHuyDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDK.Location = new System.Drawing.Point(655, 389);
            this.btnHuyDK.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyDK.Name = "btnHuyDK";
            this.btnHuyDK.Size = new System.Drawing.Size(115, 37);
            this.btnHuyDK.TabIndex = 10;
            this.btnHuyDK.Text = "Hủy đăng ký";
            this.btnHuyDK.UseVisualStyleBackColor = false;
            this.btnHuyDK.Click += new System.EventHandler(this.btnHuyDK_Click);
            // 
            // frmDangKyHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 472);
            this.Controls.Add(this.btnHuyDK);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.gbDaDK);
            this.Controls.Add(this.gbLopMo);
            this.Controls.Add(this.btnTai);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.cboHocKy);
            this.Controls.Add(this.lblTinChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDangKyHocPhan";
            this.Text = "Đăng ký học phần";
            this.Load += new System.EventHandler(this.frmDangKyHocPhan_Load);
            this.gbLopMo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMo)).EndInit();
            this.gbDaDK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTinChi;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.GroupBox gbLopMo;
        private System.Windows.Forms.DataGridView dgvLopMo;
        private System.Windows.Forms.GroupBox gbDaDK;
        private System.Windows.Forms.DataGridView dgvDaDangKy;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuyDK;
    }
}