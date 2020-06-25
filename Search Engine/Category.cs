using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine
{
    public class Category
    {
        private string Name;
        //private List<file> files;
        public List<string> keyWords { set; get; }
        public Category()
        {
            keyWords = new List<string>();
        }

        public Category(string name)
        {
            Name = name;
            //files = new List<file>();
            keyWords = new List<string>();
        }
        public string getCatName()
        {
            return Name;
        }
        //public void addFile(file newFile)
        //{
        //    files.Add(newFile);
        //}

        public void addWord(string newWord)
        {
            keyWords.Add(newWord);
        }   

        //public List<file> getFiles()
        //{
        //    return files;
        //}

        public List<string> getWords()
        {
            return keyWords;
        }

        
    }
}
