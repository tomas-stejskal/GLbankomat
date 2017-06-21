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
    public partial class Account_status : UserControl
    {

        public Account_status(string status,AppLanguage lang)
        {
            InitializeComponent();

            string dat;
            if(lang == AppLanguage.English)
            {
                dat = File.ReadAllText(".\\english.txt");
            }
            else
            {
                dat = File.ReadAllText(".\\slovensky.txt");
            }
            string[] data = dat.Split('\n');
            label1.Text = data[7];
            label4.Text = data[10];
            string[] stats = status.Split(';');
            label3.Text = stats[0];
            if (String.Equals("T", stats[1]))
            {
                label2.Text = data[9];
            }else
            {
                label2.Text = data[8];
            }
            
        }
    }
}
