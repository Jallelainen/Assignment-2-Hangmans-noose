using System;
using System.Linq;
using System.Text;

namespace Assignment_2_Hangmans_noose
{
    class Program
    {
        static void Main (string[] args)
        {
             string MenuItems = "-------Hangman-------\nNew Game (1)\nExit(-1)\nYour choice: ";
             string NotValidInput = "That is not a valid input. Please try again.";
             string AnyKey = "Hit any key to continue.";
             bool keepLooping = true;
             while (keepLooping)
             {
                

                     WriteLine(MenuItems);
                     var choice = int.Parse(Console.ReadLine() ?? "");
                     switch (choice)
                     {
                         case 1:
                             StartGame();
                             break;
                         case -1:
                             keepLooping = false;
                             break;
                         default:
                             Console.ForegroundColor = ConsoleColor.Red;
                             WriteLine(NotValidInput);
                             break;
                     }
                     Console.ResetColor();
                     WriteLine(AnyKey);
                     Console.ReadKey();
                     Console.Clear();
                 
                 /*catch
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     WriteLine(NotValidInput);
                     Console.ResetColor();
                     WriteLine(AnyKey);
                     Console.ReadKey();
                     Console.Clear();
                 }*/
             }
         

            
        }
        public static string WordGenerator()
        {
            string[] wordArray = new string[10];
            wordArray[0] = "bark";
            wordArray[1] = "potery";
            wordArray[2] = "cooperation";
            wordArray[3] = "spoil";
            wordArray[4] = "smoke";
            wordArray[5] = "pension";
            wordArray[6] = "favourite";
            wordArray[7] = "revoke";
            wordArray[8] = "intention";
            wordArray[9] = "patient";
            
            Random random = new Random();
            var randomNumber = random.Next(0, 9);
            string mysteryWord = wordArray[randomNumber];

            return mysteryWord;

        }
        static void StartGame()
        {
            string WhatType = "\nWhat would you like to guess? ";
            string NotValidInput = "That is not a valid input. Please try again.";
            StringBuilder wrongLetters = new StringBuilder();
            string theWord = WordGenerator();
            StringBuilder mysteryWord = (HideWord(theWord));
            char[] rightGuess = new char[theWord.Length];

            
            char playerGuess;
            for (int i = 9; i > 0; i--)//Lives loop
            {
                
               // Console.Clear();
                Console.WriteLine("You have {0} lives left", i + 1);
                Console.WriteLine("Your guesses:" + wrongLetters);
                Console.WriteLine(mysteryWord);
                WriteLine(WhatType);

                string[] wordLength = new string[mysteryWord.Length];

                string playerGuess1 = Console.ReadLine();
                Console.WriteLine("sdfdsfdsdfdsf" + playerGuess1.Length);
                if(playerGuess1.Length == 1)
                {
                playerGuess = char.Parse(playerGuess1);
                // playerGuess = char.Parse(Console.ReadLine());
                
                string stringPlayerGuess = playerGuess.ToString();
                for (int j = 0; j < theWord.Length; j++)
                {
                
                    if (playerGuess == theWord[j])
                    {
                        wordLength[j] = stringPlayerGuess;
                        rightGuess[j] = playerGuess;
                    }
                    else if (playerGuess.ToString() == theWord)
                    {
                        Console.WriteLine("you won biatch");
                    }

                }
                wrongLetters.Append(stringPlayerGuess);
               

                }
                else if (playerGuess1.Length > 1)
                {
                    Console.WriteLine("whaaat");
                }
            }
            Console.WriteLine("you lost suckah");
        }

        static StringBuilder HideWord(string mysteryWord)
        {
            
            StringBuilder hiddenWord = new StringBuilder();

            for (var i = 0; i <mysteryWord.Length; i++) 
            {
                hiddenWord.Append("_ ");
            }

            return hiddenWord;
      

        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
