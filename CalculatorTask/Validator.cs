using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorTask
{
    public class Validator
    {
        Course[] _course { get; set; }

        public Validator(Course[] course) 
        {
            this._course = course;
        }

        public bool Exist(string courseCode)
        {
            bool exist = false;
            foreach (Course course in this._course)
            {
               if (course != null && course.courseCode == courseCode)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }
        public bool Match(string courseCode)
        {
            Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
            if (!coursePattern.IsMatch(courseCode))
            {
                return false;
            }
            return true;
        }

        public bool Length(string courseCode)
        {
            if (courseCode.Length != 0) 
            { 
                return false;
            }
            return true;
        }

        public bool IsLength(string number)
        {
            long length;
            if (!long.TryParse(number, out length) || length < 0 || length < 5)
            {
                return false;
            }
            return true;
        }
    }
}
