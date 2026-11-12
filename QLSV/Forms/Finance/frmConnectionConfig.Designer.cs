namespace QLSV.Forms.Finance
{
    partial class frmConnectionConfig
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rdoWindowsAuth = new System.Windows.Forms.RadioButton();
            this.rdoSqlAuth = new System.Windows.Forms.RadioButton();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(92, 88);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(179, 22);
            this.txtServer.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(91, 143);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(179, 22);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(92, 213);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 22);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(92, 272);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(179, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // rdoWindowsAuth
            // 
            this.rdoWindowsAuth.AutoSize = true;
            this.rdoWindowsAuth.Checked = true;
            this.rdoWindowsAuth.Location = new System.Drawing.Point(356, 115);
            this.rdoWindowsAuth.Name = "rdoWindowsAuth";
            this.rdoWindowsAuth.Size = new System.Drawing.Size(136, 20);
            this.rdoWindowsAuth.TabIndex = 5;
            this.rdoWindowsAuth.TabStop = true;
            this.rdoWindowsAuth.Text = "Xác thực Windows";
            this.rdoWindowsAuth.UseVisualStyleBackColor = true;
            this.rdoWindowsAuth.Click += new System.EventHandler(this.rdoWindowsAuth_CheckedChanged);
            // 
            // rdoSqlAuth
            // 
            this.rdoSqlAuth.AutoSize = true;
            this.rdoSqlAuth.Location = new System.Drawing.Point(356, 186);
            this.rdoSqlAuth.Name = "rdoSqlAuth";
            this.rdoSqlAuth.Size = new System.Drawing.Size(150, 20);
            this.rdoSqlAuth.TabIndex = 6;
            this.rdoSqlAuth.Text = "Xác thực SQL Server";
            this.rdoSqlAuth.UseVisualStyleBackColor = true;
            this.rdoSqlAuth.CheckedChanged += new System.EventHandler(this.rdoWindowsAuth_CheckedChanged);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(574, 88);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(140, 74);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Kết nối";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(574, 216);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(140, 72);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sever:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "User ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password:";
            // 
            // frmConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 377);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.rdoSqlAuth);
            this.Controls.Add(this.rdoWindowsAuth);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.MaximizeBox = false;
            this.Name = "frmConnectionConfig";
            this.Text = "frmConnectionConfig";
            this.Load += new System.EventHandler(this.frmConnectionConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RadioButton rdoWindowsAuth;
        private System.Windows.Forms.RadioButton rdoSqlAuth;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}