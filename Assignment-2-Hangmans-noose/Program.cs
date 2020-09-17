using System;
using System.Text;

namespace Assignment_2_Hangmans_noose
{
    class Program
    {
        static void Main(string[] args)
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
            string WhatType = "What would you like to guess? ";
            string NotValidInput = "That is not a valid input. Please try again.";
            StringBuilder guessedLetters = new StringBuilder();
            StringBuilder mysteryWord = (HideWord());

            Console.Clear();
            Console.WriteLine(mysteryWord);
            WriteLine(WhatType);
            char playerGuess = char.Parse(Console.ReadLine());
        
            string[] wordLength = new string[mysteryWord.Length];
            string stringGuess = playerGuess.ToString();
            for (int j = 0; j < mysteryWord.Length; j++)
            {
                if (playerGuess == mysteryWord[j])
                {
                        wordLength[j] = stringGuess;

                    Console.Write(wordLength[j] + " ");

                }

                    else if (playerGuess != mysteryWord[j])
                    {
                        guessedLetters.Append(playerGuess);
                        Console.WriteLine(guessedLetters);
                    }

            }
                
            


        }

        static StringBuilder HideWord()
        {
            string mysteryWord = (WordGenerator());
            StringBuilder guessLetter = new StringBuilder();

            for (var i = 0; i <mysteryWord.Length; i++) 
            {
                guessLetter.Append("_ ");
            }

            return guessLetter;

        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
