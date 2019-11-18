using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace Boyer_moore_horspool_Algorithm
{
    class Program
    {
        static Dictionary<char, int> BadMatchTable = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            Console.WriteLine("type string to search");
            string input = Console.ReadLine();
            Console.WriteLine("type pattern to search");
            string pattern = Console.ReadLine();
            CreateBadMatchTable(pattern);
            Search(input, pattern);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="pattern"></param>
        static void Search(string Input, string pattern)
        {
            int i = 0;
            while (i <= Input.Length - pattern.Length)
            {
                int j = pattern.Length - 1;
                while (j >= 0)
                {

                    if (Input[i + j] == pattern[j])
                    {
                        if (j == 0)
                        {
                            Console.WriteLine($"Pattern match found at Index {i}");
                            i += pattern.Length;
                            break;
                        }
                        --j;
                    }
                    else
                    {
                        if (BadMatchTable.ContainsKey(Input[i + j]))
                        {
                            i += BadMatchTable[Input[i+j]];
                            j = 0;
                        }
                        else
                        {
                            i += BadMatchTable[' '];
                        }
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// CreateBadMatchTable
        /// </summary>
        /// <param name="pattern"></param>
        static void CreateBadMatchTable(string pattern)
        {
            BadMatchTable.Add(' ', pattern.Length);
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                int distance = pattern.Length - i - 1;
                BadMatchTable.TryAdd(pattern[i], distance);
            }
        }
    }
}
