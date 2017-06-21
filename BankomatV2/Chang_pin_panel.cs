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
    public partial class Chang_pin_panel : UserControl
    {
        private AppLanguage lang;
        private string[] data;
        private string old_pin;
        private string new_pin1;
        private string new_pin2;
        private int status = 1;
        private string input = "";
        private long card_id;

        public Chang_pin_panel(AppLanguage l, long cardID)
        {
            InitializeComponent();
            lang = l;
            card_id = cardID;
            if(lang == AppLanguage.Slovensky)
            {
                data = File.ReadAllText(".\\slovensky.txt").Split('\n');
            }else
            {
                data = File.ReadAllText(".\\english.txt").Split('\n');
            }
            label1.Text = data[11];
            label3.Text = data[14];
            label2.Text = "";
        }

        public void updateInput(string inp)
        {
            input = inp;
            textBox1.Text = input;
        }

        public void pushPhase()
        {
            Console.WriteLine("phush call" + input+ " "+input.Length);
            if (status == 1 && input.Length == 4)
            {
                status = 2;
                old_pin = input;
                input = "";
                textBox1.Text = "";
                label2.Text = "";
                label2.ForeColor = Color.Red;
                label1.Text = data[12];
            }
            if (status == 2 && input.Length == 4)
            {
                status = 3;
                new_pin1 = input;
                input = "";
                textBox1.Text = "";
                label1.Text = data[13];
            }
            if (status == 3 && input.Length == 4)
            {
                status = 4;
                new_pin2 = input;
                input = "";
                textBox1.Text = "";
                label1.Text = data[14];
            }
            if (status == 4)
            {
                if (!String.Equals(new_pin1, new_pin2))
                {
                    label2.Text = data[15];
                    input = "";
                    textBox1.Text = "";
                    old_pin = "";
                    new_pin1 = "";
                    new_pin2 = "";
                    status = 1;
                    label1.Text = data[11];
                    return;
                }
                DatabaseInterface di = DatabaseInterface.getInstance();
                int db_response = di.change_pin(card_id, old_pin, new_pin1);
                if (db_response == -1)
                {
                    label2.Text = "err";
                    return;
                }
                if (db_response == 1)
                {
                    label1.Text = data[11];
                    label2.Text = data[16];
                    input = "";
                    textBox1.Text = "";
                    old_pin = "";
                    new_pin1 = "";
                    new_pin2 = "";
                    status = 1;
                    return;
                }
                if (db_response == 0)
                {
                    label2.Text = data[17];
                    label2.ForeColor = Color.Green;
                }
            }
        }
    }
}
