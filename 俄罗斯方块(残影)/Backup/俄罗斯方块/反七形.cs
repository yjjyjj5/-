using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 俄罗斯方块
{
    class 反七形:方块
    {
        public int[,] Dzt1 { get; set; }
        public int[,] Dzt2 { get; set; }
        public int[,] Dzt3 { get; set; }
        public int[,] Dzt4 { get; set; }

        public 反七形()
        {
            Dzt1 = new int[4, 4];
            Dzt2 = new int[4, 4];
            Dzt3 = new int[4, 4];
            Dzt4 = new int[4, 4];
            Dzt1[3, 1] = Dzt1[2, 1] = Dzt1[1, 2] = Dzt1[1, 1] = 1;
            Dzt2[3, 3] = Dzt2[3, 2] = Dzt2[3, 1] = Dzt2[2, 1] = 1;
            Dzt3[3, 3] = Dzt3[3, 2] = Dzt3[2, 3] = Dzt3[1, 3] = 1;
            Dzt4[2, 3] = Dzt4[1, 3] = Dzt4[1, 2] = Dzt4[1, 1] = 1;

        }

        public override void Change()
        {
            this.CurrentDzt++;
            if (this.CurrentDzt == 4)
                this.CurrentDzt = 0;
        }
        public override int[,] GetCurrentDzt()
        {
            if (this.CurrentDzt == 0) return Dzt1;
            else if (this.CurrentDzt == 1) return Dzt2;
            else if (this.CurrentDzt == 2) return Dzt3;
            else return Dzt4;
        }
    }
}
