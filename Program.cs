//Author: Michael Markus Wierlemann
//Year: 2021
//Last change: 07/07/2021
using System;
using System.Collections.Generic;
using System.IO;

namespace Avg_grade
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                string workingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Avg_grade";
                Console.WriteLine("Select: \n");
                Console.WriteLine("1: Add grade");
                Console.WriteLine("2: Remove grade");
                Console.WriteLine("3: Calculate average grade");
                Console.WriteLine("4: Show all grades");
                Console.WriteLine("5: Exit program\n");
                string input = Console.ReadLine();
                Console.WriteLine("");
                if(Int32.TryParse(input, out int result) == true){
                    string dataTxt = workingDirectory + @"\grades.txt";
                    AverageGradeClass avgGrade;
                    bool fileExists = false;
                    if(result == 1){
                        if(File.Exists(dataTxt) == true){
                            fileExists = true;
                            avgGrade = AverageGradeClass.Create(dataTxt);
                        }
                        else{
                            fileExists = false;
                            Directory.CreateDirectory(workingDirectory);
                            FileStream filestream = File.Create(dataTxt);
                            filestream.Close();
                            avgGrade = new AverageGradeClass();                      
                        }
                        Console.Write("Module name: ");
                        string modName = Console.ReadLine();
                        Console.Write("Grade value: ");
                        string gradeString = Console.ReadLine();
                        Console.Write("Credit points awarded: ");
                        string cpString = Console.ReadLine();
                        Console.WriteLine("");
                        if(float.TryParse(gradeString, out float grade) && Int32.TryParse(cpString, out int cp) == true){
                            if(fileExists == false){
                                avgGrade.GradeList = new List<GradeClass>();
                            }
                            avgGrade.GradeList.Add(new GradeClass(grade, cp, modName));
                            avgGrade.Save(dataTxt);
                            Console.WriteLine("Grade data was saved.\n");
                        }
                        else{
                            Console.WriteLine("Invalid input.\n");
                        }
                    }
                    else if(result == 2){
                        if(File.Exists(dataTxt) == true){
                            fileExists = true;
                            avgGrade = AverageGradeClass.Create(dataTxt);
                            int counter = 1;
                            if(avgGrade.GradeList.Count > 0 == true){
                                Console.WriteLine("Grade to delete:\n");
                                foreach (GradeClass grade in avgGrade.GradeList)
                                {
                                    Console.WriteLine(counter.ToString() + ": " + grade.Module);
                                    counter++;
                                }
                                Console.WriteLine("");
                                string toDeleteString = Console.ReadLine();
                                Console.WriteLine("");
                                if(Int32.TryParse(toDeleteString, out int toDelete) && toDelete >= 1 && toDelete <= avgGrade.GradeList.Count){
                                    for(int i = 0; i <= avgGrade.GradeList.Count; i++){
                                        if(toDelete == i + 1){
                                            avgGrade.GradeList.Remove(avgGrade.GradeList[i]);
                                            break;
                                        }
                                    }
                                    avgGrade.Save(dataTxt);
                                    Console.WriteLine("Grade deleted.\n");
                                }
                                else{
                                    Console.WriteLine("Invalid input.\n");
                                }
                            }
                            else{
                                Console.WriteLine("No grade entries exist.\n");
                            }
                        }
                        else{
                            Console.WriteLine("No grade entries exist.\n");
                        }
                    }
                    else if(result == 3){
                        if(File.Exists(dataTxt) == true){
                            fileExists = true;
                            avgGrade = AverageGradeClass.Create(dataTxt);
                            if(avgGrade.GradeList.Count > 0 == true){
                                float avgGradeCalc = avgGrade.CalculateAverageGrade(avgGrade.GradeList);
                                Console.WriteLine("AVERAGE GRADE: " + avgGradeCalc.ToString() + "\n");
                            }
                            else{
                                Console.WriteLine("No grade entries exist.\n");
                            }
                        }
                        else{
                            Console.WriteLine("No grade entries exist.\n");
                        }
                    }
                    else if(result == 4){
                        if(File.Exists(dataTxt) == true){
                            fileExists = true;
                            avgGrade = AverageGradeClass.Create(dataTxt);
                            if(avgGrade.GradeList.Count > 0 == true){
                                int counter = 1;
                                foreach (GradeClass grade in avgGrade.GradeList)
                                {
                                    Console.WriteLine("Module " + counter.ToString() + ": " + grade.Module + ", " + grade.Grade.ToString() + ", " + grade.CP.ToString() + "CP");
                                    counter++;
                                }
                                Console.WriteLine("");
                            }
                            else{
                                Console.WriteLine("No grade entries exist.\n");
                            }
                        }
                        else{
                            Console.WriteLine("No grade entries exist.\n");
                        }                                             
                    }
                    else if(result == 5){
                        Environment.Exit(0);
                    }
                    else{
                        Console.WriteLine("Invalid input.\n");
                    }
                }
            }
        }
    }
}
