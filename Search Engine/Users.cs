using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace Search_Engine
{
    [Serializable]
    public class User
    {
        public string Name { set; get; }
        public string Password { set; get; }
        public List<Category> categories { set; get; }
        
        public User()
        {

        }
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
        
        public void setCredentials(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            categories = new List<Category>();
        }
        public string getName()
        {
            return Name;
        }

        public string getPassword()
        {
            return Password;
        }
        public void addCat(string cat)
        {
            categories.Add(new Category(cat));
        }

         
        //public bool sign_up()
        // {
        //     if (!File.Exists("User.xml"))
        //     {
        //         XmlWriter wr = XmlWriter.Create("User.xml");
        //         wr.WriteStartDocument();
        //         wr.WriteStartElement("List");
        //         wr.WriteAttributeString("name", "User");
        //         wr.WriteStartElement("User");
        //         wr.WriteStartElement("Username");
        //         wr.WriteString(Name);
        //         wr.WriteEndElement();
        //         wr.WriteStartElement("Password");
        //         wr.WriteString(Password);

        //         wr.WriteEndElement();
        //         wr.WriteStartElement("Categories");
        //         wr.WriteString("");
        //         wr.WriteEndElement();
        //         wr.WriteEndElement();
        //         wr.WriteEndDocument();
        //         wr.Close();
        //         return true;
        //     }
        //     else
        //     {
        //         XmlDocument doc = new XmlDocument();
        //         doc.Load("User.xml");
        //         XmlNodeList userName = doc.GetElementsByTagName("Username");
        //         for (int i = 0; i < userName.Count; i++)
        //         {
        //             if (userName[i].InnerText == Name)
        //             {
        //                 return false;
        //             }
        //         }
        //         XmlDocument d = new XmlDocument();
        //         XmlElement user = d.CreateElement("User");
        //         XmlElement node = d.CreateElement("Username");
        //         node.InnerText = Name;
        //         user.AppendChild(node);
        //         node = d.CreateElement("Password");
        //         node.InnerText = Password;
        //         user.AppendChild(node);
        //         node = d.CreateElement("Categories");
        //         node.InnerText = "";
        //         user.AppendChild(node);
        //         d.Load("User.xml");
        //         XmlElement root = d.DocumentElement;
        //         root.AppendChild(user);
        //         d.Save("User.xml");
        //         return true;
        //     }
        // }
        // public bool sign_in()
        // {
        //     XmlDocument doc = new XmlDocument();
        //     doc.Load("User.xml");
        //     XmlNodeList users = doc.GetElementsByTagName("User");
        //     for (int i = 0; i < users.Count; i++)
        //     {
        //         XmlNodeList ch = users[i].ChildNodes;
        //         if (ch[0].InnerText == Name && ch[1].InnerText == Password)
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        // public void addCategory(Category category)
        // {
        //     if(!File.Exists(Name+"cat.xml"))
        //     {
        //         XmlWriter wr = XmlWriter.Create(Name+"cat.xml");
        //         wr.WriteStartDocument();
        //         wr.WriteStartElement("List");
        //         wr.WriteAttributeString("name", "Categories");
        //         wr.WriteStartElement("Category");
        //         wr.WriteStartElement("Name");
        //         wr.WriteString(category.getCatName());
        //         wr.WriteEndElement();
                 
        //         for (int i = 0; i < category.getWords().Count;i++ )
        //         {
        //             wr.WriteStartElement("Keyword");
        //             wr.WriteString(category.getWords()[i]);
        //             wr.WriteEndElement();
        //         }
        //         wr.WriteEndElement();
        //         wr.WriteEndDocument();
        //         wr.Close();
        //     }
        //     else
        //     {
        //         XmlDocument d = new XmlDocument();
        //         XmlElement user = d.CreateElement("Category");
        //         XmlElement node = d.CreateElement("Name");
        //         node.InnerText = category.getCatName();
        //         user.AppendChild(node);
        //         for (int i = 0; i < category.getWords().Count;i++ )
        //         {
        //             node = d.CreateElement("Keyword");
        //             node.InnerText = category.getWords()[i];
        //             user.AppendChild(node);
                 
        //         }
        //         d.Load(Name + "cat.xml");
        //         XmlElement root = d.DocumentElement;
        //         root.AppendChild(user);
        //         d.Save(Name + "cat.xml");
                 
        //     }
        // }
        //public void addNewFile(file f)
        // {
        //     if (!File.Exists(Name + "file.xml"))
        //     {
        //         XmlWriter wr = XmlWriter.Create(Name + "file.xml");
        //         wr.WriteStartDocument();
        //         wr.WriteStartElement("List");
        //         wr.WriteAttributeString("name", "Files");
        //         wr.WriteStartElement("File");
        //         wr.WriteStartElement("Name");
        //         wr.WriteString(f.fileName);
        //         wr.WriteEndElement();
        //         wr.WriteStartElement("Path");
        //         wr.WriteString(f.path);
        //         wr.WriteEndElement();
        //         wr.WriteEndElement();
        //         wr.WriteEndDocument();
        //         wr.Close();
        //     }
        //     else
        //     {
        //         XmlDocument d = new XmlDocument();
        //         XmlElement user = d.CreateElement("File");
        //         XmlElement node = d.CreateElement("Name");
        //         node.InnerText = f.fileName;
        //         user.AppendChild(node);
        //         node = d.CreateElement("Path");
        //         node.InnerText = f.path;
        //         user.AppendChild(node);
                 
        //         d.Load(Name + "file.xml");
        //         XmlElement root = d.DocumentElement;
        //         root.AppendChild(user);
        //         d.Save(Name + "file.xml");

        //     }

        // }
    }
}
