using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 俄罗斯方块
{
    public partial class FrmMain : Form
    {
        Graphics g;
        Graphics g2;
        int[,] map;
        方块 fk;     //当前方块
        方块 fkNext; //下一个方块

        public FrmMain()
        {
            InitializeComponent();
            g = this.pGame.CreateGraphics();
            g2 = this.pNext.CreateGraphics();
            map = new int[15, 10];
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void 画游戏()
        {
            画地图();
            画当前方块();
            画下一个方块();
        }

        public void 画地图()
        {
            g.Clear(Color.Black);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                        g.FillRectangle(Brushes.Blue, j * 25, i * 25, 24, 24);
                    else
                        g.FillRectangle(Brushes.White, j * 25, i * 25, 24, 24);
                }
            }
        }

        Pen penGhost = new Pen(Color.FromArgb(100, 255, 0, 0), 4);
        public void 画当前方块()
        {
            if (fk == null) return;

            //画幻影
            int[,] dzt = fk.GetCurrentDzt();
            Point p = fk.Get幻影位置(map);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                        g.DrawRectangle(penGhost, (j * 25) + (p.X * 25) + 3, (i * 25) + (p.Y * 25) + 3, 24 - 6, 24 - 6);
                }
            }

            //画实体
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                        g.FillRectangle(Brushes.Red, (j * 25) + (fk.Col * 25), (i * 25) + (fk.Row * 25), 24, 24);
                }
            }
        }

        public void 画下一个方块()
        {
            if (fkNext == null) return;

            int[,] dzt = fkNext.GetCurrentDzt();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                        g2.FillRectangle(Brushes.Red, j * 25, i * 25, 24, 24);
                    else
                        g2.FillRectangle(Brushes.White, j * 25, i * 25, 24, 24);
                }
            }
        }

        public void 产生新方块()
        {
            if (fkNext == null)
                产生下一个方块();

            //把下一下方块做为当前方块
            fk = fkNext;

            //再产生下一个方块
            产生下一个方块();
        }

        public void 产生下一个方块()
        {
            Random r = new Random();
            int num = r.Next(0, 3);
            if (num == 0) fkNext = new 山字形();
            else if (num == 1) fkNext = new 七字形();
            else fkNext = new 一字形();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.wmpBackground.URL = "背景音乐.mp3";
            产生新方块();
            画游戏();
            this.tmrGame.Start();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (fk == null) return;

            if (e.KeyCode == Keys.A)
            {//左
                fk.MoveLeft();
                if (!Check())
                    fk.MoveRight();
            }
            else if (e.KeyCode == Keys.D)
            {//右
                fk.MoveRight();
                if (!Check())
                    fk.MoveLeft();
            }
            else if (e.KeyCode == Keys.W)
            {//变形
                fk.Change();
                if (!Check())
                    fk.CurrentDzt--;
            }
            else if (e.KeyCode == Keys.S)
            {//下
                方块下移();
            }
            else if (e.KeyCode == Keys.Space)
            {//瞬移
                while (true)
                {
                    if (!方块下移())
                        break;
                }
            }
            画游戏();
        }

        /// <summary>
        /// 检查是否出界
        /// </summary>
        private bool Check()
        {
            int[,] dzt = fk.GetCurrentDzt();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                    {//此点需要判断是否已出界
                        //左
                        if (j + fk.Col < 0) return false;
                        //右
                        if (j + fk.Col > 9) return false;
                        //下
                        if (i + fk.Row > 14) return false;
                        //重叠
                        if (map[i + fk.Row, j + fk.Col] == 1) return false;
                    }
                }
            }
            return true;
        }

        private void pGame_Paint(object sender, PaintEventArgs e)
        {
            画游戏();
        }

        private void 冻结当前方块()
        {
            int[,] dzt = fk.GetCurrentDzt();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                    {//这4个格子需要冻结
                        map[i + fk.Row, j + fk.Col] = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 检查是否有需要消除的行
        /// </summary>
        private void btnCheck消除_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {//逐行逐行的检查，是否需要消除
                for (int j = 0; j < 10; j++)
                {//逐个格子检查，是否为0
                    if (map[i, j] == 0) break; //跳出当前行的检查，进行下一行的检查

                    if (j == 9)
                    {//这是一个满行
                        MessageBox.Show("第" + i + "行需要消除");
                    }
                }
            }
        }

        public void 干掉指定的行(int rowIndex)
        {
            //MessageBox.Show(rowIndex.ToString());

            //1) 去掉这一行
            for (int j = 0; j < 10; j++)
            {
                map[rowIndex, j] = 0;
                //让线程休眠100毫秒，在100毫秒之后，叫醒线程
                画游戏();
                Thread.Sleep(10);
            }



            //2) 上面的行往下掉
            for (int i = rowIndex; i > 0; i--)
            {//从下往上数，一行一行的掉落
                for (int j = 0; j < 10; j++)
                {//每行有10列，每列都要掉
                    map[i, j] = map[i - 1, j];
                }
            }
        }

        public void 消除行()
        {
            //有没有要消除的行
            bool has = false;
            //检查是否有需要消除的行
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 0) break;

                    if (j == 9)
                    {//此行需要消除
                        has = true;
                        干掉指定的行(i);
                    }
                }
            }

            //有消除的行
            if (has)
            {//抖一抖
                pGame.Top += 2;
                Thread.Sleep(30);
                pGame.Top -= 2;
                Thread.Sleep(30);
                pGame.Top += 2;
                Thread.Sleep(30);
                pGame.Top -= 2;
                Thread.Sleep(30);
                pGame.Top += 2;
                Thread.Sleep(30);
                pGame.Top -= 2;
                Thread.Sleep(30);
            }
        }

        private void btn消除行_Click(object sender, EventArgs e)
        {
            消除行();
            画游戏();
        }

        public bool 方块下移()
        {
            fk.MoveDown();
            if (!Check())
            {
                fk.Row--;
                冻结当前方块();
                产生新方块();
                消除行();
                游戏结束();
                return false; //表示下移失败，已被冻住
            }
            return true; //表示下移成功
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            方块下移();
            画游戏();
        }

        public void 游戏结束()
        {
            for (int j = 0; j < 10; j++)
            {
                if (map[1, j] == 1)
                {//游戏结束
                    this.tmrGame.Stop();
                    fk = null;
                    画游戏();
                    MessageBox.Show("游戏结束");
                    break;
                }
            }
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //清空地图
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = 0;
                }
            }

            产生新方块();
            画游戏();
            this.tmrGame.Start();
        }
    }
}
