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
    public enum AppLanguage
    {
        English,
        Slovensky
    }
    public enum DysplayPhase
    {
        selectLang,
        enterPin,
        makeTransaction
    }

    public partial class Form1 : Form
    {
        private DysplayPhase dPhase = DysplayPhase.selectLang;
        private AppLanguage appLang;
        private string account_id;
        private long card_id;
        Phase1Panel pp1;

        public void setuserData(string aId,long cId)
        {
            account_id = aId;
            card_id = cId;
        }

        public Form1()
        {
            InitializeComponent();
            pp1 = new Phase1Panel();
            this.panel2.Controls.Add(pp1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InsertCard ic = new InsertCard(this);
            ic.ShowDialog();
            label1.Text = "card NO. " + card_id;
        }

        //set slovak language
        private void button16_Click(object sender, EventArgs e)
        {
            appLang = AppLanguage.Slovensky;
            pp1.Dispose();
        }
        //set english language
        private void button20_Click(object sender, EventArgs e)
        {
            appLang = AppLanguage.English;
            pp1.Dispose();
        }
    }
}
