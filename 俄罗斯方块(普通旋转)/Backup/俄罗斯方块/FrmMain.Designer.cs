namespace 俄罗斯方块
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.pGame = new System.Windows.Forms.Panel();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.pNext = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrRotate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pGame
            // 
            this.pGame.Location = new System.Drawing.Point(12, 32);
            this.pGame.Name = "pGame";
            this.pGame.Size = new System.Drawing.Size(630, 467);
            this.pGame.TabIndex = 0;
            this.pGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pGame_Paint);
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 500;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // pNext
            // 
            this.pNext.Location = new System.Drawing.Point(648, 32);
            this.pNext.Name = "pNext";
            this.pNext.Size = new System.Drawing.Size(100, 100);
            this.pNext.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始游戏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始游戏ToolStripMenuItem
            // 
            this.开始游戏ToolStripMenuItem.Name = "开始游戏ToolStripMenuItem";
            this.开始游戏ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.开始游戏ToolStripMenuItem.Text = "开始游戏";
            this.开始游戏ToolStripMenuItem.Click += new System.EventHandler(this.开始游戏ToolStripMenuItem_Click);
            // 
            // tmrRotate
            // 
            this.tmrRotate.Interval = 20;
            this.tmrRotate.Tick += new System.EventHandler(this.tmrRotate_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 511);
            this.Controls.Add(this.pNext);
            this.Controls.Add(this.pGame);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "俄罗斯方块";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pGame;
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.Panel pNext;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始游戏ToolStripMenuItem;
        private System.Windows.Forms.Timer tmrRotate;
    }
}

