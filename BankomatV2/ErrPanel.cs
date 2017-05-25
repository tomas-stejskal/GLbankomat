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
    public partial class ErrPanel : UserControl
    {
        private AppLanguage lang;
        public ErrPanel(AppLanguage j)
        {
            InitializeComponent();
            this.lang = j;
            string[] text;

            if (lang == AppLanguage.Slovensky)
            {
                text = File.ReadAllText("slovensky.txt").Split('\n');
            }
            else
            {
                text = File.ReadAllText("english.txt").Split('\n');
            }
            label1.Text = text[0];
        }
    }
}
