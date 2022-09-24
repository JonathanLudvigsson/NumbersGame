//Jonathan Ludvigsson SUT22
using System;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till NumbersGame! Jag tänker på ett nummer. Kan du gissa vilket? Men först, välj svårighetsgrad!");
            while (true) //Main loop
            {
                DifficultySelect(out int lives, out int maxNum); //Gives out different amount of lives and the max number we can randomize to depending on what difficulty the user chose
                Console.WriteLine($"Du har {lives} liv och ska gissa på ett slumpmässigt heltal från 1 till {maxNum}");
                NumbersGame(lives, maxNum); //Runs the NumbersGame using lives and maxNum which we got from the DifficultySelect method as arguments

                Console.WriteLine("Vill du spela igen? Svara ja om du vill det!");
                string playAgain = Console.ReadLine().ToUpper(); //Asks user if they want to play again
                if (playAgain != "JA") //If they did not answer "ja" it breaks loop and exit program
                {
                    Console.WriteLine("Vad tråkigt! Hej då!");
                    break;
                }
            }
        }

        public static void DifficultySelect(out int lives, out int maxNum) //Method that lets the user select a difficulty
        {
            lives = 6; //How many lives the user has, default is set at easiest difficulty
            maxNum = 10; //The number we can randomize up to, default is set at easiset difficulty
            Console.WriteLine("Välj en svårighetsgrad från 1 till 3");
            int difficulty = Int32.Parse(Console.ReadLine()); //User selects a difficulty, 1 2 or 3

            switch (difficulty)
            {
                case 1: break; //If 1, break as we already have the default values set at easiest difficulty
                case 2: //If 2, set values to medium difficulty
                    lives = 5;
                    maxNum = 25;
                    break;
                case 3: //If 3, set values to hard difficulty
                    lives = 3;
                    maxNum = 50;
                    break;
                default: //If user did not select 1 2 or 3 we use the default values
                    Console.WriteLine("Det där är inte ett tal mellan 1 och 3 så du får den lättaste svårighetsgraden!");
                    break;
            }
            Console.WriteLine(); //Prints new line in the console so the program looks better
        }

        public static void NumbersGame(int lives, int maxNum) //Method of the NumbersGame itself
        {
            Random random = new Random(); //Lets us use random
            int number = random.Next(1, maxNum + 1); //Creates a random number from 1 to maxNum +1, +1 because random.Next only uses less than for the max value
            int guesses = 0; //How many guesses the user has made, is used to check if the user has run out of lives or not

            Console.WriteLine("Gissa på ett nummer!");
            while (true) //Loop that runs until the user runs out of lives or guesses the correct number
            {
                int guess = Int32.Parse(Console.ReadLine()); //Lets the user guess a number
                if (guess < number) //If they guessed too low, tell the user it's too low and then do guesses++ which essentially gives them one less life
                {
                    Console.WriteLine("Tyvärr du gissade för lågt!");
                    guesses++;
                }
                else if (guess > number) //Same as above except runs if they guessed too high
                {
                    Console.WriteLine("Tyvärr du gissade för högt!");
                    guesses++;
                }
                else //If the guess is not too high or too low then the uses guessed the correct number and they win the game
                {
                    Console.WriteLine("Wohoo! Du gjorde det!");
                    break;
                }
                if (guesses == lives) //If the user runs out of lives by guessing as many times as the amount of lives they have the user loses the game
                {
                    Console.WriteLine($"Tyvärr! Du lyckades inte gissa talet på {lives} försök.");
                    break;
                }
            }

        }
    }
}
