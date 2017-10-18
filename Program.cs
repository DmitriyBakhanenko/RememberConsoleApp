using System;
using System.Timers;
using System.Linq;
using System.Collections.Generic;

namespace TESTING_CONSOLE_APP
{
    public class MainClass
    {
        internal static List<string> listOfWords;
        internal static WordList fullWordList = new WordList();

        static int TimerCount { get; set; } = 10;
        static int NumOfWords { get; set; } = 0;
        static int RightAnswers { get; set; } = 0;
        static string AnswersFromInput { get; set; }


        public static void Main(string[] args)
        {
            int i = 1;

            fullWordList.Operations(); // set up a list of words for the game in WordList class

            switch (i)
            {
                case 1:
                   
                    NumOfWords = ChooseNumberOfWords4TheGame();
                    goto case 2;

                case 2:

                    listOfWords = new List<string>();
                    var randomWordsFromCompleteList = new RandomWords(NumOfWords); // get a specific amount of random words from a complete list

                    StartTheMemorieseEvent();

                    Console.WriteLine($"Write the next {NumOfWords} words that you have seen befor separating with spacebar");
                    AnswersFromInput = Console.ReadLine();

                    CheckTheRightAnswer();

                    Console.WriteLine($"\nYou have entered {RightAnswers} from {NumOfWords} correctly");
                    goto case 3;

                case 3:

                    Console.WriteLine("\nDo you want to play again\n");
                    Console.WriteLine("1 - YES");
                    Console.WriteLine("2 - NO\n");

                    int num = AnswerFromUser();

                    if (num == 1)
                    {
                        Console.Clear();
                        ResetResults();
                        goto case 1;
                    }
                    if (num == 2)
                        break;
                    
                        Console.WriteLine("Wrong number!");
                        goto case 3;
            }


        }

        static int ChooseNumberOfWords4TheGame()
        {
            int num = 0;
            while (true)
            {
                Console.WriteLine("Please write number of words you can memoriese for 10 sec");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException) { }

                if ((num > 0) && (num <= 30))
                    break;
            }
            return num;
        }

        static void StartTheMemorieseEvent()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += TheMemorieseEvent;
            timer.Start();
            Console.Read();
            Console.Clear();
            timer.Close();
            timer.Dispose();
            GC.Collect();
        }

        private static void TheMemorieseEvent (object sender, ElapsedEventArgs e)
        {
            TimerCount--;

            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("                  Memoriese this words:\n");
            foreach (string word in listOfWords)
            Console.WriteLine($"                  {word}                ");
            Console.WriteLine("");
            Console.WriteLine("                 Time remaining:  " + TimerCount.ToString());
            Console.WriteLine("=================================================");

            if (TimerCount == 0)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("                   Times up!");
                Console.WriteLine("");
                Console.WriteLine("          Get ready to write your words");
                Console.WriteLine("");
                Console.WriteLine("           Press any key to continue");
                Console.WriteLine("==============================================");
            }
        }

        static void CheckTheRightAnswer()
        {
            string[] wordsArr = AnswersFromInput.Split(' ');
            foreach (string word in wordsArr)
                if (listOfWords.Contains(word))
                    RightAnswers++;

        }

        static int AnswerFromUser()
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException) { }
            return num;
        }
   
        static void ResetResults()
        {
            TimerCount = 10;
            NumOfWords = 0;
            RightAnswers = 0;
            AnswersFromInput = "";
        }
    }
}