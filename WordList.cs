using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace TESTING_CONSOLE_APP
{
    public class WordList
    {
        public List<string> completeList = new List<string>();

        public void Operations()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] filenames = assembly.GetManifestResourceNames();
            string content = File.ReadAllText("WordList1.txt");


            string[] text = content.Split(new[] { " ", ",", ".", "-", "\"", ";", 
                ":", "?", "!","'","\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = text.ToList();
            list.Remove("don't");

            foreach (string word in list)
            {
                if (word.Length >= 4)
                {
                    completeList.Add(word);
                }
            }
        }
    
        public void ShowList()
        {
            foreach (string word in completeList)
            {
                Console.Write(word + " ");
            }
        }
    }
}
