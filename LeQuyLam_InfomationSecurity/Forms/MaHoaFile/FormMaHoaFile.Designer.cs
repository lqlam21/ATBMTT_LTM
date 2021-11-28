
namespace LeQuyLam_InfomationSecurity.Forms
{
    partial class FormMaHoaFile
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
            this.label5 = new System.Windows.Forms.Label();
            this.btTaiLen = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutFileList = new System.Windows.Forms.FlowLayoutPanel();
            this.btChonFile = new Guna.UI2.WinForms.Guna2Button();
            this.lbDuongDan = new System.Windows.Forms.Label();
            this.btGiaiMa = new Guna.UI2.WinForms.Guna2Button();
            this.tbMaKhoa = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(20, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Danh sách file của bạn";
            // 
            // btTaiLen
            // 
            this.btTaiLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTaiLen.Animated = true;
            this.btTaiLen.BackColor = System.Drawing.Color.Transparent;
            this.btTaiLen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.btTaiLen.BorderRadius = 10;
            this.btTaiLen.BorderThickness = 2;
            this.btTaiLen.CheckedState.Parent = this.btTaiLen;
            this.btTaiLen.CustomImages.Parent = this.btTaiLen;
            this.btTaiLen.DisabledState.Parent = this.btTaiLen;
            this.btTaiLen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btTaiLen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btTaiLen.ForeColor = System.Drawing.Color.White;
            this.btTaiLen.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btTaiLen.HoverState.Parent = this.btTaiLen;
            this.btTaiLen.Location = new System.Drawing.Point(690, 377);
            this.btTaiLen.Name = "btTaiLen";
            this.btTaiLen.ShadowDecoration.Parent = this.btTaiLen;
            this.btTaiLen.Size = new System.Drawing.Size(98, 39);
            this.btTaiLen.TabIndex = 51;
            this.btTaiLen.Text = "Tải lên";
            this.btTaiLen.UseTransparentBackground = true;
            this.btTaiLen.Click += new System.EventHandler(this.btTaiLen_Click);
            // 
            // flowLayoutFileList
            // 
            this.flowLayoutFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutFileList.AutoScroll = true;
            this.flowLayoutFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.flowLayoutFileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.flowLayoutFileList.Location = new System.Drawing.Point(12, 57);
            this.flowLayoutFileList.Name = "flowLayoutFileList";
            this.flowLayoutFileList.Size = new System.Drawing.Size(776, 315);
            this.flowLayoutFileList.TabIndex = 53;
            // 
            // btChonFile
            // 
            this.btChonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btChonFile.Animated = true;
            this.btChonFile.BackColor = System.Drawing.Color.Transparent;
            this.btChonFile.BorderColor = System.Drawing.Color.Transparent;
            this.btChonFile.BorderRadius = 10;
            this.btChonFile.BorderThickness = 2;
            this.btChonFile.CheckedState.Parent = this.btChonFile;
            this.btChonFile.CustomImages.Parent = this.btChonFile;
            this.btChonFile.DisabledState.Parent = this.btChonFile;
            this.btChonFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btChonFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btChonFile.ForeColor = System.Drawing.Color.White;
            this.btChonFile.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btChonFile.HoverState.Parent = this.btChonFile;
            this.btChonFile.Location = new System.Drawing.Point(12, 377);
            this.btChonFile.Name = "btChonFile";
            this.btChonFile.ShadowDecoration.Parent = this.btChonFile;
            this.btChonFile.Size = new System.Drawing.Size(96, 39);
            this.btChonFile.TabIndex = 51;
            this.btChonFile.Text = "Chọn file";
            this.btChonFile.UseTransparentBackground = true;
            this.btChonFile.Click += new System.EventHandler(this.btChonFile_Click);
            // 
            // lbDuongDan
            // 
            this.lbDuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDuongDan.AutoSize = true;
            this.lbDuongDan.ForeColor = System.Drawing.Color.Silver;
            this.lbDuongDan.Location = new System.Drawing.Point(115, 393);
            this.lbDuongDan.Name = "lbDuongDan";
            this.lbDuongDan.Size = new System.Drawing.Size(16, 13);
            this.lbDuongDan.TabIndex = 54;
            this.lbDuongDan.Text = "...";
            // 
            // btGiaiMa
            // 
            this.btGiaiMa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGiaiMa.Animated = true;
            this.btGiaiMa.BackColor = System.Drawing.Color.Transparent;
            this.btGiaiMa.BorderRadius = 10;
            this.btGiaiMa.CheckedState.Parent = this.btGiaiMa;
            this.btGiaiMa.CustomImages.Parent = this.btGiaiMa;
            this.btGiaiMa.DisabledState.Parent = this.btGiaiMa;
            this.btGiaiMa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.btGiaiMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btGiaiMa.ForeColor = System.Drawing.Color.White;
            this.btGiaiMa.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btGiaiMa.HoverState.Parent = this.btGiaiMa;
            this.btGiaiMa.Location = new System.Drawing.Point(690, 12);
            this.btGiaiMa.Name = "btGiaiMa";
            this.btGiaiMa.ShadowDecoration.Parent = this.btGiaiMa;
            this.btGiaiMa.Size = new System.Drawing.Size(98, 39);
            this.btGiaiMa.TabIndex = 52;
            this.btGiaiMa.Text = "Giải Mã File";
            this.btGiaiMa.UseTransparentBackground = true;
            this.btGiaiMa.Click += new System.EventHandler(this.btGiaiMa_Click);
            // 
            // tbMaKhoa
            // 
            this.tbMaKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMaKhoa.BorderRadius = 10;
            this.tbMaKhoa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMaKhoa.DefaultText = "";
            this.tbMaKhoa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMaKhoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMaKhoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaKhoa.DisabledState.Parent = this.tbMaKhoa;
            this.tbMaKhoa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaKhoa.FocusedState.Parent = this.tbMaKhoa;
            this.tbMaKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbMaKhoa.ForeColor = System.Drawing.Color.Black;
            this.tbMaKhoa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaKhoa.HoverState.Parent = this.tbMaKhoa;
            this.tbMaKhoa.Location = new System.Drawing.Point(551, 382);
            this.tbMaKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMaKhoa.MaxLength = 20;
            this.tbMaKhoa.Name = "tbMaKhoa";
            this.tbMaKhoa.PasswordChar = '\0';
            this.tbMaKhoa.PlaceholderText = "";
            this.tbMaKhoa.SelectedText = "";
            this.tbMaKhoa.ShadowDecoration.Parent = this.tbMaKhoa;
            this.tbMaKhoa.Size = new System.Drawing.Size(133, 30);
            this.tbMaKhoa.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(475, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mã khóa";
            // 
            // FormMaHoaFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.tbMaKhoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDuongDan);
            this.Controls.Add(this.flowLayoutFileList);
            this.Controls.Add(this.btGiaiMa);
            this.Controls.Add(this.btChonFile);
            this.Controls.Add(this.btTaiLen);
            this.Controls.Add(this.label5);
            this.Name = "FormMaHoaFile";
            this.Text = "Mã hóa file";
            this.Load += new System.EventHandler(this.FormChatRieng_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btTaiLen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutFileList;
        private Guna.UI2.WinForms.Guna2Button btChonFile;
        private System.Windows.Forms.Label lbDuongDan;
        private Guna.UI2.WinForms.Guna2Button btGiaiMa;
        private Guna.UI2.WinForms.Guna2TextBox tbMaKhoa;
        private System.Windows.Forms.Label label1;
    }
}