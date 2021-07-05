//Author: Michael Markus Wierlemann
//Year: 2021
//Last change: 03/07/2021
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Avg_grade{
    [Serializable]
    public class AverageGradeClass{
        private List<GradeClass> _gradeList;
        public List<GradeClass> GradeList{
            get{
                return _gradeList;
            }
            set{
                _gradeList = value;
            }
        }
        public float CalculateAverageGrade(List<GradeClass> gradeList){
            float gradeSum = 0;
            int gradeWeight = 0;
            foreach (GradeClass grade in gradeList){
                gradeSum += grade.Grade * grade.CP;
                gradeWeight += grade.CP;
            }
            return gradeSum / gradeWeight;
        }
        public void Save(string path){
            BinaryFormatter writer = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Create);
            writer.Serialize(fileStream, this);
            fileStream.Flush();
            fileStream.Close();
        }
        public static AverageGradeClass Create(string path){
            BinaryFormatter reader = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            AverageGradeClass averageGrade = (AverageGradeClass)reader.Deserialize(fileStream);
            fileStream.Close();
            return averageGrade;
        }
    }
}