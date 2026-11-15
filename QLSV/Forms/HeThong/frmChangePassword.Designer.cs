namespace QLSV.Forms.HeThong
{
    partial class frmChangePassword
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCu = new System.Windows.Forms.TextBox();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.txtMoi = new System.Windows.Forms.TextBox();
            this.btnDoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHienMatKhauCu = new System.Windows.Forms.Button();
            this.btnHienMatKhauMoi = new System.Windows.Forms.Button();
            this.btnXacNhanMatKhau = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // txtCu
            // 
            this.txtCu.Location = new System.Drawing.Point(194, 36);
            this.txtCu.Name = "txtCu";
            this.txtCu.Size = new System.Drawing.Size(203, 22);
            this.txtCu.TabIndex = 3;
            this.txtCu.UseSystemPasswordChar = true;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(194, 100);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(203, 22);
            this.txtNhapLai.TabIndex = 4;
            this.txtNhapLai.UseSystemPasswordChar = true;
            // 
            // txtMoi
            // 
            this.txtMoi.Location = new System.Drawing.Point(194, 68);
            this.txtMoi.Name = "txtMoi";
            this.txtMoi.Size = new System.Drawing.Size(205, 22);
            this.txtMoi.TabIndex = 5;
            this.txtMoi.UseSystemPasswordChar = true;
            this.txtMoi.TextChanged += new System.EventHandler(this.txtMoi_TextChanged);
            // 
            // btnDoi
            // 
            this.btnDoi.Location = new System.Drawing.Point(56, 278);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(159, 43);
            this.btnDoi.TabIndex = 6;
            this.btnDoi.Text = "Đổi mật khẩu";
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(262, 278);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 43);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Trở lại";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXacNhanMatKhau);
            this.groupBox1.Controls.Add(this.btnHienMatKhauMoi);
            this.groupBox1.Controls.Add(this.btnHienMatKhauCu);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnDoi);
            this.groupBox1.Controls.Add(this.txtMoi);
            this.groupBox1.Controls.Add(this.txtNhapLai);
            this.groupBox1.Controls.Add(this.txtCu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(280, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 359);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ĐỔI MẬT KHẨU";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(353, 100);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Hãy đặt mật khẩu:\r\n- Tối thiểu 6 ký tự\r\n- Bao gồm chữ hoa, chữ thường và số\r\n- Kh" +
    "ông được trùng với mật khẩu cũ\r\n\r\n\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLSV.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(9, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 358);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnHienMatKhauCu
            // 
            this.btnHienMatKhauCu.Location = new System.Drawing.Point(403, 28);
            this.btnHienMatKhauCu.Name = "btnHienMatKhauCu";
            this.btnHienMatKhauCu.Size = new System.Drawing.Size(40, 32);
            this.btnHienMatKhauCu.TabIndex = 9;
            this.btnHienMatKhauCu.Text = "👁";
            this.btnHienMatKhauCu.UseVisualStyleBackColor = true;
            this.btnHienMatKhauCu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHienMatKhauMoi
            // 
            this.btnHienMatKhauMoi.Location = new System.Drawing.Point(405, 62);
            this.btnHienMatKhauMoi.Name = "btnHienMatKhauMoi";
            this.btnHienMatKhauMoi.Size = new System.Drawing.Size(40, 32);
            this.btnHienMatKhauMoi.TabIndex = 10;
            this.btnHienMatKhauMoi.Text = "👁";
            this.btnHienMatKhauMoi.UseVisualStyleBackColor = true;
            this.btnHienMatKhauMoi.Click += new System.EventHandler(this.btnHienMatKhauMoi_Click);
            // 
            // btnXacNhanMatKhau
            // 
            this.btnXacNhanMatKhau.Location = new System.Drawing.Point(405, 96);
            this.btnXacNhanMatKhau.Name = "btnXacNhanMatKhau";
            this.btnXacNhanMatKhau.Size = new System.Drawing.Size(40, 32);
            this.btnXacNhanMatKhau.TabIndex = 11;
            this.btnXacNhanMatKhau.Text = "👁";
            this.btnXacNhanMatKhau.UseVisualStyleBackColor = true;
            this.btnXacNhanMatKhau.Click += new System.EventHandler(this.btnXacNhanMatKhau_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 396);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCu;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.TextBox txtMoi;
        private System.Windows.Forms.Button btnDoi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnXacNhanMatKhau;
        private System.Windows.Forms.Button btnHienMatKhauMoi;
        private System.Windows.Forms.Button btnHienMatKhauCu;
    }
}