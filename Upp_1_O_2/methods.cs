using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using static System.Console;
using Upp_1_O_2;

namespace Upp_1_O_2
{
    public class Methods
    {
        //-------------------Method for reading file------------------------//                
        /// <summary>
        /// this method take bellow param read file name wordBank.txt from the same file directory. if it exist it reads all the line
        /// if not it throws an exception error.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string[] ReadFileFromSameDirectory(string fileName)
        {
            string currentDirectory = Environment.CurrentDirectory;
            string filePath = Path.Combine(currentDirectory,fileName); // file directory and file name in 'wordbank' in filepath.
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllLines(filePath); // 
                }
                else
                {
                    throw new FileNotFoundException($"The file {fileName} does not exist in the directory.");
                }
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred while reading the file: {ex.Message}");
                return new string[0]; // Return an empty array if there's an error
            }
        }

        //-------------------Method for filtering word----------------------//
        /// <summary>
        /// filters word from text file splits each line of arry by comma ',' to seprate idividual words 
        /// then it filters words based on chosen alphabet
        /// 
        /// </summary>
        /// <param name="inputArr"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>

        public static string[] FilterWordsStartingWithAlphabet(string[] inputArr, char alphabet)
        {
            try
            {
                // Filter the words that start with the chosen alphabet
                var filteredWords = inputArr
                    .SelectMany(line => line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)) // Split each word by ',' into  individual words in new line
                    .Where(word => word.StartsWith(alphabet.ToString(), StringComparison.OrdinalIgnoreCase)) // Filter words that start with the chosen alphabet
                    .ToArray();

                return filteredWords;
            }
            catch (Exception ex)
            {
                WriteLine($"Error occurred while filtering words: {ex.Message}");
                return new string[0]; // Return an empty array if there's an error
            }
        }


        //-------------------method for displaying filter word--------------//
        /// <summary>
        /// This method takes two param mentioned below shows the words based on chosehn alphabet.
        ///  
        /// </summary>
        /// <param name="filteredWords"></param>
        /// <param name="chosenAlphabet"></param>


        public static void DisplayFilteredWords(string[] filteredWords, char chosenAlphabet)
        {
            WriteLine($"Filtered words starting with '{chosenAlphabet}':"); //Shows chosen alphabet first 

            //this loop is shows all word that is seperated from txt file.
            for (int i = 0; i < filteredWords.Length; i++)
            {
                string index = (i + 1).ToString().PadLeft(2, '0'); // Add leading zero in front of number till 9
                WriteLine($"{index}. {filteredWords[i].ToUpper()}"); // writes in the console filterdword and makes it to upper class
            }
            WriteLine();
        }


        //---------------------method for saving filter words-----------------------//
        /// <summary>
        /// the method takes memtion bellow param and create a new folder with name 'WordsStartingWith' ex 'a'
        /// saves the the filterwords as .txt file with name WordStartingWith ex'A' and change it to string and uppercase.
        /// </summary>
        /// <param name="filteredWords"></param>
        /// <param name="chosenAlphabet"></param>


        public static void SaveFilteredWordsToFile(string[] filteredWords, char chosenAlphabet)
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, $"WordsStartingWith{chosenAlphabet.ToString().ToUpper()}");
            Directory.CreateDirectory(directoryPath); // creates new directory with chosen alphabet

            string filePath = Path.Combine(directoryPath, $"WordsStartingWith{chosenAlphabet.ToString().ToUpper()}.txt");
            File.WriteAllLines(filePath, filteredWords); // creates .txt file inside newly created directory 

            WriteLine($"Filtered words starting with '{chosenAlphabet}' saved to {filePath}");
        }
    }
}