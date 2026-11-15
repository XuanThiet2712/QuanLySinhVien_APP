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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend25 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend26 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea27 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend27 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea28 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend28 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopMon)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartKhoa
            // 
            chartArea25.Name = "ChartArea1";
            this.chartKhoa.ChartAreas.Add(chartArea25);
            this.chartKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            legend25.Name = "Legend1";
            this.chartKhoa.Legends.Add(legend25);
            this.chartKhoa.Location = new System.Drawing.Point(0, 0);
            this.chartKhoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartKhoa.Name = "chartKhoa";
            series25.ChartArea = "ChartArea1";
            series25.Legend = "Legend1";
            series25.Name = "Series1";
            this.chartKhoa.Series.Add(series25);
            this.chartKhoa.Size = new System.Drawing.Size(722, 250);
            this.chartKhoa.TabIndex = 0;
            this.chartKhoa.Text = "chart1";
            // 
            // chartDoanhThu
            // 
            chartArea26.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea26);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend26.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend26);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series26.ChartArea = "ChartArea1";
            series26.Legend = "Legend1";
            series26.Name = "Series1";
            this.chartDoanhThu.Series.Add(series26);
            this.chartDoanhThu.Size = new System.Drawing.Size(722, 250);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart2";
            // 
            // nudNam
            // 
            this.nudNam.Location = new System.Drawing.Point(79, 30);
            this.nudNam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudNam.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNam.Name = "nudNam";
            this.nudNam.Size = new System.Drawing.Size(161, 20);
            this.nudNam.TabIndex = 2;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(528, 92);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(161, 35);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "⌕  Lọc dữ liệu";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboLoaiBieuDo
            // 
            this.cboLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBieuDo.FormattingEnabled = true;
            this.cboLoaiBieuDo.Items.AddRange(new object[] {
            "Số lượng sinh viên theo Khoa",
            "Doanh thu học phí 12 tháng",
            "Tỉ lệ xếp loại học lực",
            "Top 5 môn học đông nhất"});
            this.cboLoaiBieuDo.Location = new System.Drawing.Point(118, 67);
            this.cboLoaiBieuDo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboLoaiBieuDo.Name = "cboLoaiBieuDo";
            this.cboLoaiBieuDo.Size = new System.Drawing.Size(293, 21);
            this.cboLoaiBieuDo.TabIndex = 4;
            this.cboLoaiBieuDo.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBieuDo_SelectedIndexChanged);
            // 
            // chartHocLuc
            // 
            chartArea27.Name = "ChartArea1";
            this.chartHocLuc.ChartAreas.Add(chartArea27);
            this.chartHocLuc.Dock = System.Windows.Forms.DockStyle.Fill;
            legend27.Name = "Legend1";
            this.chartHocLuc.Legends.Add(legend27);
            this.chartHocLuc.Location = new System.Drawing.Point(0, 0);
            this.chartHocLuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartHocLuc.Name = "chartHocLuc";
            series27.ChartArea = "ChartArea1";
            series27.Legend = "Legend1";
            series27.Name = "Series1";
            this.chartHocLuc.Series.Add(series27);
            this.chartHocLuc.Size = new System.Drawing.Size(722, 250);
            this.chartHocLuc.TabIndex = 5;
            this.chartHocLuc.Text = "chart2";
            // 
            // chartTopMon
            // 
            chartArea28.Name = "ChartArea1";
            this.chartTopMon.ChartAreas.Add(chartArea28);
            this.chartTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            legend28.Name = "Legend1";
            this.chartTopMon.Legends.Add(legend28);
            this.chartTopMon.Location = new System.Drawing.Point(0, 0);
            this.chartTopMon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartTopMon.Name = "chartTopMon";
            series28.ChartArea = "ChartArea1";
            series28.Legend = "Legend1";
            series28.Name = "Series1";
            this.chartTopMon.Series.Add(series28);
            this.chartTopMon.Size = new System.Drawing.Size(722, 250);
            this.chartTopMon.TabIndex = 6;
            this.chartTopMon.Text = "chart2";
            this.chartTopMon.Click += new System.EventHandler(this.chartTopMon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Năm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(332, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Học kỳ:";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "HK1",
            "HK2",
            "HK3"});
            this.cboHocKy.Location = new System.Drawing.Point(387, 35);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(202, 21);
            this.cboHocKy.TabIndex = 10;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chartTopMon);
            this.panel1.Controls.Add(this.chartKhoa);
            this.panel1.Controls.Add(this.chartDoanhThu);
            this.panel1.Controls.Add(this.chartHocLuc);
            this.panel1.Location = new System.Drawing.Point(20, 160);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 252);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboHocKy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboLoaiBieuDo);
            this.groupBox1.Controls.Add(this.btnLoc);
            this.groupBox1.Controls.Add(this.nudNam);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 132);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ lọc thống kê";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Loại biểu đồ :";
            // 
            // frmBieuDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmBieuDo";
            this.Text = "frmChartDashboard";
            this.Load += new System.EventHandler(this.frmChartDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopMon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}