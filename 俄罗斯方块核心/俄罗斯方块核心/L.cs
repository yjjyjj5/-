using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块核心
{
    class L : Father
    {
        //形状1
        int[,] a1 = new int[4, 4];
        //形状2
        int[,] a2 = new int[4, 4];
        //形状3
        int[,] a3 = new int[4, 4];
        //形状4
        int[,] a4 = new int[4, 4];
        //构造函数,对形状进行初始化
        public L()
        {
            a1[2, 2] = a1[2, 1] = a1[1, 1] = a1[0, 1] = 1;
            a2[2, 1] = a2[1, 3] = a2[1, 2] = a2[1, 1] = 1;
            a3[3, 2] = a3[2, 2] = a3[1, 2] = a3[1, 1] = 1;
            a4[3, 2] = a4[3, 1] = a4[3, 0] = a4[2, 2] = 1;
        }
        
        public override void Change()
        {
            i++;
            if (i == 3)
                i = 0;
        }

        public override int[,] Get()
        {
            switch (i)
            {
                case 0: return a1;
                case 1: return a2;
                case 2: return a3;
                case 3: return a4;
                default: return a1;
            }
        }
    }
}
