namespace QLSV.Forms.Finance
{
    partial class frmThongKeDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(150, 12);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 22);
            this.dtpTuNgay.TabIndex = 0;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(434, 12);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(114, 22);
            this.dtpDenNgay.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(695, 148);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(174, 100);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Xem thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(37, 40);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(622, 282);
            this.dgvDoanhThu.TabIndex = 3;
            // 
            // chartDoanhThu
            // 
            chartArea8.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend8);
            this.chartDoanhThu.Location = new System.Drawing.Point(37, 344);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartDoanhThu.Series.Add(series8);
            this.chartDoanhThu.Size = new System.Drawing.Size(511, 225);
            this.chartDoanhThu.TabIndex = 4;
            this.chartDoanhThu.Text = "chart1";
            this.chartDoanhThu.Click += new System.EventHandler(this.chartDoanhThu_Click);
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.Red;
            this.lblTongCong.Location = new System.Drawing.Point(609, 524);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(118, 17);
            this.lblTongCong.TabIndex = 5;
            this.lblTongCong.Text = "Tổng cộng: 0 đ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(112, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(385, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến:";
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 581);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKeDoanhThu";
            this.Text = "frmThongKeDoanhThu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}