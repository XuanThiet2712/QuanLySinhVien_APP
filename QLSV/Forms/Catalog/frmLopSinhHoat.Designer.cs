namespace QLSV.Forms.Catalog
{
    partial class frmLopSinhHoat
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.cboLocNganh = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(110, 439);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(302, 439);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 45);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(494, 439);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(686, 439);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(99, 45);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // txtMaLop
            // 
            this.txtMaLop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMaLop.Location = new System.Drawing.Point(91, 21);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(120, 22);
            this.txtMaLop.TabIndex = 4;
            // 
            // txtNienKhoa
            // 
            this.txtNienKhoa.Location = new System.Drawing.Point(697, 21);
            this.txtNienKhoa.Name = "txtNienKhoa";
            this.txtNienKhoa.Size = new System.Drawing.Size(185, 22);
            this.txtNienKhoa.TabIndex = 5;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(315, 21);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(261, 22);
            this.txtTenLop.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(597, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Niên khóa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngành trực thuộc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(390, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lớp sinh hoạt theo Ngành";
            // 
            // dgvLop
            // 
            this.dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLop.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvLop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLop.Location = new System.Drawing.Point(14, 127);
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.RowTemplate.Height = 24;
            this.dgvLop.Size = new System.Drawing.Size(870, 287);
            this.dgvLop.TabIndex = 12;
            // 
            // cboNganh
            // 
            this.cboNganh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboNganh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(164, 69);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(200, 24);
            this.cboNganh.TabIndex = 13;
            // 
            // cboLocNganh
            // 
            this.cboLocNganh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboLocNganh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboLocNganh.FormattingEnabled = true;
            this.cboLocNganh.Location = new System.Drawing.Point(600, 69);
            this.cboLocNganh.Name = "cboLocNganh";
            this.cboLocNganh.Size = new System.Drawing.Size(200, 24);
            this.cboLocNganh.TabIndex = 14;
            this.cboLocNganh.SelectedIndexChanged += new System.EventHandler(this.cboLocNganh_SelectedIndexChanged);
            // 
            // frmLopSinhHoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::QLSV.Properties.Resources.abstract_background_with_soft_gradient_color_and_dynamic_shadow_on_background_background_for_wallpaper_eps_10_free_vector;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.cboLocNganh);
            this.Controls.Add(this.cboNganh);
            this.Controls.Add(this.dgvLop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.txtNienKhoa);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLopSinhHoat";
            this.Text = "LopSinhHoat";
            this.Load += new System.EventHandler(this.frmLopSinhHoat_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.ComboBox cboLocNganh;
    }
}