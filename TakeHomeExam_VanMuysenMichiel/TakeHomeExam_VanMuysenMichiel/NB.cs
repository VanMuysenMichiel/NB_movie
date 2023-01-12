using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TakeHomeExam_VanMuysenMichiel
{
    class NB
    {
        Dictionary<string, Dictionary<string, int>> dict;

        int goodCount;
        int badCount;

        public NB()
        {
            dict = new Dictionary<string, Dictionary<string, int>>();
            dict["Good"] = new Dictionary<string, int>();
            dict["Bad"] = new Dictionary<string, int>();

        }
        public void useTrainData(string file)
        {
            foreach (var item in File.ReadAllLines(file))
            {
                var newItem = item.Replace(".", " ");
                string[] words = newItem.Split(" ");

                string key = "";
                if (item.Contains("Good, "))
                {
                    key = "Good";
                    goodCount++;
                }
                else
                {
                    key = "Bad";
                    badCount++;
                }

                foreach (var word in words)
                {
                    if (dict[key].ContainsKey(word))
                    {
                        dict[key][word]++;
                    }
                    else
                    {
                        dict[key][word] = 1;
                    }
                }
            }
        }

        public string PositiveOrNegative(string text)
        {
            string[] words = text.Split(" ");

            double neg = 1;
            double pos = 1;

            foreach (var item in words)
            {
                if (dict["Bad"].ContainsKey(item))
                {
                    neg += (double)dict["Bad"][item] / badCount;
                }
                if (dict["Good"].ContainsKey(item))
                {
                    pos += (double)dict["Good"][item] / goodCount;
                }
            }

            if (neg > pos)
            {
                return "Negative";
            }
            else
            {
                return "Positive";
            }
        }
    }
}
