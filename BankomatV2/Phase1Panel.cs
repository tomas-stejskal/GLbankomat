using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankomatV2
{
    public partial class Phase1Panel : UserControl
    {
        public Phase1Panel()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "svk.png";
            pictureBox2.ImageLocation = "eng.png";
        }
    }
}
