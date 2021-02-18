using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 俄罗斯方块核心
{
    public partial class Form1 : Form
    {
        //1.准备一个可绘制区域(无用)
        Graphics g;
        //2.准备一支红色的画刷
        Brush r = Brushes.Red;
        Brush y = Brushes.Yellow;
        //3.所有画法都存在 g 当中,我们要做的就是去调用 g 里面的画法
        public Form1()
        {
            InitializeComponent();
            //2.让当前窗体成为可绘制区域(this可以被用来绘制了)
            g = this.CreateGraphics();
        }

        int i = 10;

        int[,] arr;
        Father f;
        private void button1_Click(object sender, EventArgs e)
        {
            //1.产生随机方块
            Random rr = new Random();
            int num = rr.Next(0, 2);
            if (num == 0)
            {
                f = new One();
            }
            else
            {
                f = new L();
            }

            arr = f.Get();


            g.Clear(Color.LightGray);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (arr[j, i] == 1)
                    {
                        g.FillRectangle(y, i * 50 + i, j * 50 + j, 50, 50);
                    }
                    else
                    {
                        g.FillRectangle(r, i * 50 + i, j * 50 + j, 50, 50);
                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Change();
            arr = f.Get();


            g.Clear(Color.LightGray);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (arr[j, i] == 1)
                    {
                        g.FillRectangle(y, i * 50 + i, j * 50 + j, 50, 50);
                    }
                    else
                    {
                        g.FillRectangle(r, i * 50 + i, j * 50 + j, 50, 50);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f.y++;
            arr = f.Get();
            g.Clear(Color.LightGray);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (arr[j, i] == 1)
                    {
                        g.FillRectangle(y, (i * 50 + i), (j * 50 + j) + f.y * 50, 50, 50);
                    }
                    else
                    {
                        g.FillRectangle(r, (i * 50 + i), (j * 50 + j) + f.y * 50, 50, 50);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //1.方块是否掉落到了最低部

            //2.老方块要停留在底部,同时要产生新的方块

            //3.控制方块不停的下降

            //4.判断在下降的同时是否有其它指令(左,右,变形)

            //5.你想要的其它逻辑
        }
    }
}
