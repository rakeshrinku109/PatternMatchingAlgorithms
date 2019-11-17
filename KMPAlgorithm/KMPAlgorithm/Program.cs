using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    class Program
    {
        static int[] lps = null;
        static void Main(string[] args)
        {
            Console.Write("Enter a string");
            string LongString = Console.ReadLine();
            Console.Write("Enter a patten to search the string");
            string Pattern = Console.ReadLine();
            CreateLps(Pattern);
            SearchIndex(Pattern,LongString);

            Console.ReadKey();
        }

        /// <summary>
        /// Time complexity O(M+N)
        /// </summary>
        /// <param name="pattern"></param>
        private static void SearchIndex(string pattern,string Input)
        {
            int len2 = pattern.Length;
            int len1 = Input.Length;

            int i = 0, j = 0;
            while (i < len1)
            {
                if (Input[i] == pattern[j])
                {

                    if (j == len2 - 1)
                    {
                        Console.WriteLine($"Match found at {i - j}");
                        j = -1;
                    }
                    ++i; ++j;
                  

                }
                else
                {
                    if (j==0)
                    {
                        ++i;
                    }
                    else
                    {
                        j = lps[j - 1];
                    }
                }
            }
        }

        /// <summary>
        /// Create the prefix table formt the given pattern. 
        /// Where we check for a given suffix if there exists a prefix. 
        /// </summary>
        /// <param name="pattern"></param>
        public static void CreateLps(string pattern)
        {
            char[] patternArray = pattern.ToCharArray();
            lps = new int[pattern.Length];
            lps[0] = 0;
            int j = 0;
            int i = 1;
            while (i < pattern.Length)
            {
                if (patternArray[i] == patternArray[j])
                {
                    lps[i] = ++j;
                    ++i;
                }
                else
                {
                    if (j!=0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        ++i;
                    }

                }
            }
        }
    }
}
