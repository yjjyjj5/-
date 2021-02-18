using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块
{
    class 一字形 : 方块
    {
        public int[,] Dzt1 { get; set; }
        public int[,] Dzt2 { get; set; }

        public 一字形()
        {
            Dzt1 = new int[4, 4];
            Dzt2 = new int[4, 4];
            Dzt1[1, 3] = Dzt1[1, 2] = Dzt1[1, 1] = Dzt1[1, 0] = 1;
            Dzt2[3, 1] = Dzt2[2, 1] = Dzt2[1, 1] = Dzt2[0, 1] = 1;
        }

        public override void Change()
        {
            this.CurrentDzt++;
            if (this.CurrentDzt == 2)
                this.CurrentDzt = 0;
        }
        public override int[,] GetCurrentDzt()
        {
            if (this.CurrentDzt == 0) return Dzt1;
            else return Dzt2;
        }
    }
}
