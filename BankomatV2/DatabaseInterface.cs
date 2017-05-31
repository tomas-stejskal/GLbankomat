using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankomatV2
{
    
    class DatabaseInterface
    {
        private MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=glbank;UID=root;PASSWORD=1234;");
        private static DatabaseInterface dat = new DatabaseInterface();

        private  DatabaseInterface()
        {
           // string con_str = "SERVER=localhost;DATABASE=glbank;UID=root;PASSWORD=1234;";
           // conn = new MySqlConnection(con_str);
        }
        public static DatabaseInterface getInstance()
        {
            return dat;
        }

        private bool openConn()
        {
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
        private bool closeConn()
        {
            try
            {
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
        /*******************************************************************/

        public string getAccountId(long card_number)
        {
            string result = "";
            string query = "select * from cards where cardnumber = '"+card_number+"';";
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = reader["idacc"].ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                closeConn();
            }
            return result;
        }
        /**************************************************************************/
        public bool isCardBlocked(string card_number)
        {
            bool answer = true;
            string query = "select blocked from cards where cardnumber="+card_number+";";
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        answer = reader["blocked"].ToString().Equals("T");
                    }
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                closeConn();
            }

            return answer;
        }
        /**************************************************************************************************/

        public bool isPinValid(string pin,string card_number)
        {
            bool answer = false;
            string query = "select * from cards where cardnumber like'" + card_number+"';";
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query,conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string res = reader["pin_code"].ToString();
                        Console.WriteLine(res + "    " + pin);
                        answer = res.Equals(pin);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                closeConn();
            }
            return answer;
        }

        public void setWrongTry(string card_num)
        {
            string query = "update cards set vrong_try = vrong_try + 1 where cardnumber="+card_num+";";
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                closeConn();
            }
            string q2 = "select * from cards where cardnumber like'" + card_num + "';";
            int wrongryCounter = 0;
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(q2, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        wrongryCounter = (int)reader["vrong_try"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                closeConn();
            }
            if (wrongryCounter >= 3)
            {
                string q3 = "update cards set blocked = 'T' where cardnumber=" + card_num + ";";
                if (openConn())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(q3, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    closeConn();
                }
            }
        }

        public void resetWrongTry(string card_num)
        {
            string query = "update cards set vrong_try = 0 where cardnumber=" + card_num + ";";
            if (openConn())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                closeConn();
            }
            
        }
    } 
}
