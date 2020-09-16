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

        static void StartGame()
        {
            string WhatType = "What kind of guess would you like to make?";
            string GuessType = "A letter (1)\nA word (2)";
            string NotValidInput = "That is not a valid input. Please try again.";
            //string mysteryword = WordGenerator();
            double userInput;

            //Console.WriteLine(mysteryword);
            WriteLine(WhatType);
            WriteLine(GuessType);
            userInput = Console.ReadLine();

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
            }
        }

        static string AskForWord()
        {
            string guessString = Console.ReadLine();

            return guessString;
        }

        static void AskForLetter()
        {
            string EnterGuess = "Please enter which letter you would like to guess: ";


            WriteLine(EnterGuess);
            char userInput = Console.ReadKey().KeyChar;
            StringBuilder guessChar = new StringBuilder();

            guessChar.ToString().Contains(userInput);


            //return guessChar;
        }

        static string WordGenerator()
        {
            Random random = new Random();
            string[] wordArray = new string[10];
            string mysteryWord = random.Next().ToString();

            wordArray[1] = "potery";
            wordArray[2] = "cooperation";
            wordArray[3] = "spoil";
            wordArray[4] = "smoke";
            wordArray[5] = "pension";
            wordArray[6] = "favourite";
            wordArray[7] = "revoke";
            wordArray[8] = "intention";
            wordArray[9] = "patient";
            wordArray[10] = "bark";

           


            /* wordArray[2, 1] = "belly";
             wordArray[2, 2] = "laboratory";
             wordArray[2, 3] = "recover";
             wordArray[2, 4] = "civilian";
             wordArray[2, 5] = "origin";
             wordArray[2, 6] = "bottle";
             wordArray[2, 7] = "cake";
             wordArray[2, 8] = "powder";
             wordArray[2, 9] = "cinema";
             wordArray[2, 10] = "magnetic";*/

            return mysteryWord;
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
