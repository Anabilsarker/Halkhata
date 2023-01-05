using Halkhata.Model;
using Halkhata.UC;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows;

namespace Halkhata.Database
{
    public class MySqlDatabase
    {
        public static MySqlDatabase Instance { get; } = new MySqlDatabase();

        string connection_string = $"server={ConfigurationManager.AppSettings["server"]};user id={ConfigurationManager.AppSettings["userid"]};password={ConfigurationManager.AppSettings["pass"]};database=halkhata;";

        MySqlConnection sqlconnect;
        MySqlDataReader SqlReader;
        MySqlCommand cmd;
        public void Initialize_DB()
        {
            try
            {
                string connection = $"server={ConfigurationManager.AppSettings["server"]};user id={ConfigurationManager.AppSettings["userid"]};password={ConfigurationManager.AppSettings["pass"]};";
                sqlconnect = new MySqlConnection(connection);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = "SHOW DATABASES";
                SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    for (int i = 0; i < SqlReader.FieldCount; i++)
                    {
                        if (SqlReader.GetString(i).Contains("halkhata"))
                        {
                            Console.WriteLine("DB found.");
                            Dispose();
                            return;
                        }
                    }
                }
                SqlReader.Close();
                cmd.CommandText = "CREATE DATABASE halkhata";
                cmd.ExecuteReader();
                Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dispose();
            }
        }

