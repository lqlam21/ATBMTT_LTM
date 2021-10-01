
namespace LeQuyLam_InfomationSecurity.Forms
{
    partial class FormHome
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btSua = new System.Windows.Forms.Button();
            this.btBaoVe = new System.Windows.Forms.Button();
            this.btDoiPass = new System.Windows.Forms.Button();
            this.timeNow = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.panelXacNhan = new System.Windows.Forms.Panel();
            this.btConfirmSecuritySecond = new System.Windows.Forms.Button();
            this.panelDoiPass = new System.Windows.Forms.Panel();
            this.btConfirmChangePass = new System.Windows.Forms.Button();
            this.tbNewPass2 = new System.Windows.Forms.TextBox();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.tbOldPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDisplayname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btEditDisplayname = new System.Windows.Forms.Button();
            this.pLoading = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.pnBgBot = new Guna.UI2.WinForms.Guna2Panel();
            this.pnBgTop = new Guna.UI2.WinForms.Guna2Panel();
            this.panelXacNhan.SuspendLayout();
            this.panelDoiPass.SuspendLayout();
            this.pnBgBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Mã khóa của bạn";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(441, 36);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(68, 25);
            this.labelStatus.TabIndex = 23;
            this.labelStatus.Text = "Status";
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKey.Location = new System.Drawing.Point(71, 186);
            this.tbKey.MaxLength = 100;
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(158, 23);
            this.tbKey.TabIndex = 2;
            // 
            // btSua
            // 
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(71, 215);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(91, 40);
            this.btSua.TabIndex = 3;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btBaoVe
            // 
            this.btBaoVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBaoVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBaoVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBaoVe.Location = new System.Drawing.Point(446, 92);
            this.btBaoVe.Name = "btBaoVe";
            this.btBaoVe.Size = new System.Drawing.Size(102, 40);
            this.btBaoVe.TabIndex = 4;
            this.btBaoVe.Text = "Tắt";
            this.btBaoVe.UseVisualStyleBackColor = true;
            this.btBaoVe.Click += new System.EventHandler(this.btBaoVe_Click);
            // 
            // btDoiPass
            // 
            this.btDoiPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDoiPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDoiPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoiPass.Location = new System.Drawing.Point(591, 93);
            this.btDoiPass.Name = "btDoiPass";
            this.btDoiPass.Size = new System.Drawing.Size(102, 40);
            this.btDoiPass.TabIndex = 5;
            this.btDoiPass.Text = "Đổi mật khẩu";
            this.btDoiPass.UseVisualStyleBackColor = true;
            this.btDoiPass.Click += new System.EventHandler(this.btDoiPass_Click);
            // 
            // timeNow
            // 
            this.timeNow.Enabled = true;
            this.timeNow.Interval = 1000;
            this.timeNow.Tick += new System.EventHandler(this.timeNow_Tick);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.lbTime.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(14, -2);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(213, 49);
            this.lbTime.TabIndex = 23;
            this.lbTime.Text = "Time Now";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập lại mật khẩu:";
            // 
            // txbPassWord
            // 
            this.txbPassWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txbPassWord.Location = new System.Drawing.Point(16, 33);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.PasswordChar = '•';
            this.txbPassWord.Size = new System.Drawing.Size(123, 23);
            this.txbPassWord.TabIndex = 1;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // panelXacNhan
            // 
            this.panelXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panelXacNhan.Controls.Add(this.btConfirmSecuritySecond);
            this.panelXacNhan.Controls.Add(this.txbPassWord);
            this.panelXacNhan.Controls.Add(this.label1);
            this.panelXacNhan.Location = new System.Drawing.Point(431, 122);
            this.panelXacNhan.Name = "panelXacNhan";
            this.panelXacNhan.Size = new System.Drawing.Size(245, 125);
            this.panelXacNhan.TabIndex = 25;
            // 
            // btConfirmSecuritySecond
            // 
            this.btConfirmSecuritySecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfirmSecuritySecond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmSecuritySecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmSecuritySecond.Location = new System.Drawing.Point(16, 62);
            this.btConfirmSecuritySecond.Name = "btConfirmSecuritySecond";
            this.btConfirmSecuritySecond.Size = new System.Drawing.Size(102, 40);
            this.btConfirmSecuritySecond.TabIndex = 26;
            this.btConfirmSecuritySecond.Text = "Xác nhận";
            this.btConfirmSecuritySecond.UseVisualStyleBackColor = true;
            this.btConfirmSecuritySecond.Click += new System.EventHandler(this.btConfirmSecuritySecond_Click);
            // 
            // panelDoiPass
            // 
            this.panelDoiPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDoiPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panelDoiPass.Controls.Add(this.btConfirmChangePass);
            this.panelDoiPass.Controls.Add(this.tbNewPass2);
            this.panelDoiPass.Controls.Add(this.tbNewPass);
            this.panelDoiPass.Controls.Add(this.tbOldPass);
            this.panelDoiPass.Controls.Add(this.label4);
            this.panelDoiPass.Controls.Add(this.label3);
            this.panelDoiPass.Controls.Add(this.label2);
            this.panelDoiPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDoiPass.Location = new System.Drawing.Point(431, 135);
            this.panelDoiPass.Name = "panelDoiPass";
            this.panelDoiPass.Size = new System.Drawing.Size(262, 134);
            this.panelDoiPass.TabIndex = 26;
            // 
            // btConfirmChangePass
            // 
            this.btConfirmChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfirmChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmChangePass.Location = new System.Drawing.Point(94, 92);
            this.btConfirmChangePass.Name = "btConfirmChangePass";
            this.btConfirmChangePass.Size = new System.Drawing.Size(93, 36);
            this.btConfirmChangePass.TabIndex = 16;
            this.btConfirmChangePass.Text = "Xác nhận";
            this.btConfirmChangePass.UseVisualStyleBackColor = true;
            this.btConfirmChangePass.Click += new System.EventHandler(this.btConfirmChangePass_Click);
            // 
            // tbNewPass2
            // 
            this.tbNewPass2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNewPass2.Location = new System.Drawing.Point(94, 62);
            this.tbNewPass2.Name = "tbNewPass2";
            this.tbNewPass2.PasswordChar = '•';
            this.tbNewPass2.Size = new System.Drawing.Size(123, 23);
            this.tbNewPass2.TabIndex = 4;
            this.tbNewPass2.UseSystemPasswordChar = true;
            // 
            // tbNewPass
            // 
            this.tbNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNewPass.Location = new System.Drawing.Point(94, 33);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '•';
            this.tbNewPass.Size = new System.Drawing.Size(123, 23);
            this.tbNewPass.TabIndex = 3;
            this.tbNewPass.UseSystemPasswordChar = true;
            // 
            // tbOldPass
            // 
            this.tbOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbOldPass.Location = new System.Drawing.Point(94, 4);
            this.tbOldPass.Name = "tbOldPass";
            this.tbOldPass.PasswordChar = '•';
            this.tbOldPass.Size = new System.Drawing.Size(123, 23);
            this.tbOldPass.TabIndex = 2;
            this.tbOldPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // tbDisplayname
            // 
            this.tbDisplayname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplayname.Location = new System.Drawing.Point(71, 67);
            this.tbDisplayname.MaxLength = 20;
            this.tbDisplayname.Name = "tbDisplayname";
            this.tbDisplayname.Size = new System.Drawing.Size(158, 23);
            this.tbDisplayname.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Tên hiển thị";
            // 
            // btEditDisplayname
            // 
            this.btEditDisplayname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditDisplayname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditDisplayname.Location = new System.Drawing.Point(71, 96);
            this.btEditDisplayname.Name = "btEditDisplayname";
            this.btEditDisplayname.Size = new System.Drawing.Size(91, 40);
            this.btEditDisplayname.TabIndex = 1;
            this.btEditDisplayname.Text = "Sửa";
            this.btEditDisplayname.UseVisualStyleBackColor = true;
            this.btEditDisplayname.Click += new System.EventHandler(this.btEditDisplayname_Click);
            // 
            // pLoading
            // 
            this.pLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pLoading.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pLoading.ForeColor = System.Drawing.Color.White;
            this.pLoading.InnerColor = System.Drawing.Color.Transparent;
            this.pLoading.Location = new System.Drawing.Point(327, 159);
            this.pLoading.Minimum = 0;
            this.pLoading.Name = "pLoading";
            this.pLoading.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pLoading.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pLoading.ShadowDecoration.Parent = this.pLoading;
            this.pLoading.Size = new System.Drawing.Size(130, 130);
            this.pLoading.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(308, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "Mã hóa lại dữ liệu";
            // 
            // pnBgBot
            // 
            this.pnBgBot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBgBot.BackColor = System.Drawing.Color.White;
            this.pnBgBot.BorderRadius = 15;
            this.pnBgBot.Controls.Add(this.lbTime);
            this.pnBgBot.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnBgBot.ForeColor = System.Drawing.Color.White;
            this.pnBgBot.Location = new System.Drawing.Point(106, 346);
            this.pnBgBot.Name = "pnBgBot";
            this.pnBgBot.ShadowDecoration.Parent = this.pnBgBot;
            this.pnBgBot.Size = new System.Drawing.Size(608, 113);
            this.pnBgBot.TabIndex = 30;
            // 
            // pnBgTop
            // 
            this.pnBgTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBgTop.BackColor = System.Drawing.Color.White;
            this.pnBgTop.BorderRadius = 30;
            this.pnBgTop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnBgTop.Location = new System.Drawing.Point(27, 12);
            this.pnBgTop.Name = "pnBgTop";
            this.pnBgTop.ShadowDecoration.Parent = this.pnBgTop;
            this.pnBgTop.Size = new System.Drawing.Size(732, 322);
            this.pnBgTop.TabIndex = 29;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 462);
            this.Controls.Add(this.pnBgBot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pLoading);
            this.Controls.Add(this.btEditDisplayname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDisplayname);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btBaoVe);
            this.Controls.Add(this.btDoiPass);
            this.Controls.Add(this.panelDoiPass);
            this.Controls.Add(this.panelXacNhan);
            this.Controls.Add(this.pnBgTop);
            this.Name = "FormHome";
            this.Opacity = 0.9D;
            this.Text = "Trang chủ tài khoản";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.panelXacNhan.ResumeLayout(false);
            this.panelXacNhan.PerformLayout();
            this.panelDoiPass.ResumeLayout(false);
            this.panelDoiPass.PerformLayout();
            this.pnBgBot.ResumeLayout(false);
            this.pnBgBot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btBaoVe;
        private System.Windows.Forms.Button btDoiPass;
        private System.Windows.Forms.Timer timeNow;
        private System.Windows.Forms.Label lbTime;
        public System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Panel panelXacNhan;
        private System.Windows.Forms.Button btConfirmSecuritySecond;
        private System.Windows.Forms.Panel panelDoiPass;
        private System.Windows.Forms.Button btConfirmChangePass;
        private System.Windows.Forms.TextBox tbNewPass2;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.TextBox tbOldPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbDisplayname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btEditDisplayname;
        private Guna.UI2.WinForms.Guna2CircleProgressBar pLoading;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel pnBgTop;
        private Guna.UI2.WinForms.Guna2Panel pnBgBot;
    }
}