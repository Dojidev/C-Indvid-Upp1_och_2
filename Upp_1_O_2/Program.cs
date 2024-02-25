using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;




namespace Upp_1_O_2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            WriteLine("Enter the alphabet you want to filter words with: ");

            char chosenAlphabet = Char.ToLower(ReadKey().KeyChar);
            WriteLine();
            WriteLine();

            string fileName = "wordBank.txt";
            string[] words = Methods.ReadFileFromSameDirectory(fileName);

            //Filter the words based on the chosen alphabet
            string[] filteredWords = Methods.FilterWordsStartingWithAlphabet(words, chosenAlphabet); //runs the method retuns the filterwrds as string arry.

            if (filteredWords.Length > 0)
            {
                //Display the filtered words
                Methods.DisplayFilteredWords(filteredWords, chosenAlphabet);

                //Option to save filterd word
                WriteLine("Do you want to save filter words? (yes/no)");
                string input = ReadLine().ToLower();
                if (input == "yes")
                {
                    Methods.SaveFilteredWordsToFile(filteredWords, chosenAlphabet);
                }
                else
                {
                    WriteLine("Filtered words were not saved.");
                }
            }
            else
            {
                WriteLine("No words found starting with the chosen alphabet.");
            }
        }
    }
}
