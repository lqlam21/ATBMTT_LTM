
namespace LeQuyLam_InfomationSecurity.Forms
{
    partial class FormChat
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.tbTenNhom = new System.Windows.Forms.TextBox();
            this.lbTennhom = new System.Windows.Forms.Label();
            this.btTaoNhom = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.flowLayoutNhomChat = new System.Windows.Forms.FlowLayoutPanel();
            this.lbStt = new System.Windows.Forms.Label();
            this.toolTipGroup = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timerLoadGr = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Danh sách nhóm";
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMatKhau.Location = new System.Drawing.Point(688, 45);
            this.tbMatKhau.MaxLength = 30;
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(100, 20);
            this.tbMatKhau.TabIndex = 1;
            this.tbMatKhau.UseSystemPasswordChar = true;
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Location = new System.Drawing.Point(630, 50);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(52, 13);
            this.lbMatKhau.TabIndex = 19;
            this.lbMatKhau.Text = "Mật khẩu";
            // 
            // tbTenNhom
            // 
            this.tbTenNhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTenNhom.Location = new System.Drawing.Point(688, 19);
            this.tbTenNhom.MaxLength = 40;
            this.tbTenNhom.Name = "tbTenNhom";
            this.tbTenNhom.Size = new System.Drawing.Size(100, 20);
            this.tbTenNhom.TabIndex = 0;
            // 
            // lbTennhom
            // 
            this.lbTennhom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTennhom.AutoSize = true;
            this.lbTennhom.Location = new System.Drawing.Point(627, 22);
            this.lbTennhom.Name = "lbTennhom";
            this.lbTennhom.Size = new System.Drawing.Size(55, 13);
            this.lbTennhom.TabIndex = 17;
            this.lbTennhom.Text = "Tên nhóm";
            // 
            // btTaoNhom
            // 
            this.btTaoNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTaoNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTaoNhom.Location = new System.Drawing.Point(22, 19);
            this.btTaoNhom.Name = "btTaoNhom";
            this.btTaoNhom.Size = new System.Drawing.Size(91, 40);
            this.btTaoNhom.TabIndex = 16;
            this.btTaoNhom.Text = "Tạo nhóm";
            this.btTaoNhom.UseVisualStyleBackColor = true;
            this.btTaoNhom.Click += new System.EventHandler(this.btTaoNhom_Click);
            // 
            // btSearch
            // 
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.Location = new System.Drawing.Point(137, 19);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(91, 40);
            this.btSearch.TabIndex = 15;
            this.btSearch.Text = "Tìm nhóm";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // flowLayoutNhomChat
            // 
            this.flowLayoutNhomChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutNhomChat.AutoScroll = true;
            this.flowLayoutNhomChat.BackColor = System.Drawing.Color.White;
            this.flowLayoutNhomChat.Location = new System.Drawing.Point(12, 78);
            this.flowLayoutNhomChat.Name = "flowLayoutNhomChat";
            this.flowLayoutNhomChat.Size = new System.Drawing.Size(776, 360);
            this.flowLayoutNhomChat.TabIndex = 27;
            // 
            // lbStt
            // 
            this.lbStt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStt.AutoSize = true;
            this.lbStt.Location = new System.Drawing.Point(500, 59);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(103, 13);
            this.lbStt.TabIndex = 28;
            this.lbStt.Text = "(Bạn chưa có nhóm)";
            // 
            // toolTipGroup
            // 
            this.toolTipGroup.IsBalloon = true;
            this.toolTipGroup.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipGroup.ToolTipTitle = "Gợi ý";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.flowLayoutNhomChat;
            // 
            // timerLoadGr
            // 
            this.timerLoadGr.Enabled = true;
            this.timerLoadGr.Interval = 1000;
            this.timerLoadGr.Tick += new System.EventHandler(this.timerLoadGr_Tick);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.flowLayoutNhomChat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMatKhau);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.tbTenNhom);
            this.Controls.Add(this.lbTennhom);
            this.Controls.Add(this.btTaoNhom);
            this.Controls.Add(this.btSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChat";
            this.Text = "Chat nhóm";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.TextBox tbTenNhom;
        private System.Windows.Forms.Label lbTennhom;
        private System.Windows.Forms.Button btTaoNhom;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutNhomChat;
        private System.Windows.Forms.Label lbStt;
        private System.Windows.Forms.ToolTip toolTipGroup;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Timer timerLoadGr;
    }
}