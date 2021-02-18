using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 俄罗斯方块
{
    abstract class 方块
    {
        public int CurrentDzt { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public 方块()
        {
            this.Col = 3;
        }

        public void MoveLeft()
        {
            this.Col--;
        }
        public void MoveRight()
        {
            this.Col++;
        }
        public void MoveDown()
        {
            this.Row++;
        }
        public abstract void Change();
        public abstract int[,] GetCurrentDzt();

        public Point Get幻影位置(int[,] map)
        {
            Point p = new Point(this.Col, this.Row);

            while (true)
            {
                p.Y++;
                if (!this.Check(p, map))
                {
                    p.Y--;
                    break;
                }
            }

            return p;
        }

        /// <summary>
        /// 检查是否出界
        /// </summary>
        private bool Check(Point point, int[,] map)
        {
            int[,] dzt = this.GetCurrentDzt();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dzt[i, j] == 1)
                    {//此点需要判断是否已出界
                        //左
                        if (j + point.X < 0) return false;
                        //右
                        if (j + point.X > 9) return false;
                        //下
                        if (i + point.Y > 14) return false;
                        //重叠
                        if (map[i + point.Y, j + point.X] == 1) return false;
                    }
                }
            }
            return true;
        }
    }
}
