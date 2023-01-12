using System;

namespace TakeHomeExam_VanMuysenMichiel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your simple sentence here, start with a subject and then verb followed by nouns");
                string input = Console.ReadLine();
                Console.WriteLine("\r");

                NB nb = new NB();
                Check check = new Check();
                Match match = new Match();

                // With Naive Bayes --> I will check if my sentece is positive or negative
                nb.useTrainData("data.txt");

                if (check.CheckSentence(input) == false)
                {
                    Console.WriteLine("Possible fouls:");
                    Console.WriteLine("         - Your sentence contained wrong symbols");
                    Console.WriteLine("         - Your sentence was to short --> I need a subject/verb and noun(s)");
                    Console.WriteLine("I expect something likes this --> I like wars and fights");
                    Console.WriteLine("Please try again!");
                }
                else
                {
                    if (nb.PositiveOrNegative(input.ToLower()) == "Positive")
                    {
                        if (input.Contains("no"))
                        {
                            string[] inputNO = input.Split("no");
                            //Console.WriteLine("Positive");
                            match.BestMatch(inputNO[0]);
                        }
                        else
                        {
                            //Console.WriteLine("Positive");
                            match.BestMatch(input);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Negative");
                        match.WorstMatch(input);
                    }
                }
            }
            catch 
            {
                Console.WriteLine("We couldn't find a matching movie to your sentence");
                Console.WriteLine("Please try again, but use more and simple words");
            }
        }
    }
}
