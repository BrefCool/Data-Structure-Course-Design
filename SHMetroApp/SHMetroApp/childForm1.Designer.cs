namespace SHMetroApp
{
    partial class childForm1
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
            this.lineNameLabel = new System.Windows.Forms.Label();
            this.lineNameBox = new System.Windows.Forms.TextBox();
            this.lineColorLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lineColorShowArea = new System.Windows.Forms.Panel();
            this.colorSelectBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineNameLabel
            // 
            this.lineNameLabel.AutoSize = true;
            this.lineNameLabel.Location = new System.Drawing.Point(12, 21);
            this.lineNameLabel.Name = "lineNameLabel";
            this.lineNameLabel.Size = new System.Drawing.Size(82, 15);
            this.lineNameLabel.TabIndex = 0;
            this.lineNameLabel.Text = "线路名称：";
            // 
            // lineNameBox
            // 
            this.lineNameBox.Location = new System.Drawing.Point(91, 18);
            this.lineNameBox.Name = "lineNameBox";
            this.lineNameBox.Size = new System.Drawing.Size(100, 25);
            this.lineNameBox.TabIndex = 1;
            // 
            // lineColorLabel
            // 
            this.lineColorLabel.AutoSize = true;
            this.lineColorLabel.Location = new System.Drawing.Point(197, 21);
            this.lineColorLabel.Name = "lineColorLabel";
            this.lineColorLabel.Size = new System.Drawing.Size(82, 15);
            this.lineColorLabel.TabIndex = 2;
            this.lineColorLabel.Text = "线路颜色：";
            // 
            // lineColorShowArea
            // 
            this.lineColorShowArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lineColorShowArea.Location = new System.Drawing.Point(285, 18);
            this.lineColorShowArea.Name = "lineColorShowArea";
            this.lineColorShowArea.Size = new System.Drawing.Size(110, 25);
            this.lineColorShowArea.TabIndex = 3;
            this.lineColorShowArea.Visible = false;
            // 
            // colorSelectBtn
            // 
            this.colorSelectBtn.Location = new System.Drawing.Point(424, 17);
            this.colorSelectBtn.Name = "colorSelectBtn";
            this.colorSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.colorSelectBtn.TabIndex = 4;
            this.colorSelectBtn.Text = "选取颜色";
            this.colorSelectBtn.UseVisualStyleBackColor = true;
            this.colorSelectBtn.Click += new System.EventHandler(this.colorSelectBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(320, 74);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "确定";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(424, 74);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // childForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 110);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.colorSelectBtn);
            this.Controls.Add(this.lineColorShowArea);
            this.Controls.Add(this.lineColorLabel);
            this.Controls.Add(this.lineNameBox);
            this.Controls.Add(this.lineNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 157);
            this.MinimumSize = new System.Drawing.Size(529, 157);
            this.Name = "childForm1";
            this.Text = "新建线路";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineNameLabel;
        private System.Windows.Forms.TextBox lineNameBox;
        private System.Windows.Forms.Label lineColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel lineColorShowArea;
        private System.Windows.Forms.Button colorSelectBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}