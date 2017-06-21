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
        makeTransaction,
        menuAfterLogin,
        acc_status_shown,
        change_pin
    }

    public partial class Form1 : Form
    {
        //var declaration
        private DysplayPhase dPhase = DysplayPhase.selectLang;
        private AppLanguage appLang;
        private string account_id;
        private long card_id;
        private Phase1Panel pp1; //select language
        private ErrPanel errPanel;
        private EnterPin enterPin;
        private string user_input = "";
        private MenuAfterLogin menuAlogin;
        private Account_status acc_status_panel;
        private Chang_pin_panel ch_pin_panel;
        private string ch_pin_in = "";
        private Pick_up_cash pickUpCash;
        private Transaction_msg trans_msg;
        //end of var declaration

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
        //if account_status >> BACK
        //if change_pin >> CANCEL
        //id cash_operation >> CANCEL
        private void button20_Click(object sender, EventArgs e)
        {
            if(DysplayPhase.selectLang == dPhase)
            {
                appLang = AppLanguage.English;
                pp1.Dispose();
                checkCardValidity();
            }
            if(dPhase == DysplayPhase.acc_status_shown)
            {
                panel2.Controls.Clear();
                acc_status_panel.Dispose();

                menuAlogin = new MenuAfterLogin(appLang);
                panel2.Controls.Add(menuAlogin);
                dPhase = DysplayPhase.menuAfterLogin;
            }
            if (dPhase == DysplayPhase.change_pin)
            {
                ch_pin_panel.Dispose();
                panel2.Controls.Clear();

                menuAlogin = new MenuAfterLogin(appLang);
                panel2.Controls.Add(menuAlogin);

                dPhase = DysplayPhase.menuAfterLogin;
                ch_pin_in = "";
            }
            if(dPhase == DysplayPhase.makeTransaction)
            {
                pickUpCash.Dispose();
                panel2.Controls.Clear();
                menuAlogin = new MenuAfterLogin(appLang);
                panel2.Controls.Add(menuAlogin);
                dPhase = DysplayPhase.menuAfterLogin;
                try
                {
                    trans_msg.Dispose();
                }
                catch { }
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "1";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "2";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "3";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "4";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "5";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "6";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "7";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "8";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "9";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length < 4)
            {
                ch_pin_in += "0";
                ch_pin_panel.updateInput(ch_pin_in);
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
            if (dPhase == DysplayPhase.change_pin)
            {
                ch_pin_in = "";
                ch_pin_panel.updateInput(ch_pin_in);
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
                    di.resetWrongTry(card_id.ToString());
                    dPhase = DysplayPhase.menuAfterLogin;
                    panel2.Controls.Clear();
                    menuAlogin = new MenuAfterLogin(appLang);
                    panel2.Controls.Add(menuAlogin);
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
            if (dPhase == DysplayPhase.change_pin && ch_pin_in.Length == 4)
            {
                ch_pin_in = "";
                ch_pin_panel.pushPhase();
            }
        }
        //if menu >> EXIT
        private void button18_Click(object sender, EventArgs e)
        {
            if(dPhase == DysplayPhase.menuAfterLogin)
            {
                panel2.Controls.Clear();
                try
                {
                    pp1.Dispose();
                }
                catch { }
                dPhase = DysplayPhase.selectLang;
                pp1 = new Phase1Panel();
                panel2.Controls.Add(pp1);
                user_input = "";
            }
            if (dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 100d;
                pickUpCash.pushTransaction(bal);
            }

        }
        //if menu >> ACCOUNT status
        private void button17_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.menuAfterLogin)
            {
                DatabaseInterface di = DatabaseInterface.getInstance();
                string status = di.getAccountStatus(account_id);
  
                panel2.Controls.Clear();
                menuAlogin.Dispose();

                acc_status_panel = new Account_status(status, appLang);
                panel2.Controls.Add(acc_status_panel);

                dPhase = DysplayPhase.acc_status_shown;
            }
            if (dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 30d;
                pickUpCash.pushTransaction(bal);
            }
        }
        //if menu >> CHANGE PIN
        private void button14_Click(object sender, EventArgs e)
        {
            if(dPhase == DysplayPhase.menuAfterLogin)
            {
                dPhase = DysplayPhase.change_pin;
                menuAlogin.Dispose();
                panel2.Controls.Clear();

                ch_pin_panel = new Chang_pin_panel(appLang, card_id);
                panel2.Controls.Add(ch_pin_panel);
            }
            if (dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 50d;
                pickUpCash.pushTransaction(bal);
            }
        }
        //if menu >> CASH OPERATIN
        //id cash operation >> get 10e
        private void button13_Click(object sender, EventArgs e)
        {
            if(dPhase == DysplayPhase.menuAfterLogin)
            {
                dPhase = DysplayPhase.makeTransaction;
                menuAlogin.Dispose();
                panel2.Controls.Clear();
                pickUpCash = new Pick_up_cash(account_id, card_id, appLang,this);
                panel2.Controls.Add(pickUpCash);
            }
            if(dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 10d;
                pickUpCash.pushTransaction(bal);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 200d;
                pickUpCash.pushTransaction(bal);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (dPhase == DysplayPhase.makeTransaction)
            {
                double bal = 5d;
                pickUpCash.pushTransaction(bal);
            }
        }
        /*********************************************************************************/

        public void showTransactionMsg(int code)
        {
            panel2.Controls.Clear();
            trans_msg = new Transaction_msg(appLang, code);
            panel2.Controls.Add(trans_msg);
        }
    }
}
