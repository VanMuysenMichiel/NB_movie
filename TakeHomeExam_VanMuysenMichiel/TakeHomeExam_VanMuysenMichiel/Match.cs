using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TakeHomeExam_VanMuysenMichiel
{
    class Match
    {
        public string BestMatch(string input)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            input = rgx.Replace(input, "");
            string[] allInput = input.Split(" ");
            allInput = allInput.Skip(1).ToArray();
            allInput = allInput.Skip(1).ToArray();

            List<string> okayArray = new List<string>();

            foreach (var item in allInput)
            {

                if (item.Length > 3)
                {
                    okayArray.Add(item);
                }
            }



            string output = " ";
            string watch = "";
            int count = 0;

            foreach (var item in File.ReadAllLines("movie.txt"))
            {
                string[] tekstWatch = item.Split("split2");
                string[] words = tekstWatch[0].Split(" ");
                int maxCount = 0;

                foreach (var wordInput in okayArray)
                {
                    foreach (var wordData in words)
                    {
                        if (wordInput == wordData)
                        {
                            maxCount++;

                            if (maxCount > count)
                            {
                                output = tekstWatch[0];
                                watch = tekstWatch[1];
                                count = maxCount;
                                maxCount = 0;
                            }

                        }
                    }
                }
            }
            string[] title = output.Split("split1");
            Console.WriteLine(title[0]);
            string result = watch.Remove(0, 1);
            Console.WriteLine(result);
            return (title[0] + "\r" + watch);
        }

        public string WorstMatch(string input)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            input = rgx.Replace(input, "");
            string[] allInput = input.Split(" ");
            allInput = allInput.Skip(1).ToArray();
            allInput = allInput.Skip(1).ToArray();

            List<string> okayArray = new List<string>();

            foreach (var item in allInput)
            {

                if (item.Length > 3)
                {
                    okayArray.Add(item);
                }
            }

            List<string> titleArray = new List<string>();
            List<string> watchArray = new List<string>();

            foreach (var item in File.ReadAllLines("movie.txt"))
            {
                string[] tekstWatch = item.Split("split2");
                string[] words = tekstWatch[0].Split(" ");
                int maxCount = 0;

                foreach (var wordInput in okayArray)
                {
                    foreach (var wordData in words)
                    {
                        if (wordInput == wordData)
                        {
                            maxCount++;
                        }

                    }
                    if (maxCount == 0)
                    {
                        titleArray.Add(tekstWatch[0]);
                        watchArray.Add(tekstWatch[1]);
                        maxCount = 0;
                    }
                }
            }

            Random random = new Random();
            int num = random.Next(0, watchArray.Count);
            string[] final = titleArray[num].Split("split1");

            Console.WriteLine(final[0]);
            string result = watchArray[num].Remove(0, 1);
            Console.WriteLine(result);
            return titleArray[num] + "\r" + watchArray[num];

        }

    }
}

