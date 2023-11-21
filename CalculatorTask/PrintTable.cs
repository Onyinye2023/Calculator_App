using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTask
{
    public class PrintTable
    {
        public Course[] convertedGrades { get; set; }
        public double tcuRegistered, tcuPassed, twPoint, gpa;

        public PrintTable(Course[] convertedGrades)
        {
            this.convertedGrades = convertedGrades;
        }
         public double TCURegistered()
        {
            tcuRegistered = 0;
            for (int i = 0;  i < convertedGrades.Length; i++)
            {
                tcuRegistered += convertedGrades[i].courseUnit;
            }
            return tcuRegistered;
         }

        public double TCUPassed()
        {
            tcuPassed = 0;
            for (int i = 0; i < convertedGrades.Length;i++)
            {
                if (convertedGrades[i].gradeUnit != 0)
                {
                    tcuPassed += convertedGrades[i].courseUnit;
                }
            }
            return tcuPassed;
        }

        public double TWPoint()
        {
            twPoint = 0;
            for (int i = 0; i < convertedGrades.Length; i++)
            {
                twPoint += convertedGrades[i].weightPoint;
            }
            return twPoint;
        }

        public double GPA() => Math.Round(TWPoint() / TCURegistered(), 2);

        public void Table()
        {
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");
            Console.WriteLine("| COURSE & CODE | COURSE UNIT | GRADE | GRADE UNIT | WEIGHT Pt. |  REMARK   |");
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");

            foreach (var course in convertedGrades)
            {
                Console.WriteLine("|    " + course.courseCode + "     |      " + course.courseUnit + "      |   " + course.grade + "   |       " + course.gradeUnit + "    |" + course.weightPoint.ToString().PadLeft(11, ' ') + " | " + course.remarks.PadLeft(10, ' ') + "|");
            }
                Console.WriteLine("|---------------------------------------------------------------------------|");

            Console.WriteLine();
            Console.WriteLine("Total Course unit Registered is " + TCURegistered());
            Console.WriteLine();
            Console.WriteLine("Total Course unit Passed is " + TCUPassed());
            Console.WriteLine();
            Console.WriteLine("Total Weight Point is " + TWPoint());
            Console.WriteLine();
            Console.WriteLine($"Your GPA is {GPA():F2} to 2 decimal places");
        }
    }
}
