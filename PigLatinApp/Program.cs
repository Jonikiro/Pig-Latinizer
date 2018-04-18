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
            while(true)
            {
                // Set up vowel array to check words against.
                char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u'};
                string normalString;

                // Requests user input for letter-only strings. Normalizes input.
                do
                {
                    Console.Clear();
                    Console.WriteLine("Play the Pig Latin Game! " +
                        "\nEnter a sentence without special characters or numbers." +
                        "\nLetters only, please: \n");
                    normalString = Console.ReadLine();
                    normalString = Regex.Replace(normalString, @"\s+", " ");
                    Console.WriteLine();
                } while (!normalString.Any(ch => Char.IsLetter(ch)));

                // Splits strings into individual words.
                string[] words = normalString.Split(' ');

                // Runs a character-by-character breakdown on each word
                foreach (string s in words)
                {
                    List<char> breakWord = s.ToList();

                    // If not a vowel, takes first letter of word and appends it to the end.
                    // Also accounts for words that end in 'y'.
                    while (!vowels.Contains(breakWord[0]))
                    {
                        breakWord.Add(breakWord[0]);
                        breakWord.RemoveAt(0);
                        if (breakWord[0] == 'y')
                            break;
                    }

                    // Prints pig-latinized version of word.
                    Console.Write(string.Join("", breakWord) + "ay ");
                }

                // Sets exit condition. Normalizes user input.
                Console.Write("\n\nWould you like to try again? Type Y or N: ");
                string choice = Console.ReadLine().ToLower();
                choice = Regex.Replace(choice, @"\s+", " ");
                if (choice == "n")
                    break;
            }

        }
    }
}
