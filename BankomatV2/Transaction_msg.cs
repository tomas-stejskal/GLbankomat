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
    public partial class Transaction_msg : UserControl
    {
        public Transaction_msg(AppLanguage l,int code)
        {
            InitializeComponent();
            string[] data;
            if (l == AppLanguage.English)
            {
                data = File.ReadAllText(".\\english.txt").Split('\n');
            }else
            {
                data = File.ReadAllText(".\\slovensky.txt").Split('\n');
            }
            if (code == 0)
            {
                label1.Text = data[21];
            }else if(code == 1)
            {
                label1.Text = data[20];
            }else
            {
                label1.Text = data[19];
            }
        }
    }
}
