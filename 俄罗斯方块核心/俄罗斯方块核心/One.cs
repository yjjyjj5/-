using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块核心
{
    public class One : Father
    {
        //形状1
        int[,] a1 = new int[4, 4];
        //形状2
        int[,] a2 = new int[4, 4];
        //构造函数,对形状进行初始化
        public One()
        {
            a1[3, 0] = a1[2, 0] = a1[1, 0] = a1[0, 0] = 1;
            a2[1, 3] = a2[1, 2] = a2[1, 1] = a2[1, 0] = 1;
        }

        public override void Change()
        {
            if (i == 0)
                i = 1;
            else
                i = 0;
        }

        public override int[,] Get()
        {
            if(i == 0)
                return a1;
            else
                return a2;
        }
    }
}
