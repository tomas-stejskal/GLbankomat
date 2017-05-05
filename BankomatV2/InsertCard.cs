using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankomatV2
{
    public partial class InsertCard : Form
    {
        private Form1 patent;
        private bool funRunCucesful = false;

        public InsertCard(Form1 f1)
        {
            InitializeComponent();
            patent = f1;
        }

        private void InsertCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (funRunCucesful)
                return;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long val = (long)numericUpDown1.Value;
            DatabaseInterface di = new DatabaseInterface();
            string result = di.getAccountId(val);
            if (result.Equals(""))
            {
                label2.Text = "this card is not exist";
                label2.ForeColor = Color.Red;
                return;
            }
            else
            {
                patent.setuserData(result, val);
                funRunCucesful = true;
                this.Dispose();
            }
        }
    }
}
