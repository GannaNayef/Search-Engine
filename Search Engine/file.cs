using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Search_Engine
{
    static class global
    {
        public static Dictionary<string, int> global_dictionary = new Dictionary<string, int>();
    }
 public   class file
    {
        public string fileName;
        public Dictionary<string, int> keyWord_freq = new Dictionary<string, int>();
        public string path;

        public file(string fileName, string path)
        {
            this.fileName = fileName;
            this.path = path;
        }
        public file(string fileName, string path, string text)
        {
            this.fileName = fileName;
            this.path = path;
            FileStream writer = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(writer);
            sw.Write(text);
            writer.Close();
            sw.Close();
        }
        public string showFile()
        {
            string myText = "";
            FileStream reader = new FileStream(path, FileMode.Open);
            StreamReader fileReader = new StreamReader(reader);
            while (fileReader.Peek() != -1)
            {
                myText = myText + fileReader.ReadLine();
            }
            reader.Close();
            fileReader.Close();
            return myText;
        }
        public void coutFreq()
        {
            FileStream reader = new FileStream(path, FileMode.Open);
            StreamReader fileReader = new StreamReader(reader);
            while (fileReader.Peek() != -1)
            {
                string word = fileReader.ReadLine(), temp = "";
                for (int i = 0; i <= word.Length; i++)
                {
                    if (i == word.Length || word[i] == ' ')
                    {
                        if (global.global_dictionary.ContainsKey(temp))
                        {
                            if (keyWord_freq.ContainsKey(temp))
                                keyWord_freq[temp]++;
                            else keyWord_freq[temp] = 1;
                        }
                        temp = "";
                    }
                    else temp += word[i];
                }
            }
            reader.Close();
            fileReader.Close();
        }
       


    }
}
