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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu mới";
            // 
            // txtCu
            // 
            this.txtCu.Location = new System.Drawing.Point(245, 36);
            this.txtCu.Name = "txtCu";
            this.txtCu.Size = new System.Drawing.Size(215, 22);
            this.txtCu.TabIndex = 3;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(245, 196);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(215, 22);
            this.txtNhapLai.TabIndex = 4;
            // 
            // txtMoi
            // 
            this.txtMoi.Location = new System.Drawing.Point(245, 116);
            this.txtMoi.Name = "txtMoi";
            this.txtMoi.Size = new System.Drawing.Size(215, 22);
            this.txtMoi.TabIndex = 5;
            // 
            // btnDoi
            // 
            this.btnDoi.Location = new System.Drawing.Point(155, 288);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(165, 96);
            this.btnDoi.TabIndex = 6;
            this.btnDoi.Text = "Đổi";
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(460, 288);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(165, 96);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Huy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.txtMoi);
            this.Controls.Add(this.txtNhapLai);
            this.Controls.Add(this.txtCu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}