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
    public partial class 窗体演示 : Form
    {
        public 窗体演示()
        {
            InitializeComponent();
        }

        private void 窗体演示_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }
    }
}
