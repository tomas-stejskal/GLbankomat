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
    public partial class MenuAfterLogin : UserControl
    {
        private AppLanguage lang;
        private string[] text;
        public MenuAfterLogin(AppLanguage l)
        {
            InitializeComponent();
            lang = l;
            string txt;
            if(lang == AppLanguage.Slovensky)
            {
                txt = File.ReadAllText(".\\slovensky.txt");
            }else
            {
                txt = File.ReadAllText(".\\english.txt");
            }
            text = txt.Split('\n');
            label1.Text = text[3];
            label2.Text = text[4];
            label3.Text = text[5];
            label4.Text = text[6];
        }
    }
}
