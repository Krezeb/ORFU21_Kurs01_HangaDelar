using System;

namespace ORFU21_Kurs01_HangaDelar
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Random rndNum = new Random();//Skapar en "random" variabel som kan användas senare
            int totalLives = rndNum.Next(2, 5); //Random siffra mellan 2 och 5.
            int goodAttempts = 0;

            ConsoleKeyInfo guessInput;
            string guess = null;
            string guessMid;

            //Det här fick jag googla fram
            string[] randomWord = { "HUND", "JORDEN", "SOFFA", "BORD", "BIL" };
            Random rndWordChoice = new Random();
            int wordArrayPre = rndWordChoice.Next(randomWord.Length); //Samma som ovan, fast med ord istället för siffror
            string rndWordString = randomWord[wordArrayPre]; //Sparar en random ord som en string
            Console.WriteLine(rndWordString);
            string[] wordArray = new string[rndWordString.Length]; //Skapar en Array med index = random ordets längd
            for (int i = 0; i < rndWordString.Length; i++) //For-Loop för random ordets längd
            {
                wordArray[i] = rndWordString[i].ToString(); //lägger varje bokstav i sin egen index i array:en wordArray.
            }

            while (isRunning == true)
            {
                string[] attArray = new string[1] { null };
                string[] obfArray = new string[wordArray.Length]; //Creating a obfuscation array to be filled with "_". Same length as the wordArray
                for (int i = 0; i < obfArray.Length; i++) //Filling obfArray with "_" depending on how many letters are stored in the array "obfArray"
                {
                    obfArray[i] = "_";
                }

                bool gameStart = true;

                while (gameStart)
                {

                    int[] livesArray = new int[totalLives];

                    Console.Clear();
                    Console.Write("Antal Försök kvar: "); //Visar antal lives (enligt totalLives)
                    foreach (int totalLivesSym in livesArray)
                    {
                        Console.Write(" | ");
                    }
                    Console.WriteLine("\n\n");

                    for (int i = 0; i < obfArray.Length; i++)
                    {
                        Console.Write($" {obfArray[i]} "); //Shows obfArray on a single line
                    }
                    Console.WriteLine("\n\n");

                    Console.Write("Tidigare försök: ");
                    for (int i = 0; i < attArray.Length; i++)
                    {
                        Console.Write($" {attArray[i]} "); //tidigare försök
                    }

                    Console.Write("\n\nAnge en bokstav för att göra en gissning: ");

                    guessInput = Console.ReadKey(true);
                    guessMid = guessInput.KeyChar.ToString();
                    guess = guessMid.ToUpper();

                    bool lifeLoop = true;
                    bool isPassed = false;
                    while (lifeLoop)
                    {
                        for (var i = 0; i < wordArray.Length; i++)
                        {
                            if (guess == wordArray[i])
                            {
                                obfArray[i] = guess;
                                isPassed = true; //Om "guess" hittas i array
                                goodAttempts++;
                            }

                        }

                        if (isPassed == false)
                        {
                            totalLives = totalLives - 1;

                            string[] tempAttArray = new string[attArray.Length + 1];
                            for (int j = 0; j < attArray.Length; j++)
                            {
                                tempAttArray[j] = attArray[j];
                            }
                            tempAttArray[^1] = guess;
                            attArray = tempAttArray;

                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (totalLives == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Inga gissningar kvar. Du har förlorat denna omgång");
                        Console.WriteLine("Tryck på valfri knapp för att avsluta...");
                        Console.ReadKey(true);
                        gameStart = false;
                        isRunning = false;
                        //Environment.Exit(0); //snabb sätt att avsluta hela programmet
                    }

                    if (goodAttempts == wordArray.Length)
                    {
                        Console.Clear();
                        Console.WriteLine("Grattis! Du har vunnit!");
                        Console.WriteLine("Tryck på valfri knapp för att avsluta...");
                        Console.ReadKey(true);
                        gameStart = false;
                        isRunning = false;
                    }
                }
            }
        }
    }
}
