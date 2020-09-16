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

            for(var i = 0; i <mysteryWord.Length; i++) 
            {
                Console.Write("_ ");
            }
            return mysteryWord;

        }
        static void StartGame()
        {
            string WhatType = "What kind of guess would you like to make?";
            string GuessType = "A letter (1)\nA word (2)";
            string NotValidInput = "That is not a valid input. Please try again.";
            string mysteryWord = (WordGenerator());
            double userInput;
            string[] wordLength = new string[mysteryWord.Length];
            
            /*WriteLine(WhatType);
            WriteLine(GuessType);
            userInput = Int32.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    AskForLetter();
                    break;
                case 2:
                    AskForWord();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine(NotValidInput);
                    break;
            }*/
            // Here starts the loop
            for (int p = 0; p < mysteryWord.Length; p++)
            {
                wordLength[p] = "_ ";
            }

            while (true)
            {
                StringBuilder guessedLetters = new StringBuilder();
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                    {
                        wordLength[j] = playerGuess;

                    Console.Write(wordLength[j] + " ");

                    }

                    else
                    {
                        guessedLetters.ToString().Contains(playerGuess);
                        Console.WriteLine(guessedLetters);
                    }

                }
                
            }


        }

        static string AskForWord()
        {
            string guessString = Console.ReadLine();

            return guessString;
        }

        static void AskForLetter()
        {
            StringBuilder guessLetter = new StringBuilder();

            string EnterGuess = "Please enter which letter you would like to guess: ";

            


            WriteLine(EnterGuess);
            char userInput = Console.ReadKey().KeyChar;

            guessLetter.ToString().Contains(userInput);


            //return guessChar;
        }

        

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
