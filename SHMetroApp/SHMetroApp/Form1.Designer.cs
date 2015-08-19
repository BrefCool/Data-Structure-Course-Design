namespace SHMetroApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroup = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.Y_textBox = new System.Windows.Forms.TextBox();
            this.YLabel = new System.Windows.Forms.Label();
            this.X_textBox = new System.Windows.Forms.TextBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.nodeNameBox = new System.Windows.Forms.TextBox();
            this.nodeNameLabel = new System.Windows.Forms.Label();
            this.metroGraphView = new SHMetroApp.MetroGraphView();
            this.menuStrip1.SuspendLayout();
            this.editGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1441, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(51, 24);
            this.editMenuItem.Text = "编辑";
            this.editMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Edit_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // editGroup
            // 
            this.editGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editGroup.Controls.Add(this.cancelBtn);
            this.editGroup.Controls.Add(this.saveBtn);
            this.editGroup.Controls.Add(this.Y_textBox);
            this.editGroup.Controls.Add(this.YLabel);
            this.editGroup.Controls.Add(this.X_textBox);
            this.editGroup.Controls.Add(this.XLabel);
            this.editGroup.Controls.Add(this.nodeNameBox);
            this.editGroup.Controls.Add(this.nodeNameLabel);
            this.editGroup.Location = new System.Drawing.Point(12, 606);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(1417, 45);
            this.editGroup.TabIndex = 2;
            this.editGroup.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(1339, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(1241, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Y_textBox
            // 
            this.Y_textBox.Location = new System.Drawing.Point(455, 13);
            this.Y_textBox.Name = "Y_textBox";
            this.Y_textBox.Size = new System.Drawing.Size(100, 25);
            this.Y_textBox.TabIndex = 5;
            this.Y_textBox.TextChanged += new System.EventHandler(this.Y_textBox_textChanged);
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(419, 16);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(30, 15);
            this.YLabel.TabIndex = 4;
            this.YLabel.Text = "Y：";
            // 
            // X_textBox
            // 
            this.X_textBox.Location = new System.Drawing.Point(313, 13);
            this.X_textBox.Name = "X_textBox";
            this.X_textBox.Size = new System.Drawing.Size(100, 25);
            this.X_textBox.TabIndex = 3;
            this.X_textBox.TextChanged += new System.EventHandler(this.X_textBox_textChanged);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(277, 16);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(30, 15);
            this.XLabel.TabIndex = 2;
            this.XLabel.Text = "X：";
            // 
            // nodeNameBox
            // 
            this.nodeNameBox.Location = new System.Drawing.Point(91, 13);
            this.nodeNameBox.Name = "nodeNameBox";
            this.nodeNameBox.Size = new System.Drawing.Size(168, 25);
            this.nodeNameBox.TabIndex = 1;
            this.nodeNameBox.TextChanged += new System.EventHandler(this.nodeNameBox_textChanged);
            // 
            // nodeNameLabel
            // 
            this.nodeNameLabel.AutoSize = true;
            this.nodeNameLabel.Location = new System.Drawing.Point(3, 16);
            this.nodeNameLabel.Name = "nodeNameLabel";
            this.nodeNameLabel.Size = new System.Drawing.Size(82, 15);
            this.nodeNameLabel.TabIndex = 0;
            this.nodeNameLabel.Text = "站点名称：";
            // 
            // metroGraphView
            // 
            this.metroGraphView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroGraphView.BackColor = System.Drawing.Color.White;
            this.metroGraphView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroGraphView.clickNode = null;
            this.metroGraphView.endNode = null;
            this.metroGraphView.Location = new System.Drawing.Point(12, 31);
            this.metroGraphView.Name = "metroGraphView";
            this.metroGraphView.scrollX = 0;
            this.metroGraphView.scrollY = 0;
            this.metroGraphView.shortestPath = null;
            this.metroGraphView.Size = new System.Drawing.Size(1417, 620);
            this.metroGraphView.startNode = null;
            this.metroGraphView.TabIndex = 0;
            this.metroGraphView.zoomScale = 1F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 663);
            this.Controls.Add(this.editGroup);
            this.Controls.Add(this.metroGraphView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "上海市地铁线路图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editGroup.ResumeLayout(false);
            this.editGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroGraphView metroGraphView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel editGroup;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox Y_textBox;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.TextBox X_textBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox nodeNameBox;
        private System.Windows.Forms.Label nodeNameLabel;
    }
}

