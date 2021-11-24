
namespace LeQuyLam_InfomationSecurity.Forms.FormsGroupChat
{
    partial class FormMemberGroup
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
            this.lbTenNhom = new System.Windows.Forms.Label();
            this.tbBg = new CSharpControl.Control.RJTextBox();
            this.btnMinisize = new System.Windows.Forms.Button();
            this.btnMaxsize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.tbNoiDung = new System.Windows.Forms.TextBox();
            this.lbStt = new System.Windows.Forms.Label();
            this.btGui = new Guna.UI2.WinForms.Guna2Button();
            this.DragAnimation = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnLichSu = new System.Windows.Forms.Panel();
            this.timerDellMess = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTenNhom
            // 
            this.lbTenNhom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTenNhom.AutoSize = true;
            this.lbTenNhom.BackColor = System.Drawing.Color.Transparent;
            this.lbTenNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbTenNhom.Location = new System.Drawing.Point(20, 7);
            this.lbTenNhom.Name = "lbTenNhom";
            this.lbTenNhom.Size = new System.Drawing.Size(62, 24);
            this.lbTenNhom.TabIndex = 43;
            this.lbTenNhom.Text = "Nhóm";
            // 
            // tbBg
            // 
            this.tbBg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tbBg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tbBg.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbBg.BorderSize = 2;
            this.tbBg.Enabled = false;
            this.tbBg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBg.ForeColor = System.Drawing.Color.Silver;
            this.tbBg.Location = new System.Drawing.Point(10, 445);
            this.tbBg.Margin = new System.Windows.Forms.Padding(4);
            this.tbBg.Multiline = false;
            this.tbBg.Name = "tbBg";
            this.tbBg.Padding = new System.Windows.Forms.Padding(7);
            this.tbBg.PasswordChar = false;
            this.tbBg.Size = new System.Drawing.Size(495, 31);
            this.tbBg.TabIndex = 3;
            this.tbBg.Texts = "";
            this.tbBg.UnderlinedStyle = true;
            // 
            // btnMinisize
            // 
            this.btnMinisize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinisize.FlatAppearance.BorderSize = 0;
            this.btnMinisize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinisize.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinisize.ForeColor = System.Drawing.Color.White;
            this.btnMinisize.Location = new System.Drawing.Point(503, -2);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(30, 30);
            this.btnMinisize.TabIndex = 48;
            this.btnMinisize.Text = "O";
            this.btnMinisize.UseVisualStyleBackColor = true;
            this.btnMinisize.Click += new System.EventHandler(this.btnMinisize_Click);
            // 
            // btnMaxsize
            // 
            this.btnMaxsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxsize.FlatAppearance.BorderSize = 0;
            this.btnMaxsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxsize.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxsize.ForeColor = System.Drawing.Color.White;
            this.btnMaxsize.Location = new System.Drawing.Point(534, -2);
            this.btnMaxsize.Name = "btnMaxsize";
            this.btnMaxsize.Size = new System.Drawing.Size(30, 30);
            this.btnMaxsize.TabIndex = 47;
            this.btnMaxsize.Text = "O";
            this.btnMaxsize.UseVisualStyleBackColor = true;
            this.btnMaxsize.Click += new System.EventHandler(this.btnMaxsize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(565, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "O";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 500;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // tbNoiDung
            // 
            this.tbNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tbNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoiDung.ForeColor = System.Drawing.Color.Silver;
            this.tbNoiDung.Location = new System.Drawing.Point(10, 456);
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.Size = new System.Drawing.Size(495, 17);
            this.tbNoiDung.TabIndex = 0;
            this.tbNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNoiDung_KeyDown);
            // 
            // lbStt
            // 
            this.lbStt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStt.AutoSize = true;
            this.lbStt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStt.ForeColor = System.Drawing.Color.Gray;
            this.lbStt.Location = new System.Drawing.Point(12, 456);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(110, 18);
            this.lbStt.TabIndex = 49;
            this.lbStt.Text = "Nhập tin nhắn...";
            this.lbStt.Click += new System.EventHandler(this.lbStt_Click);
            // 
            // btGui
            // 
            this.btGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGui.Animated = true;
            this.btGui.BackColor = System.Drawing.Color.Transparent;
            this.btGui.BorderColor = System.Drawing.Color.Transparent;
            this.btGui.BorderRadius = 20;
            this.btGui.BorderThickness = 2;
            this.btGui.CheckedState.Parent = this.btGui;
            this.btGui.CustomImages.Parent = this.btGui;
            this.btGui.DisabledState.Parent = this.btGui;
            this.btGui.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btGui.ForeColor = System.Drawing.Color.White;
            this.btGui.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btGui.HoverState.Parent = this.btGui;
            this.btGui.Location = new System.Drawing.Point(511, 445);
            this.btGui.Name = "btGui";
            this.btGui.ShadowDecoration.Parent = this.btGui;
            this.btGui.Size = new System.Drawing.Size(76, 41);
            this.btGui.TabIndex = 56;
            this.btGui.Text = "Gửi";
            this.btGui.UseTransparentBackground = true;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // DragAnimation
            // 
            this.DragAnimation.ContainerControl = this;
            this.DragAnimation.TargetControl = this.lbTenNhom;
            this.DragAnimation.TransparentWhileDrag = true;
            this.DragAnimation.UseTransparentDrag = true;
            // 
            // pnLichSu
            // 
            this.pnLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLichSu.AutoScroll = true;
            this.pnLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.pnLichSu.Location = new System.Drawing.Point(10, 34);
            this.pnLichSu.Name = "pnLichSu";
            this.pnLichSu.Size = new System.Drawing.Size(577, 404);
            this.pnLichSu.TabIndex = 57;
            // 
            // timerDellMess
            // 
            this.timerDellMess.Enabled = true;
            this.timerDellMess.Interval = 1000;
            this.timerDellMess.Tick += new System.EventHandler(this.timerDellMess_Tick);
            // 
            // FormMemberGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(593, 489);
            this.Controls.Add(this.pnLichSu);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.tbNoiDung);
            this.Controls.Add(this.btnMinisize);
            this.Controls.Add(this.btnMaxsize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbBg);
            this.Controls.Add(this.lbTenNhom);
            this.MinimumSize = new System.Drawing.Size(581, 491);
            this.Name = "FormMemberGroup";
            this.Text = "FormMemberGroup";
            this.Load += new System.EventHandler(this.FormMemberGroup_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMemberGroup_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTenNhom;
        private CSharpControl.Control.RJTextBox tbBg;
        private System.Windows.Forms.Button btnMinisize;
        private System.Windows.Forms.Button btnMaxsize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.TextBox tbNoiDung;
        private System.Windows.Forms.Label lbStt;
        private Guna.UI2.WinForms.Guna2Button btGui;
        private Guna.UI2.WinForms.Guna2DragControl DragAnimation;
        private System.Windows.Forms.Panel pnLichSu;
        private System.Windows.Forms.Timer timerDellMess;
    }
}