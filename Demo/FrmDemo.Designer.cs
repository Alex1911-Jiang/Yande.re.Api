namespace Demo
{
    partial class FrmDemo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picRandomPicture = new System.Windows.Forms.PictureBox();
            this.txbItems = new System.Windows.Forms.TextBox();
            this.btnRandomHPicture = new System.Windows.Forms.Button();
            this.btnItemList = new System.Windows.Forms.Button();
            this.txbTagFilter = new System.Windows.Forms.TextBox();
            this.lblTagFilter = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.cboHost = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picRandomPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picRandomPicture
            // 
            this.picRandomPicture.Location = new System.Drawing.Point(19, 17);
            this.picRandomPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.picRandomPicture.Name = "picRandomPicture";
            this.picRandomPicture.Size = new System.Drawing.Size(512, 512);
            this.picRandomPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRandomPicture.TabIndex = 0;
            this.picRandomPicture.TabStop = false;
            // 
            // txbItems
            // 
            this.txbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbItems.Location = new System.Drawing.Point(541, 18);
            this.txbItems.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbItems.Multiline = true;
            this.txbItems.Name = "txbItems";
            this.txbItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbItems.Size = new System.Drawing.Size(447, 604);
            this.txbItems.TabIndex = 1;
            // 
            // btnRandomHPicture
            // 
            this.btnRandomHPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRandomHPicture.Enabled = false;
            this.btnRandomHPicture.Location = new System.Drawing.Point(210, 590);
            this.btnRandomHPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRandomHPicture.Name = "btnRandomHPicture";
            this.btnRandomHPicture.Size = new System.Drawing.Size(118, 32);
            this.btnRandomHPicture.TabIndex = 2;
            this.btnRandomHPicture.Text = "随机色图";
            this.btnRandomHPicture.UseVisualStyleBackColor = true;
            this.btnRandomHPicture.Click += new System.EventHandler(this.BtnRandomHPicture_Click);
            // 
            // btnItemList
            // 
            this.btnItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemList.Enabled = false;
            this.btnItemList.Location = new System.Drawing.Point(342, 590);
            this.btnItemList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnItemList.Name = "btnItemList";
            this.btnItemList.Size = new System.Drawing.Size(118, 32);
            this.btnItemList.TabIndex = 3;
            this.btnItemList.Text = "地址列表";
            this.btnItemList.UseVisualStyleBackColor = true;
            this.btnItemList.Click += new System.EventHandler(this.BtnItemList_Click);
            // 
            // txbTagFilter
            // 
            this.txbTagFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTagFilter.Location = new System.Drawing.Point(342, 554);
            this.txbTagFilter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTagFilter.Name = "txbTagFilter";
            this.txbTagFilter.Size = new System.Drawing.Size(189, 30);
            this.txbTagFilter.TabIndex = 4;
            // 
            // lblTagFilter
            // 
            this.lblTagFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTagFilter.AutoSize = true;
            this.lblTagFilter.Location = new System.Drawing.Point(282, 557);
            this.lblTagFilter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTagFilter.Name = "lblTagFilter";
            this.lblTagFilter.Size = new System.Drawing.Size(50, 24);
            this.lblTagFilter.TabIndex = 5;
            this.lblTagFilter.Text = "标签:";
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInit.Location = new System.Drawing.Point(79, 590);
            this.btnInit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(118, 32);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // cboHost
            // 
            this.cboHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHost.FormattingEnabled = true;
            this.cboHost.Items.AddRange(new object[] {
            "yande.re",
            "konachan.net",
            "lolibooru.moe"});
            this.cboHost.Location = new System.Drawing.Point(79, 551);
            this.cboHost.Name = "cboHost";
            this.cboHost.Size = new System.Drawing.Size(189, 32);
            this.cboHost.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 554);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "网站:";
            // 
            // FrmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 635);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboHost);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lblTagFilter);
            this.Controls.Add(this.txbTagFilter);
            this.Controls.Add(this.btnItemList);
            this.Controls.Add(this.btnRandomHPicture);
            this.Controls.Add(this.txbItems);
            this.Controls.Add(this.picRandomPicture);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmDemo";
            this.Text = "Demo";
            ((System.ComponentModel.ISupportInitialize)(this.picRandomPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picRandomPicture;
        private TextBox txbItems;
        private Button btnRandomHPicture;
        private Button btnItemList;
        private TextBox txbTagFilter;
        private Label lblTagFilter;
        private Button btnInit;
        private ComboBox cboHost;
        private Label label1;
    }
}