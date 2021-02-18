using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块
{
    class 田字形:方块
    {
        public int[,] Dzt1 { get; set; }

        public 田字形()
        {
            Dzt1 = new int[4, 4];
            Dzt1[2, 2] = Dzt1[2, 1] = Dzt1[1, 2] = Dzt1[1, 1] = 1;
        }

        public override void Change()
        {
            
        }
        public override int[,] GetCurrentDzt()
        {
            return Dzt1;
        }
    }
}
