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
            this.dgvDaDK = new System.Windows.Forms.DataGridView();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuyDK = new System.Windows.Forms.Button();
            this.gbLopMo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMo)).BeginInit();
            this.gbDaDK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sinh viên :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Học kỳ : ";
            // 
            // lblTinChi
            // 
            this.lblTinChi.AutoSize = true;
            this.lblTinChi.Location = new System.Drawing.Point(42, 70);
            this.lblTinChi.Name = "lblTinChi";
            this.lblTinChi.Size = new System.Drawing.Size(124, 16);
            this.lblTinChi.TabIndex = 2;
            this.lblTinChi.Text = "Đã đăng ký: 0 tín chỉ";
            // 
            // cboHocKy
            // 
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(412, 40);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(137, 24);
            this.cboHocKy.TabIndex = 3;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(148, 42);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(76, 22);
            this.txtMaSV.TabIndex = 4;
            // 
            // btnTai
            // 
            this.btnTai.Location = new System.Drawing.Point(613, 21);
            this.btnTai.Name = "btnTai";
            this.btnTai.Size = new System.Drawing.Size(106, 65);
            this.btnTai.TabIndex = 5;
            this.btnTai.Text = "XEM";
            this.btnTai.UseVisualStyleBackColor = true;
            // 
            // gbLopMo
            // 
            this.gbLopMo.Controls.Add(this.dgvLopMo);
            this.gbLopMo.Location = new System.Drawing.Point(12, 100);
            this.gbLopMo.Name = "gbLopMo";
            this.gbLopMo.Size = new System.Drawing.Size(776, 176);
            this.gbLopMo.TabIndex = 6;
            this.gbLopMo.TabStop = false;
            this.gbLopMo.Text = "Lớp học phần đang mở";
            // 
            // dgvLopMo
            // 
            this.dgvLopMo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopMo.Location = new System.Drawing.Point(3, 18);
            this.dgvLopMo.Name = "dgvLopMo";
            this.dgvLopMo.RowHeadersWidth = 51;
            this.dgvLopMo.RowTemplate.Height = 24;
            this.dgvLopMo.Size = new System.Drawing.Size(770, 155);
            this.dgvLopMo.TabIndex = 7;
            // 
            // gbDaDK
            // 
            this.gbDaDK.Controls.Add(this.dgvDaDK);
            this.gbDaDK.Location = new System.Drawing.Point(15, 321);
            this.gbDaDK.Name = "gbDaDK";
            this.gbDaDK.Size = new System.Drawing.Size(776, 176);
            this.gbDaDK.TabIndex = 8;
            this.gbDaDK.TabStop = false;
            this.gbDaDK.Text = "Lớp học phần đang mở";
            // 
            // dgvDaDK
            // 
            this.dgvDaDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaDK.Location = new System.Drawing.Point(3, 18);
            this.dgvDaDK.Name = "dgvDaDK";
            this.dgvDaDK.RowHeadersWidth = 51;
            this.dgvDaDK.RowTemplate.Height = 24;
            this.dgvDaDK.Size = new System.Drawing.Size(770, 155);
            this.dgvDaDK.TabIndex = 7;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(753, 29);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(106, 65);
            this.btnDangKy.TabIndex = 9;
            this.btnDangKy.Text = "DANG ky";
            this.btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnHuyDK
            // 
            this.btnHuyDK.Location = new System.Drawing.Point(823, 134);
            this.btnHuyDK.Name = "btnHuyDK";
            this.btnHuyDK.Size = new System.Drawing.Size(65, 60);
            this.btnHuyDK.TabIndex = 10;
            this.btnHuyDK.Text = "Huy DK";
            this.btnHuyDK.UseVisualStyleBackColor = true;
            // 
            // frmDangKyHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 509);
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
            this.Name = "frmDangKyHocPhan";
            this.Text = "Đăng ký học phần";
            this.gbLopMo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMo)).EndInit();
            this.gbDaDK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDK)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvDaDK;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuyDK;
    }
}