using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BankomatV2
{
    public partial class EnterPin : UserControl
    {
        public EnterPin(AppLanguage l)
        {
            InitializeComponent();
            string[] text;
            if (l == AppLanguage.Slovensky)
            {
                text = File.ReadAllText("slovensky.txt").Split('\n');
            }
            else
            {
                text = File.ReadAllText("english.txt").Split('\n');
            }
            label1.Text = text[1];

        }

        public void setPin(string pin)
        {
            textBox1.Text = pin;
        }
    }
}
