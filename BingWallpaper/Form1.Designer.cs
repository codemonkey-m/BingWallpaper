namespace BingWallpaper
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sadadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Center = new System.Windows.Forms.ToolStripMenuItem();
            this.Tiling = new System.Windows.Forms.ToolStripMenuItem();
            this.Stretching = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_Img_Dir = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh_Img = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.Button_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Bing壁纸";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sadadaToolStripMenuItem,
            this.Open_Img_Dir,
            this.Refresh_Img,
            this.AutoRun,
            this.About,
            this.Button_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 158);
            // 
            // sadadaToolStripMenuItem
            // 
            this.sadadaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Center,
            this.Tiling,
            this.Stretching});
            this.sadadaToolStripMenuItem.Enabled = false;
            this.sadadaToolStripMenuItem.Name = "sadadaToolStripMenuItem";
            this.sadadaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sadadaToolStripMenuItem.Text = "显示方式";
            this.sadadaToolStripMenuItem.Visible = false;
            // 
            // Center
            // 
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(100, 22);
            this.Center.Text = "居中";
            this.Center.Click += new System.EventHandler(this.Center_Click);
            // 
            // Tiling
            // 
            this.Tiling.Name = "Tiling";
            this.Tiling.Size = new System.Drawing.Size(100, 22);
            this.Tiling.Text = "平铺";
            this.Tiling.Click += new System.EventHandler(this.Tiling_Click);
            // 
            // Stretching
            // 
            this.Stretching.Name = "Stretching";
            this.Stretching.Size = new System.Drawing.Size(100, 22);
            this.Stretching.Text = "拉伸";
            this.Stretching.Click += new System.EventHandler(this.Stretching_Click);
            // 
            // Open_Img_Dir
            // 
            this.Open_Img_Dir.Name = "Open_Img_Dir";
            this.Open_Img_Dir.Size = new System.Drawing.Size(180, 22);
            this.Open_Img_Dir.Text = "打开图片目录";
            this.Open_Img_Dir.Click += new System.EventHandler(this.Open_Img_Dir_Click);
            // 
            // Refresh_Img
            // 
            this.Refresh_Img.Name = "Refresh_Img";
            this.Refresh_Img.Size = new System.Drawing.Size(180, 22);
            this.Refresh_Img.Text = "手动刷新";
            this.Refresh_Img.Click += new System.EventHandler(this.Refresh_Img_Click);
            // 
            // AutoRun
            // 
            this.AutoRun.Name = "AutoRun";
            this.AutoRun.Size = new System.Drawing.Size(180, 22);
            this.AutoRun.Text = "开机启动";
            this.AutoRun.Click += new System.EventHandler(this.AutoRun_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(180, 22);
            this.Button_Exit.Text = "退出";
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(180, 22);
            this.About.Text = "关于";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sadadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Center;
        private System.Windows.Forms.ToolStripMenuItem Button_Exit;
        private System.Windows.Forms.ToolStripMenuItem Tiling;
        private System.Windows.Forms.ToolStripMenuItem Stretching;
        private System.Windows.Forms.ToolStripMenuItem AutoRun;
        private System.Windows.Forms.ToolStripMenuItem Refresh_Img;
        private System.Windows.Forms.ToolStripMenuItem Open_Img_Dir;
        private System.Windows.Forms.ToolStripMenuItem About;
    }
}

