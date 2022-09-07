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
            ((System.ComponentModel.ISupportInitialize)(this.picRandomPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picRandomPicture
            // 
            this.picRandomPicture.Location = new System.Drawing.Point(12, 12);
            this.picRandomPicture.Name = "picRandomPicture";
            this.picRandomPicture.Size = new System.Drawing.Size(400, 400);
            this.picRandomPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRandomPicture.TabIndex = 0;
            this.picRandomPicture.TabStop = false;
            // 
            // txbItems
            // 
            this.txbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbItems.Location = new System.Drawing.Point(418, 12);
            this.txbItems.Multiline = true;
            this.txbItems.Name = "txbItems";
            this.txbItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbItems.Size = new System.Drawing.Size(370, 429);
            this.txbItems.TabIndex = 1;
            // 
            // btnRandomHPicture
            // 
            this.btnRandomHPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRandomHPicture.Enabled = false;
            this.btnRandomHPicture.Location = new System.Drawing.Point(256, 418);
            this.btnRandomHPicture.Name = "btnRandomHPicture";
            this.btnRandomHPicture.Size = new System.Drawing.Size(75, 23);
            this.btnRandomHPicture.TabIndex = 2;
            this.btnRandomHPicture.Text = "随机色图";
            this.btnRandomHPicture.UseVisualStyleBackColor = true;
            this.btnRandomHPicture.Click += new System.EventHandler(this.btnRandomHPicture_Click);
            // 
            // btnItemList
            // 
            this.btnItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemList.Enabled = false;
            this.btnItemList.Location = new System.Drawing.Point(337, 418);
            this.btnItemList.Name = "btnItemList";
            this.btnItemList.Size = new System.Drawing.Size(75, 23);
            this.btnItemList.TabIndex = 3;
            this.btnItemList.Text = "地址列表";
            this.btnItemList.UseVisualStyleBackColor = true;
            this.btnItemList.Click += new System.EventHandler(this.btnItemList_Click);
            // 
            // txbTagFilter
            // 
            this.txbTagFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTagFilter.Location = new System.Drawing.Point(77, 418);
            this.txbTagFilter.Name = "txbTagFilter";
            this.txbTagFilter.Size = new System.Drawing.Size(92, 23);
            this.txbTagFilter.TabIndex = 4;
            // 
            // lblTagFilter
            // 
            this.lblTagFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTagFilter.AutoSize = true;
            this.lblTagFilter.Location = new System.Drawing.Point(12, 421);
            this.lblTagFilter.Name = "lblTagFilter";
            this.lblTagFilter.Size = new System.Drawing.Size(59, 17);
            this.lblTagFilter.TabIndex = 5;
            this.lblTagFilter.Text = "标签过滤:";
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInit.Location = new System.Drawing.Point(175, 418);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // FrmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lblTagFilter);
            this.Controls.Add(this.txbTagFilter);
            this.Controls.Add(this.btnItemList);
            this.Controls.Add(this.btnRandomHPicture);
            this.Controls.Add(this.txbItems);
            this.Controls.Add(this.picRandomPicture);
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
    }
}