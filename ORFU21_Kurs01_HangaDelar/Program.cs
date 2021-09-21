using System;

namespace ORFU21_Kurs01_HangaDelar
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            int totalLives = 5;
            string[] wordArray = new[] { "t", "e", "s", "t" };
            //int[] livesArray = new int[totalLives];

            while (isRunning == true)
            {
                int[] livesArray = new int[totalLives];

                Console.WriteLine("Total Lives  : " + totalLives);
                Console.WriteLine("Total Letters: " + wordArray.Length);
                Console.WriteLine();

                Console.Write("Lives : ");
                foreach (int totalLivesSym in livesArray)
                {
                    Console.Write(" | ");
                }

                Console.WriteLine();
                Console.Write("Ord   : ");

                foreach (string totalLettersSym in wordArray)
                {
                    Console.Write(" _ ");
                }

                Console.WriteLine();
                string guess = Console.ReadLine();
                //bool isFound;

                for (var i = 0; i < wordArray.Length; i++)
                {
                    if (guess == wordArray[i])
                    {
                        Console.WriteLine("Found! " + i);
                        //isFound = true;

                    }
                    else
                    {
                        Console.WriteLine("Not Found! " + i);
                    }

                    //if (isFound == true)
                    //{

                    //}

                    //}

                }
                Console.ReadLine();
            }
        }
    }
}
