using System;
using System.Linq;

namespace TESTING_CONSOLE_APP
{
    public class RandomWords : MainClass
    {
        public RandomWords(int i)
        {
            var random = new Random();
            for (int num = 0; num < i; num++)
            {
                int tempIndexOfWord = random.Next(0, fullWordList.completeList.Count);
                listOfWords.Add(fullWordList.completeList.ElementAt(tempIndexOfWord).ToLower());

            }
        }
    }
}