        public void Create_Table_User()
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = "SHOW TABLES";
                SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    for (int i = 0; i < SqlReader.FieldCount; i++)
                    {
                        if (SqlReader.GetString(i).Contains("user"))
                        {
                            Console.WriteLine("Table found.");
                            SqlReader.Close();
                            return;
                        }
                    }
                }
                SqlReader.Close();
                cmd.CommandText = "CREATE TABLE user (email_id VARCHAR(255) NOT NULL, PRIMARY KEY (email_id), password VARCHAR(255), name VARCHAR(255), total_earned DOUBLE(15, 5), total_spent DOUBLE(15, 5), loan DOUBLE(15, 5));INSERT INTO user (email_id,password,name,total_earned,total_spent,loan) VALUES('admin','admin','admin','0.0','0.0','0.0');";
                SqlReader = cmd.ExecuteReader();
                Console.WriteLine("user table created");
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dispose();
            }
        }

        public void Create_Table_Expences()
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = "SHOW TABLES";
                SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    for (int i = 0; i < SqlReader.FieldCount; i++)
                    {
                        if (SqlReader.GetString(i).Contains("expences"))
                        {
                            Console.WriteLine("Table found.");
                            SqlReader.Close();
                            return;
                        }
                    }
                }
                SqlReader.Close();
                cmd.CommandText = "CREATE TABLE expences (email_id VARCHAR(255), spent_on VARCHAR(255) NOT NULL, amount DOUBLE(15, 5), date DATE, FOREIGN KEY (email_id) REFERENCES user(email_id));";
                SqlReader = cmd.ExecuteReader();
                Console.WriteLine("expences table created");
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dispose();
            }
        }
        public void Create_Table_Loan()
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = "SHOW TABLES";
                SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    for (int i = 0; i < SqlReader.FieldCount; i++)
                    {
                        if (SqlReader.GetString(i).Contains("loan"))
                        {
                            Console.WriteLine("Table found.");
                            SqlReader.Close();
                            return;
                        }
                    }
                }
                SqlReader.Close();
                cmd.CommandText = "CREATE TABLE loan (email_id VARCHAR(255), loan_request_reason LONGTEXT NOT NULL, amount DOUBLE(15, 5), category VARCHAR(255), FOREIGN KEY (email_id) REFERENCES user(email_id));";
                SqlReader = cmd.ExecuteReader();
                Console.WriteLine("loan table created");
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dispose();
            }
        }
        public bool Update_Table_User(string user_id, string password, string name, double total_earned, double total_spent, double loan)
        {
            sqlconnect = new MySqlConnection(connection_string);
            sqlconnect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = sqlconnect;

            cmd.CommandText = $"INSERT INTO user (email_id,password,name,total_earned,total_spent,loan) VALUES('{user_id}','{password}','{name}','{total_earned}','{total_spent}','{loan}');";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return false;
            }

            Console.WriteLine("user table updated");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return true;
        }
        public bool Update_Table_Expences(string user_id, string spent_on, double amount, string date)
        {
            sqlconnect = new MySqlConnection(connection_string);
            sqlconnect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = sqlconnect;

            cmd.CommandText = $"INSERT INTO expences (email_id,spent_on,amount,date) VALUES('{user_id}','{spent_on}','{amount}','{date}');";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return false;
            }

            Console.WriteLine("expences table updated");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return true;
        }
        public bool Update_Table_Loan(string user_id, string loan_request_reason, double amount, string category)
        {
            sqlconnect = new MySqlConnection(connection_string);
            sqlconnect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = sqlconnect;

            cmd.CommandText = $"INSERT INTO loan (email_id,loan_request_reason,amount,category) VALUES('{user_id}','{loan_request_reason}','{amount}','{category}');";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return false;
            }

            Console.WriteLine("loan table updated");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return true;
        }
        public void Read_Table_User()
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = $"SELECT email_id FROM user;";
                SqlReader = cmd.ExecuteReader();
                string user = null;
                while (SqlReader.Read())
                {
                    user = SqlReader.GetString(0);
                    AdminPanel.Instance.userData.Add(new UserData() { Email = user });
                }
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return;
            }

            Console.WriteLine("expences table read");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return;
        }
        public void Read_Table_Expences(string user_id)
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = $"SELECT * FROM expences WHERE email_id= '{user_id}';";
                SqlReader = cmd.ExecuteReader();
                string itemname = null;
                double price = 0.0;
                string date = null;
                while (SqlReader.Read())
                {
                    itemname = SqlReader.GetString(1);
                    price = double.Parse(SqlReader.GetString(2));
                    date = SqlReader.GetString(3);
                    Transaction.Instance.itemData.Add(new ItemData() { ItemName = itemname, Price = price, Date = date.Split(' ')[0] });
                }
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return;
            }

            Console.WriteLine("expences table read");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return;
        }
        public void Read_Table_Loan()
        {
            try
            {
                sqlconnect = new MySqlConnection(connection_string);
                sqlconnect.Open();
                cmd = new MySqlCommand();
                cmd.Connection = sqlconnect;

                cmd.CommandText = $"SELECT * FROM loan WHERE loan_request_reason IS NOT NULL OR loan_request_reason='';";
                SqlReader = cmd.ExecuteReader();
                string user_id = null;
                string loan_request_reason = null;
                double amount = 0.0;
                string category = null;
                while (SqlReader.Read())
                {
                    user_id = SqlReader.GetString(0);
                    loan_request_reason = SqlReader.GetString(1);
                    amount = double.Parse(SqlReader.GetString(2));
                    category = SqlReader.GetString(3);
                    AdminPanel.Instance.userData.Add(new UserData() { Email = user_id, LoanRequestReason = loan_request_reason, LoanAmount = amount, LoanCategory = category });
                }
                SqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlconnect.Close();
                sqlconnect.Dispose();
                cmd.Dispose();
                return;
            }

            Console.WriteLine("loan table read");
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
            return;
        }
        public void GetExpencesByDate(string date)
        {
            sqlconnect = new MySqlConnection(connection_string);
            sqlconnect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = sqlconnect;

            cmd.CommandText = $"SELECT * FROM expences WHERE date= '{date}';";
            try
            {
                SqlReader = cmd.ExecuteReader();
                string itemname = null;
                double price = 0.0;
                string datetemp = null;
                while (SqlReader.Read())
                {
                    itemname = SqlReader.GetString(1);
                    price = double.Parse(SqlReader.GetString(2));
                    datetemp = SqlReader.GetString(3);
                    Transaction.Instance.itemData.Add(new ItemData() { ItemName = itemname, Price = price, Date = datetemp.Split(' ')[0] });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dispose();
                return;
            }

            Console.WriteLine("data found by date");
            Dispose();
            return;
        }
        public bool Validate_User(string id, string password)
        {
            sqlconnect = new MySqlConnection(connection_string);
            sqlconnect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = sqlconnect;

            cmd.CommandText = $"SELECT * FROM user WHERE email_id= '{id}' AND password= '{password}'";
            SqlReader = cmd.ExecuteReader();
            while (SqlReader.Read())
            {
                for (int i = 0; i < SqlReader.FieldCount; i++)
                {
                    if (SqlReader.GetString(i).Contains($"{id}"))
                    {
                        Console.WriteLine("User found.");
                        Dispose();
                        return true;
                    }
                }
            }
            Console.WriteLine("User not found.");
            Dispose();
            return false;
        }

        public void Dispose()
        {
            SqlReader.Close();
            SqlReader.Dispose();
            sqlconnect.Close();
            sqlconnect.Dispose();
            cmd.Dispose();
        }
    }
}
