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
                 try
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
                 }
                 catch
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     WriteLine(NotValidInput);
                     Console.ResetColor();
                     WriteLine(AnyKey);
                     Console.ReadKey();
                     Console.Clear();
                 }
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
            StringBuilder guessedLetters = new StringBuilder();
            StringBuilder mysteryWord = (HideWord());
            char[] rightGuess = new char[mysteryWord.Length];

            
            char playerGuess;
            for (int i = 9; i > 0; i--)
            {
                
                Console.Clear();
                Console.WriteLine("You have {0} lives left", i + 1);
                Console.WriteLine("Your guesses:" + guessedLetters);
                Console.WriteLine(mysteryWord);
                WriteLine(WhatType);

                string[] wordLength = new string[mysteryWord.Length];
                playerGuess = char.Parse(Console.ReadLine());
                string stringGuess = playerGuess.ToString();
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                
                    if (playerGuess == mysteryWord[j])
                    {
                        wordLength[j] = stringGuess;
                        stringGuess.ToCharArray();

                    }

                }
                guessedLetters.Append(stringGuess);
               
            }
        }

        static StringBuilder HideWord()
        {
            string mysteryWord = (WordGenerator());
            StringBuilder guessedLetter = new StringBuilder();

            for (var i = 0; i <mysteryWord.Length; i++) 
            {
                guessedLetter.Append("_ ");
            }

            return guessedLetter;

        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
