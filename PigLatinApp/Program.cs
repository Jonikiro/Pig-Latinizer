using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PigLatinApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets up variables and vowel array to check words against.
            char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            string normalString;
            string[] words;
            List<char> breakWord;
            int count, i;

            // Main loop
            while (true)
            {
                // Requests user input for letter-only strings. Normalizes input.
                do
                {
                    Console.Clear();
                    Console.WriteLine("Play the Pig Latin Game! " +
                        "\nEnter a sentence WITHOUT special characters or numbers: ");
                    normalString = Regex.Replace(Console.ReadLine().ToLower(), @"\s+", " ");
                    Console.WriteLine();
                    words = normalString.Split(' ');
                } while (!words.All(ch => Regex.IsMatch(ch, @"^[a-zA-Z]+$")));

                // Runs a character-by-character breakdown on each word
                foreach (string s in words)
                {
                    breakWord = s.ToList();
                    count = s.Length;
                    i = 0;
                    // If not a vowel, takes first letter of word and appends it to the end.
                    // Also accounts for words that end in 'y'.
                    while (!vowels.Contains(breakWord[0]) && i < count)
                    {
                        breakWord.Add(breakWord[0]);
                        breakWord.RemoveAt(0);
                        if (breakWord[0] == 'y')
                            break;
                        i++;
                    }

                    // Prints pig-latinized version of word.
                    Console.Write(string.Join("", breakWord) + "ay ");
                }

                // Sets exit condition. Normalizes user input.
                Console.Write("\n\nWould you like to try again? Type Y or N: ");
                if (Regex.Replace(Console.ReadLine().ToLower(), @"\s+", " ") == "n")
                    break;
            }

        }
    }
}
