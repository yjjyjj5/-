
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块核心
{
    public abstract class Father
    {
        //变形变量
        public int i = 0;
        public abstract int[,] Get();
        public abstract void Change();
        public int y = 0;
        public int x = 3;
    }
}
