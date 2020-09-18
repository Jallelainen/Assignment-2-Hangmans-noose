using System;
using System.Linq;
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
            // StringBuilder mysteryWord = (HideWord(theWord));
            char[] rightGuess = new char[theWord.Length];
            InitUnderscore(rightGuess);


            char playerGuess;


            for (int i = 10; i > 0; i--)//Lives loop
            {

                Console.Clear();
                Console.WriteLine("You have {0} lives left", i);
                Console.WriteLine("Your guesses:" + wrongLetters);
                PrintRightGuesses(rightGuess);
                WriteLine(WhatType);

                string[] wordLength = new string[theWord.Length];

                string playerGuess1 = Console.ReadLine();
                if (playerGuess1.Length == 1)
                {
                    if (wrongLetters.ToString().Contains(playerGuess1) || rightGuess.ToString().Contains(playerGuess1))
                    {
                        i++;
                        Console.WriteLine("you already guessed that");
                    }
                    else if (theWord.Contains(playerGuess1))
                    {
                        playerGuess = char.Parse(playerGuess1);
                        for (int j = 0; j < theWord.Length; j++)
                        {

                            if (playerGuess == theWord[j])
                            {
                                rightGuess[j] = playerGuess;
                            }


                        }

                    }
                    else
                    {
                        wrongLetters.Append(playerGuess1);

                    }



                }
                else if (playerGuess1.Length > 1)
                {
                    if (playerGuess1 == theWord)
                    {
                        Console.WriteLine("you won\nHit any key: ");
                        break;

                    }
                }
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey(true);
            }
            Console.WriteLine("you lost");



        }

        static void InitUnderscore(char[] hiddenWord)
        {
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = '_';
            }
        }

        static void PrintRightGuesses(char[] rightGuess)
        {
            for (int i = 0; i < rightGuess.Length; i++)
            {
                Console.Write(rightGuess[i] + " ");
            }
            Console.WriteLine();
        }


       /* static StringBuilder HideWord(string mysteryWord)
        {

            StringBuilder hiddenWord = new StringBuilder();

            for (var i = 0; i < mysteryWord.Length; i++)
            {
                hiddenWord.Append("_ ");
            }

            return hiddenWord;


        }*/

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
