//Author: Michael Markus Wierlemann
//Year: 2021
//Last change: 02/07/2021
using System;

namespace Avg_grade{
    [Serializable]
    public class GradeClass{
        private float _grade;
        public float Grade{
            get{
                return _grade;
            }
            set{
                _grade = value;
            }
        }
        private int _cp;
        public int CP{
            get{
                return _cp;
            }
            set{
                _cp = value;
            }
        }
        private string _module;
        public string Module{
            get{
                return _module;
            }
            set{
                _module = value;
            }
        }
        public GradeClass(float grade, int cp, string module){
            Grade = grade;
            CP = cp;
            Module = module;
        }
    }
}