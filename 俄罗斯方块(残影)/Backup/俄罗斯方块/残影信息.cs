using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块
{
    class 残影信息
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int[,] Dzt { get; set; }

        public 残影信息() { }
        public 残影信息(int row, int col, int[,] dzt)
        {
            this.Row = row;
            this.Col = col;
            this.Dzt = dzt;
        }
    }
}
