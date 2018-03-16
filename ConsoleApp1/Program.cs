using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateNewJudgeScoreFile();
        }

        public static void CreateNewJudgeScoreFile()
        {
            string[] readFile = File.ReadAllText(@"C:\Users\Dianna\Developer\figure-skating-scores\data\tidy\judge-scores.csv").Split('\n');
            using (StreamWriter writeFile = new StreamWriter(@"C:\Users\Dianna\Developer\figure-skating-scores\data\tidy\custom-scores.csv"))
            {
                writeFile.WriteLine("aspect_id, J1, J2, J3, J4, J5, J6, J7, J8, J9");

                int j = 0;

                for (int i = 1; i < readFile.Length - 9; i += j)
                {
                    j = 0;
                    string id = readFile[i].Split(',')[0];
                    string toAppend = id;

                    while (readFile[i + j].Split(',')[0] == id)
                    {
                        toAppend += "," + readFile[i + j].Split(',')[2].Trim();
                        j++;

                        if (i + j > readFile.Length)
                            break;
                    }

                    writeFile.WriteLine(toAppend);
                }
            }
        }

        public static void GetPerformanceInformation()
        {
            List<string> readFile = File.ReadAllText(@"C:\Users\Dianna\Developer\figure-skating-scores\data\tidy\judged-aspects.csv").Split('\n').ToList();
            using (StreamWriter writeFile = new StreamWriter(@"C:\Users\Dianna\Developer\figure-skating-scores\data\tidy\performance-custom.csv"))
            {
                writeFile.WriteLine("aspect_id, J1, J2, J3, J4, J5, J6, J7, J8, J9");

                int j = 0;

                for (int i = 1; i < readFile.Length - 9; i += j)
                {
                    j = 0;
                    string id = readFile[i].Split(',')[0];
                    string toAppend = id;

                    while (readFile[i + j].Split(',')[0] == id)
                    {
                        toAppend += "," + readFile[i + j].Split(',')[2].Trim();
                        j++;

                        if (i + j > readFile.Length)
                            break;
                    }

                    writeFile.WriteLine(toAppend);
                }
            }
        }
    }
}
