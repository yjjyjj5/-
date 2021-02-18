using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块
{
    abstract class 方块
    {
        public int CurrentDzt { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public 方块()
        {
            this.Row = 11;
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
        public void MoveUp()
        {
            this.Row--;
        }
        public abstract void Change();
        public abstract int[,] GetCurrentDzt();
    }
}
