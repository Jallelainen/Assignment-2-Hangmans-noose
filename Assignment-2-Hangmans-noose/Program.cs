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
            string[] wordArray = new string[10]; //declares new array
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

            Random random = new Random(); //declares random variable
            var randomNumber = random.Next(0, 9); // assigns an int number from array to a variable
            string mysteryWord = wordArray[randomNumber]; // creates variable with string assigned from array via the random int number

            return mysteryWord;

        }
        static void StartGame()
        {
            string WhatType = "\nWhat would you like to guess? ";
            StringBuilder wrongLetters = new StringBuilder(" "); //creates a stringbuilder intended for wrong letter guesses.
            string theWord = WordGenerator(); //assigns the word by calling WordGenerator method.
            char[] rightGuess = new char[theWord.Length]; //creates new array for the right guesses. Makes it as long as the word.
            InitUnderscore(rightGuess); // takes the array above and calls method that returns the word but in underscores.
            char playerGuess;


            for (int i = 10; i >= 0; i--)//Lives loop. Will loop 10 times
            {

                Console.Clear();
                Console.WriteLine("You have {0} lives left", i); //string message that calls{0} which iteration the for-loop is in.
                Console.WriteLine("Your guesses: " + wrongLetters); //displays previous wrong guesses.
                PrintRightGuesses(rightGuess); // calls method to display the hidden word. Will insert right guesses in right place.
                WriteLine(WhatType);

                if (i > 0) // if index is bigger than 0, keeps looping
                {

                    string playerGuess1 = Console.ReadLine(); // user inputs guess, gets assigned to variable.

                    if (playerGuess1.Length == 1) //if the user guess amount of letters equals 1.
                    {
                        if (wrongLetters.ToString().Contains(playerGuess1) || Array.IndexOf(rightGuess, playerGuess1) >= 0) //if user guess already exists in the wrong or right guesses.(compares to stringbuilder and array)
                        {
                            i++; // adds a iteration (life) to the for-loop.
                            Console.WriteLine("you already guessed that");
                        }
                        else if (theWord.Contains(playerGuess1)) //if the word contains the users guess.
                        {
                            playerGuess = char.Parse(playerGuess1); //turns user guess from string to char.
                            for (int j = 0; j < theWord.Length; j++) // goes through as many iterations as the word is long.
                            {

                                if (playerGuess == theWord[j]) // if user guess matches with position in the word[j].
                                {
                                    rightGuess[j] = playerGuess; // inserts user guess in rightWord array in correct position.
                                }


                            }

                        }
                        else
                        {
                            wrongLetters.Append(playerGuess1);// wrong guess gets put in stringbuilder.

                        }



                    }
                    else if (playerGuess1.Length > 1) // if user guess is bigger than 1 letter.
                    {
                        if (playerGuess1 == theWord) // if user guess equals to the word
                        {
                            Console.Clear();
                            Console.WriteLine("-------| | CONGRATULATIONS! | |------- \nWell done, you've won!!! ");
                            Console.WriteLine("You had {0} lives left", i); //{0} calls iteration from loop
                            Console.WriteLine("You guessed: " + wrongLetters);
                            Console.WriteLine("The right word was " + theWord);
                            break;

                        }
                    }

                }
                else if (i == 0) // if index equal to 0 = losing condition.
                {
                    Console.Clear();
                    Console.WriteLine("|-|-|THE GAME|-|-|\nYou just lost it...");
                    break;
                }
                Console.WriteLine("Hit any key to continue"); //pauses progress to prevent clear console to wipe out info.
                Console.ReadKey(true);
            }



        }

        static void InitUnderscore(char[] hiddenWord) // transforms the word to underscores
        {
            for (int i = 0; i < hiddenWord.Length; i++) // loops as long as the word
            {
                hiddenWord[i] = '_'; // replaces the letter in specific iteration with underscore
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


        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
