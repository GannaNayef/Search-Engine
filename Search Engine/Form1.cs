using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Search_Engine
{
    [Serializable, XmlRoot("Users")]
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        XmlSerializer xs;
        int index = 0;
        public Form1()
        {
            InitializeComponent();
            if(File.Exists("Users.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("UsersList"));
                FileStream fs = new FileStream("Users.xml", FileMode.Open);
                //XmlRootAttribute xroot = new XmlRootAttribute();
                //xroot.ElementName = "List Of users";
                //xroot.IsNullable = true;
                
                users = (List<User>)xs.Deserialize(fs);
                fs.Close();
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Users.xml", FileMode.Open);
            xs = new XmlSerializer(typeof(User));
            List<User> temp = (List<User>)xs.Deserialize(fs);
            fs.Close();
            bool valid=false;
            User u=new User(textBox1.Text, textBox2.Text);
            foreach(User t in temp)
            {
                if(t.getName()==textBox1.Text&&t.getPassword()==textBox2.Text)
                {
                    index = temp.IndexOf(t);
                    valid =true;
                    break;
                }
            }
            if(valid)
            {
                tabControl1.SelectedTab = tabPage3;
               //// Dictionary<string, Category> cat = u.getCategories();
               // for (int i = 0; i < cat.Count; i++)
               // {
               //     comboBox1.Items.Add(cat.ElementAt(i).Value.getCatName());
               // }
                    
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            if(!File.Exists("User.xml"))
            {
                FileStream wr = new FileStream("User.xml", FileMode.Append);
                //users.Add(new User(textBox3.Text, textBox4.Text));
                User tempUser = new User();
                tempUser.setCredentials(textBox3.Text, textBox4.Text);
                users.Add(tempUser);
                index = users.IndexOf(tempUser);
                xs = new XmlSerializer(users.GetType());
                xs.Serialize(wr, users);
                wr.Close();
                tabControl1.SelectedTab = tabPage4;
            }
            else
            {
                
                FileStream fs = new FileStream("User.xml", FileMode.Open);
                xs = new XmlSerializer(users.GetType());
                List<User> temp = (List<User>)xs.Deserialize(fs);
                fs.Close();
                bool exist = false;
                foreach(User t in temp)
                {
                    if(t.getName()==textBox3.Text)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    MessageBox.Show("Username already exist!" + "/n" + "Try again !");
                }
                else
                {
                    User tempUser = new User();
                    tempUser.setCredentials(textBox3.Text, textBox4.Text);
                    users.Add(tempUser);
                    index = users.IndexOf(tempUser);
                    FileStream wr = new FileStream("User.xml", FileMode.Append);
                    xs.Serialize(wr, users);
                    wr.Close();
                    tabControl1.SelectedTab = tabPage4;
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("User.xml", FileMode.Append);
            XmlSerializer xs = new XmlSerializer(users.GetType());
            xs.Serialize(fs, xs);
            tabControl1.SelectedTab = tabPage3;
            comboBox1.Items.Add(textBox6.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool exist = false;
            int i=0;
            foreach(Category c in users[index].categories)
            {
                if(c.getCatName()==textBox6.Text)
                {
                    i = users[index].categories.IndexOf(c);
                    exist = true;
                    break;
                }
            }
            if(exist)
            {
                users[index].categories[i].addWord(textBox7.Text);
            }
            else
            {
                users[index].addCat(textBox6.Text);
                users[index].categories[users[index].categories.Count - 1].addWord(textBox7.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //file f = new file(textBox8.Text, textBox9.Text);
            //users[textBox1.Text].getCategory(textBox6.Text).addFile(f);
        }

        
    }
}
