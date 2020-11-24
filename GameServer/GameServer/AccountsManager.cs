using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class AccountsManager
    {
        //public static List<string> Usernames = new List<string>();
        //public static List<string> Passwords = new List<string>();
        public static string[] Usernames = new string[0];
        public static string[] Passwords = new string[0];
        public static int AccountsAmount/* = Usernames.Count*/;

        public static void CheckCorrectLogin(string username, string password, int fromClient)
        {
            //Console.WriteLine("Login " + username + " " + password);
            //AccountsAmount = Usernames.Count;
            //Console.WriteLine(Usernames.Length);
            for (int i = 0; i < Usernames.Length/*Count*/; i++)
            {
                //Console.WriteLine(Usernames[i]);
                if (username == Usernames[i])
                {
                    if (password == Passwords[i])
                    {
                        //Logged :)
                        ServerSend.LoginResult(fromClient, true, "Logged");
                    }
                    else
                    {
                        //Wrong password :(
                        ServerSend.LoginResult(fromClient, false, "Wrong password");
                    }
                    return;
                }
            }
            ServerSend.LoginResult(fromClient, false, "Wrong username or account not exist");
        }

        public static void Register(string username, string password, int fromClient)
        {
            //Console.WriteLine("Register " + username + " " + password);
            //AccountsAmount = Usernames.Count;
            for (int i = 0; i < Usernames.Length; i++)
            {
                if (username == Usernames[i])
                {
                    //Unfortunetly username exist :(
                    ServerSend.RegisterResult(fromClient, false, "Given username exist");
                    return;
                }
            }
            //Registered :)
            //Console.WriteLine("Accounts amount: " + AccountsAmount);
            //Usernames.Add(username);
            //Passwords.Add(password);
            string[] a = Usernames;
            Usernames = new string[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                Usernames[i] = a[i];
            }
            Usernames[Usernames.Length - 1] = username;

            string[] b = Passwords;
            Passwords = new string[a.Length + 1];
            for (int i = 0; i < b.Length; i++)
            {
                Passwords[i] = b[i];
            }
            Passwords[Passwords.Length - 1] = password;

            AccountsAmount++;
            //Console.WriteLine("Jeden " + Usernames[0] + " " + Passwords[0] + " " + username + " " + password);
            ServerSend.RegisterResult(fromClient, true, "Registration was successful");
        }
    }
}
