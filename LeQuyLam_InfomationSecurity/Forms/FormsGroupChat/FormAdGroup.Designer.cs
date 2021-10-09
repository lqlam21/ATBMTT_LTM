
namespace LeQuyLam_InfomationSecurity.Forms.FormsGroupChat
{
    partial class FormAdGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTenNhom = new System.Windows.Forms.Label();
            this.tbMatKhauGr = new System.Windows.Forms.TextBox();
            this.lbMatKhauGr = new System.Windows.Forms.Label();
            this.tbBg = new CSharpControl.Control.RJTextBox();
            this.btnMinisize = new System.Windows.Forms.Button();
            this.btnMaxsize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.tbNoiDung = new System.Windows.Forms.TextBox();
            this.lbStt = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch1 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.btGui = new Guna.UI2.WinForms.Guna2Button();
            this.DragAnimation = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btInvaite = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.pnLichSu = new System.Windows.Forms.Panel();
            this.dc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewsMember = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewsMember)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTenNhom
            // 
            this.lbTenNhom.AutoSize = true;
            this.lbTenNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNhom.ForeColor = System.Drawing.Color.White;
            this.lbTenNhom.Location = new System.Drawing.Point(12, 18);
            this.lbTenNhom.Name = "lbTenNhom";
            this.lbTenNhom.Size = new System.Drawing.Size(49, 18);
            this.lbTenNhom.TabIndex = 4;
            this.lbTenNhom.Text = "Nhóm";
            // 
            // tbMatKhauGr
            // 
            this.tbMatKhauGr.Location = new System.Drawing.Point(121, 43);
            this.tbMatKhauGr.Name = "tbMatKhauGr";
            this.tbMatKhauGr.Size = new System.Drawing.Size(100, 20);
            this.tbMatKhauGr.TabIndex = 33;
            // 
            // lbMatKhauGr
            // 
            this.lbMatKhauGr.AutoSize = true;
            this.lbMatKhauGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhauGr.ForeColor = System.Drawing.Color.White;
            this.lbMatKhauGr.Location = new System.Drawing.Point(13, 42);
            this.lbMatKhauGr.Name = "lbMatKhauGr";
            this.lbMatKhauGr.Size = new System.Drawing.Size(111, 18);
            this.lbMatKhauGr.TabIndex = 4;
            this.lbMatKhauGr.Text = "Mật khẩu nhóm";
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
            this.tbBg.ForeColor = System.Drawing.Color.White;
            this.tbBg.Location = new System.Drawing.Point(5, 480);
            this.tbBg.Margin = new System.Windows.Forms.Padding(4);
            this.tbBg.Multiline = false;
            this.tbBg.Name = "tbBg";
            this.tbBg.Padding = new System.Windows.Forms.Padding(7);
            this.tbBg.PasswordChar = false;
            this.tbBg.Size = new System.Drawing.Size(494, 31);
            this.tbBg.TabIndex = 6;
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
            this.btnMinisize.Location = new System.Drawing.Point(777, -4);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(30, 30);
            this.btnMinisize.TabIndex = 51;
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
            this.btnMaxsize.Location = new System.Drawing.Point(808, -4);
            this.btnMaxsize.Name = "btnMaxsize";
            this.btnMaxsize.Size = new System.Drawing.Size(30, 30);
            this.btnMaxsize.TabIndex = 50;
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
            this.btnClose.Location = new System.Drawing.Point(839, -4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "O";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 1000;
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
            this.tbNoiDung.Location = new System.Drawing.Point(5, 490);
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.Size = new System.Drawing.Size(487, 17);
            this.tbNoiDung.TabIndex = 0;
            this.tbNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNoiDung_KeyDown);
            // 
            // lbStt
            // 
            this.lbStt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStt.AutoSize = true;
            this.lbStt.CausesValidation = false;
            this.lbStt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStt.ForeColor = System.Drawing.Color.Gray;
            this.lbStt.Location = new System.Drawing.Point(3, 489);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(110, 18);
            this.lbStt.TabIndex = 53;
            this.lbStt.Text = "Nhập tin nhắn...";
            this.lbStt.Click += new System.EventHandler(this.lbStt_Click);
            // 
            // guna2ToggleSwitch1
            // 
            this.guna2ToggleSwitch1.Animated = true;
            this.guna2ToggleSwitch1.Checked = true;
            this.guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.Navy;
            this.guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.Parent = this.guna2ToggleSwitch1;
            this.guna2ToggleSwitch1.Location = new System.Drawing.Point(227, 43);
            this.guna2ToggleSwitch1.Name = "guna2ToggleSwitch1";
            this.guna2ToggleSwitch1.ShadowDecoration.Parent = this.guna2ToggleSwitch1;
            this.guna2ToggleSwitch1.Size = new System.Drawing.Size(35, 20);
            this.guna2ToggleSwitch1.TabIndex = 54;
            this.guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.BorderThickness = 2;
            this.guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.Parent = this.guna2ToggleSwitch1;
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
            this.btGui.Location = new System.Drawing.Point(498, 478);
            this.btGui.Name = "btGui";
            this.btGui.ShadowDecoration.Parent = this.btGui;
            this.btGui.Size = new System.Drawing.Size(84, 41);
            this.btGui.TabIndex = 55;
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
            // btInvaite
            // 
            this.btInvaite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInvaite.Animated = true;
            this.btInvaite.BackColor = System.Drawing.Color.Transparent;
            this.btInvaite.BorderRadius = 10;
            this.btInvaite.CheckedState.Parent = this.btInvaite;
            this.btInvaite.CustomImages.Parent = this.btInvaite;
            this.btInvaite.DisabledState.Parent = this.btInvaite;
            this.btInvaite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.btInvaite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btInvaite.ForeColor = System.Drawing.Color.White;
            this.btInvaite.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btInvaite.HoverState.Parent = this.btInvaite;
            this.btInvaite.Location = new System.Drawing.Point(372, 31);
            this.btInvaite.Name = "btInvaite";
            this.btInvaite.ShadowDecoration.Parent = this.btInvaite;
            this.btInvaite.Size = new System.Drawing.Size(95, 39);
            this.btInvaite.TabIndex = 56;
            this.btInvaite.Text = "Mời ";
            this.btInvaite.UseTransparentBackground = true;
            this.btInvaite.Click += new System.EventHandler(this.btInvaite_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.Animated = true;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(486, 30);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(98, 41);
            this.guna2Button2.TabIndex = 57;
            this.guna2Button2.Text = "Đổi pass";
            this.guna2Button2.UseTransparentBackground = true;
            // 
            // pnLichSu
            // 
            this.pnLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLichSu.AutoScroll = true;
            this.pnLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.pnLichSu.Location = new System.Drawing.Point(12, 76);
            this.pnLichSu.Name = "pnLichSu";
            this.pnLichSu.Size = new System.Drawing.Size(570, 400);
            this.pnLichSu.TabIndex = 2;
            // 
            // dc
            // 
            this.dc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dc.DefaultCellStyle = dataGridViewCellStyle10;
            this.dc.HeaderText = "Disconnect";
            this.dc.MinimumWidth = 20;
            this.dc.Name = "dc";
            this.dc.ReadOnly = true;
            this.dc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dc.Text = "Kick";
            this.dc.UseColumnTextForButtonValue = true;
            this.dc.Width = 80;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle9;
            this.name.HeaderText = "Name";
            this.name.MaxInputLength = 20;
            this.name.MinimumWidth = 20;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // identifier
            // 
            this.identifier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.identifier.DefaultCellStyle = dataGridViewCellStyle8;
            this.identifier.HeaderText = "ID";
            this.identifier.MaxInputLength = 20;
            this.identifier.MinimumWidth = 20;
            this.identifier.Name = "identifier";
            this.identifier.ReadOnly = true;
            this.identifier.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.identifier.Width = 70;
            // 
            // DataGridViewsMember
            // 
            this.DataGridViewsMember.AllowUserToAddRows = false;
            this.DataGridViewsMember.AllowUserToDeleteRows = false;
            this.DataGridViewsMember.AllowUserToResizeColumns = false;
            this.DataGridViewsMember.AllowUserToResizeRows = false;
            this.DataGridViewsMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewsMember.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.DataGridViewsMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridViewsMember.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DataGridViewsMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewsMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewsMember.ColumnHeadersHeight = 24;
            this.DataGridViewsMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewsMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.identifier,
            this.name,
            this.dc});
            this.DataGridViewsMember.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewsMember.EnableHeadersVisualStyles = false;
            this.DataGridViewsMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.DataGridViewsMember.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DataGridViewsMember.Location = new System.Drawing.Point(591, 32);
            this.DataGridViewsMember.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewsMember.MultiSelect = false;
            this.DataGridViewsMember.Name = "DataGridViewsMember";
            this.DataGridViewsMember.ReadOnly = true;
            this.DataGridViewsMember.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DataGridViewsMember.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridViewsMember.RowHeadersVisible = false;
            this.DataGridViewsMember.RowHeadersWidth = 40;
            this.DataGridViewsMember.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewsMember.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DataGridViewsMember.RowTemplate.Height = 24;
            this.DataGridViewsMember.RowTemplate.ReadOnly = true;
            this.DataGridViewsMember.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewsMember.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewsMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewsMember.ShowCellErrors = false;
            this.DataGridViewsMember.ShowCellToolTips = false;
            this.DataGridViewsMember.ShowEditingIcon = false;
            this.DataGridViewsMember.ShowRowErrors = false;
            this.DataGridViewsMember.Size = new System.Drawing.Size(269, 482);
            this.DataGridViewsMember.TabIndex = 31;
            this.DataGridViewsMember.TabStop = false;
            this.DataGridViewsMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewsMember_CellClick);
            // 
            // FormAdGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(868, 524);
            this.Controls.Add(this.pnLichSu);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.btInvaite);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.guna2ToggleSwitch1);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.tbNoiDung);
            this.Controls.Add(this.btnMinisize);
            this.Controls.Add(this.btnMaxsize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbBg);
            this.Controls.Add(this.tbMatKhauGr);
            this.Controls.Add(this.DataGridViewsMember);
            this.Controls.Add(this.lbMatKhauGr);
            this.Controls.Add(this.lbTenNhom);
            this.MinimumSize = new System.Drawing.Size(828, 511);
            this.Name = "FormAdGroup";
            this.Text = "FormAdGroup";
            this.Load += new System.EventHandler(this.FormAdGroup_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormAdGroup_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewsMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTenNhom;
        private System.Windows.Forms.TextBox tbMatKhauGr;
        private System.Windows.Forms.Label lbMatKhauGr;
        private CSharpControl.Control.RJTextBox tbBg;
        private System.Windows.Forms.Button btnMinisize;
        private System.Windows.Forms.Button btnMaxsize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.TextBox tbNoiDung;
        private System.Windows.Forms.Label lbStt;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch1;
        private Guna.UI2.WinForms.Guna2Button btGui;
        private Guna.UI2.WinForms.Guna2DragControl DragAnimation;
        private Guna.UI2.WinForms.Guna2Button btInvaite;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Panel pnLichSu;
        private System.Windows.Forms.DataGridView DataGridViewsMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewButtonColumn dc;
    }
}