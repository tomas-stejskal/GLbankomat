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
    public partial class Pick_up_cash : UserControl
    {
        private bool can_push = true;
        private string accID;
        private Form1 parent;
        public Pick_up_cash(string accID,long cardID,AppLanguage la,Form1 f)
        {
            InitializeComponent();
            string[] data;
            if(la == AppLanguage.Slovensky)
            {
                data = File.ReadAllText(".\\slovensky.txt").Split('\n');
            }
            else
            {
                data = File.ReadAllText(".\\english.txt").Split('\n');
            }
            label1.Text = data[18];
            this.accID = accID;
            this.parent = f;
        }

        private bool ready = false;
        public void pushTransaction(double balance)
        {
            if (!ready)
            {
                ready = true;
                return;
            }
            if (!can_push)
                return;
            can_push = false;

            DatabaseInterface di = DatabaseInterface.getInstance();
            int status = di.pcik_up_cash(accID, balance);
            parent.showTransactionMsg(status);
        }
    }
}
