using System;
using System.IO;

namespace textToBinaryByLineLength
{
    class Program
    {
        /// <summary>
        /// This tool takes a file compare every line in the file with the value that is given
        /// if the line lenght is bigger then the value it puts 1 else 0 untill there is a binary given
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int middleValue = 10;
            string textFileFullPath;
            string binaryString = "";
            bool isMidValueNumber = true;
            string toolHeader = "textToBinaryByLineLength v1.00 - Cyber toolbox\nCopyright (C) 2019 Nati Berkovich\n";

            if (args.Length > 0)
            {
                Console.WriteLine(toolHeader);
                if (args.Length > 1)
                {
                    isMidValueNumber = int.TryParse(args[0], out middleValue);
                    textFileFullPath = args[1];
                }
                else
                {
                    textFileFullPath = args[0];
                }
                if (isMidValueNumber)
                {
                    if (File.Exists(textFileFullPath))
                    {
                        System.IO.StreamReader textFileStreamReader = new System.IO.StreamReader(textFileFullPath);
                        string Line;
                        while ((Line = textFileStreamReader.ReadLine()) != null)
                        {
                            if (Line.Length > middleValue)
                            {
                                binaryString += 1;
                            }
                            else
                            {
                                binaryString += 0;
                            }
                        }
                        Console.WriteLine("Binary:");
                        Console.WriteLine(binaryString);
                    }
                    else
                    {
                        Console.WriteLine("No matching files were found.");
                    }
                }
                else
                {
                    Console.WriteLine("Middle value is not a valid number.");
                }
            }
            else
            {
                Console.WriteLine(toolHeader +
                    "\nThis tool takes a file compare every line in the file with the middle value that is given\n" +
                    "if the line lenght is bigger then the value it puts one else zero, and build a binary string.\n\n" +
                    "usage: textToBinaryByLineLength [-m] <file full path>\n\n" +
                    "Options:\n" +
                    "     -m   Sets the middle value for checking the line length from      # Default is 10");
            }

        }
    }
}
