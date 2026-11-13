namespace QLSV.Forms.Finance
{
    partial class frmBieuDo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartKhoa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nudNam = new System.Windows.Forms.NumericUpDown();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.chartHocLuc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopMon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopMon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartKhoa
            // 
            chartArea9.Name = "ChartArea1";
            this.chartKhoa.ChartAreas.Add(chartArea9);
            this.chartKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend1";
            this.chartKhoa.Legends.Add(legend9);
            this.chartKhoa.Location = new System.Drawing.Point(0, 0);
            this.chartKhoa.Name = "chartKhoa";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chartKhoa.Series.Add(series9);
            this.chartKhoa.Size = new System.Drawing.Size(813, 427);
            this.chartKhoa.TabIndex = 0;
            this.chartKhoa.Text = "chart1";
            // 
            // chartDoanhThu
            // 
            chartArea10.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea10);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend10.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend10);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chartDoanhThu.Series.Add(series10);
            this.chartDoanhThu.Size = new System.Drawing.Size(813, 427);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart2";
            // 
            // nudNam
            // 
            this.nudNam.Location = new System.Drawing.Point(120, 14);
            this.nudNam.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNam.Name = "nudNam";
            this.nudNam.Size = new System.Drawing.Size(131, 22);
            this.nudNam.TabIndex = 2;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(631, 44);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(99, 45);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboLoaiBieuDo
            // 
            this.cboLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBieuDo.FormattingEnabled = true;
            this.cboLoaiBieuDo.Location = new System.Drawing.Point(398, 12);
            this.cboLoaiBieuDo.Name = "cboLoaiBieuDo";
            this.cboLoaiBieuDo.Size = new System.Drawing.Size(200, 24);
            this.cboLoaiBieuDo.TabIndex = 4;
            this.cboLoaiBieuDo.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBieuDo_SelectedIndexChanged);
            // 
            // chartHocLuc
            // 
            chartArea11.Name = "ChartArea1";
            this.chartHocLuc.ChartAreas.Add(chartArea11);
            this.chartHocLuc.Dock = System.Windows.Forms.DockStyle.Fill;
            legend11.Name = "Legend1";
            this.chartHocLuc.Legends.Add(legend11);
            this.chartHocLuc.Location = new System.Drawing.Point(0, 0);
            this.chartHocLuc.Name = "chartHocLuc";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chartHocLuc.Series.Add(series11);
            this.chartHocLuc.Size = new System.Drawing.Size(813, 427);
            this.chartHocLuc.TabIndex = 5;
            this.chartHocLuc.Text = "chart2";
            // 
            // chartTopMon
            // 
            chartArea12.Name = "ChartArea1";
            this.chartTopMon.ChartAreas.Add(chartArea12);
            this.chartTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.Name = "Legend1";
            this.chartTopMon.Legends.Add(legend12);
            this.chartTopMon.Location = new System.Drawing.Point(0, 0);
            this.chartTopMon.Name = "chartTopMon";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartTopMon.Series.Add(series12);
            this.chartTopMon.Size = new System.Drawing.Size(813, 427);
            this.chartTopMon.TabIndex = 6;
            this.chartTopMon.Text = "chart2";
            this.chartTopMon.Click += new System.EventHandler(this.chartTopMon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(54, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Năm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(54, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Học kỳ:";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(120, 55);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(131, 24);
            this.cboHocKy.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chartTopMon);
            this.panel1.Controls.Add(this.chartKhoa);
            this.panel1.Controls.Add(this.chartDoanhThu);
            this.panel1.Controls.Add(this.chartHocLuc);
            this.panel1.Location = new System.Drawing.Point(57, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 429);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại biểu đồ";
            // 
            // frmBieuDo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::QLSV.Properties.Resources.abstract_background_with_soft_gradient_color_and_dynamic_shadow_on_background_background_for_wallpaper_eps_10_free_vector;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 547);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboHocKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLoaiBieuDo);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.nudNam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBieuDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu đồ";
            this.Load += new System.EventHandler(this.frmChartDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopMon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartKhoa;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.NumericUpDown nudNam;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.ComboBox cboLoaiBieuDo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHocLuc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}