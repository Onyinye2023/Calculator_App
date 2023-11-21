using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTask
{
    public class Course
    {
        public string courseCode, grade, remarks;
        public double courseUnit, gradeUnit, weightPoint, courseScore;
        
        public Course(string courseCode, double courseUnit,double courseScore)
        {
            this.courseCode = courseCode;
            this.courseUnit = courseUnit;
            this.courseScore = courseScore;

            //setting grade unit using course score
            this.gradeUnit = courseScore >= 0 && courseScore < 40 ? 0 : 
                courseScore >= 40 && courseScore < 45 ? 1 :
                courseScore >= 45 && courseScore < 50 ? 2 :
                courseScore >= 50 && courseScore < 60 ? 3 :
                courseScore >= 60 && courseScore < 70 ? 4 :
                courseScore >= 70 && courseScore <= 100 ? 5 : 6;

            //setting grade using grade unit
            this.grade = gradeUnit == 5 ? "A" : 
                gradeUnit == 4 ? "B" :
                gradeUnit == 3 ? "C" :
                gradeUnit == 2 ? "D" : 
                gradeUnit == 1 ? "E" :
                gradeUnit == 0 ? "F" : "NO GRADE";

            //calculate weight point
            this.weightPoint = courseUnit * gradeUnit;

            //setting remarks using grade unit
            this.remarks = gradeUnit == 5 ? "Excellent" :
                gradeUnit == 4 ? "very good" :
                gradeUnit == 3 ? "Good" :
                gradeUnit == 2 ? "Fair" :
                gradeUnit == 1 ? "Pass" :
                gradeUnit == 0 ? "Fail" : "No Remark";
        }

    }
}
