namespace WorkTimeProgress
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.HProgressBar = new System.Windows.Forms.ProgressBar();
            this.VProgressBar = new WorkTimeProgress.VerticalProgressBar();
            this.SuspendLayout();
            // 
            // HProgressBar
            // 
            this.HProgressBar.BackColor = System.Drawing.Color.DarkGray;
            this.HProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HProgressBar.Location = new System.Drawing.Point(0, 0);
            this.HProgressBar.Name = "HProgressBar";
            this.HProgressBar.Size = new System.Drawing.Size(100, 100);
            this.HProgressBar.TabIndex = 0;
            this.HProgressBar.Value = 50;
            // 
            // VProgressBar
            // 
            this.VProgressBar.BackColor = System.Drawing.Color.DarkGray;
            this.VProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VProgressBar.Location = new System.Drawing.Point(0, 0);
            this.VProgressBar.Name = "VProgressBar";
            this.VProgressBar.Size = new System.Drawing.Size(100, 100);
            this.VProgressBar.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.HProgressBar);
            this.Controls.Add(this.VProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar HProgressBar;
        private VerticalProgressBar VProgressBar;
    }
}

