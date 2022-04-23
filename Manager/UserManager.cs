using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WPFTestingSystem.Model;

namespace WPFTestingSystem.Manager
{
    class UserManager
    {
        public string GetPass(string login)
        {
            string pass = null;
            if (File.Exists("Users.xml"))
            {
                XDocument document = XDocument.Load("Users.xml");
                XElement root = document.Element("Users");
                pass = (from i in root.Elements("User")
                        where i.Element("Login").Value == login
                        select i.Element("Password").Value).First();
            }
            return pass;
        }
        public bool Register(string log, string pass, string _name)
        {
            if (File.Exists("Users.xml"))
            {
                XDocument document = XDocument.Load("Users.xml");
                XElement root = document.Element("Users");
                XElement user = new XElement("User");
                XElement name = new XElement("Name", _name);
                XElement login = new XElement("Login", log);
                XElement password = new XElement("Password", pass);
                root.Add(user);
                user.Add(login);
                user.Add(name);
                user.Add(password);
                document.Save("Users.xml");
            }
            return true;
        }
        public User Auth(string log, string pass)
        {
            User u = null;
            XDocument document = XDocument.Load("Users.xml");
            XElement root = document.Element("Users");
            var user = from us in root.Elements("User")
                       where us.Element("Login").Value == log && us.Element("Password").Value == pass
                       select us;
            //Check for registration 1 user
            if (user != null)
            {

                try
                {
                    u = new User() { Login = user.ToList()[0].Element("Login").Value, Name = user.ToList()[0].Element("Name").Value };
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Incorrect login or password");
                }
            }
            return u;
        }
    }
}
