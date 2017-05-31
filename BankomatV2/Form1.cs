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
        cardBlocked,
        makeTransaction
    }

    public partial class Form1 : Form
    {
        private DysplayPhase dPhase = DysplayPhase.selectLang;
        private AppLanguage appLang;
        private string account_id;
        private long card_id;
        private Phase1Panel pp1;
        private ErrPanel errPanel;
        private EnterPin enterPin;
        private string user_input = "";

        public void setuserData(string aId,long cId)
        {
            account_id = aId;
            card_id = cId;
          /*  DatabaseInterface dbi = DatabaseInterface.getInstance();
            bool isBlocked = dbi.isCardBlocked(card_id.ToString());
            if (isBlocked)
            {
                dPhase = DysplayPhase.cardBlocked;
                Console.WriteLine(isBlocked);
            }*/
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
            if (DysplayPhase.selectLang == dPhase)
            {
                appLang = AppLanguage.Slovensky;
                pp1.Dispose();
                checkCardValidity();
            }
            
        }
        //set english language
        private void button20_Click(object sender, EventArgs e)
        {
            if(DysplayPhase.selectLang == dPhase)
            {
                appLang = AppLanguage.English;
                pp1.Dispose();
                checkCardValidity();
            }
           
        }

        private void checkCardValidity()
        {
            Console.WriteLine(appLang);
            DatabaseInterface dat = DatabaseInterface.getInstance();
            if (dat.isCardBlocked(card_id.ToString()))
            {
                dPhase = DysplayPhase.cardBlocked;
                errPanel = new ErrPanel(appLang);
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(errPanel);
            }
            else
            {
                dPhase = DysplayPhase.enterPin;
                enterPin = new EnterPin(appLang);
                panel2.Controls.Clear();
                panel2.Controls.Add(enterPin);
            }
        }
        /*******************************************************/
        //1
        private void button1_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "1";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }
        //2
        private void button2_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "2";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }
        //3
        private void button3_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "3";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "4";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "5";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "6";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "7";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "8";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "9";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }
        //0
        private void button11_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length < 4)
            {
                user_input += "0";
                enterPin.setPin(user_input);
                enterPin.unSetErr();
            }
        }
        //C
        private void button10_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin)
            {
                user_input = "";
                enterPin.setPin(user_input);
            }
        }
        //OK
        private void button12_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.enterPin && user_input.Length == 4)
            {
                DatabaseInterface di = DatabaseInterface.getInstance();
                bool isPinValid = di.isPinValid(user_input, card_id.ToString());
                
                if (isPinValid)
                {
                    di.resetWrongTry(card_id.ToString());
                }else
                {
                    bool isCardBlockt = di.isCardBlocked(card_id.ToString());
                    if (isCardBlockt)
                    {
                        dPhase = DysplayPhase.cardBlocked;
                        errPanel = new ErrPanel(appLang);
                        this.panel2.Controls.Clear();
                        this.panel2.Controls.Add(errPanel);
                    }else
                    {
                        di.setWrongTry(card_id.ToString());
                        enterPin.setErr();
                        user_input = "";
                        enterPin.setPin(user_input);
                    }
                }
            }
        }
        /*********************************************************************************/
    }
}
