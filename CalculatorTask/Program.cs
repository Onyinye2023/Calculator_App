using System;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace CalculatorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Your are welcome to CGPA App." +
                "\n 1.To calculate your GPA follow the format" +
                "\n 2.Course code should follow the format as: MTH101, COM104" +
                "\n 3 Course Unit (0-5)" +
                "\n 4.Course Score (0-100)" +
                "\n ";
            string numberOfCourseMSG = $"Enter the number of courses offered";
            string numberOfCourseMSGerrMSG = "Note the following" +
                "\n 1.number of courses must be a number" +
                "\n 2.number of course offered must be between( 1-100). No negative interger" +
                "\n 3.number of courses cannot be empty";
            string courseCodeMSG = "Note the following" +
                "\n 1.course code must follow the format: MTH101, COM201, STA344" +
                "\n 2.Course code must not be more than six characters(3 letters and 3 numbers)" +
                "\n 3.course code cannot be empty" +
                "\n 4.course code must not be entered more than once";
            string courseUniterrMSG = $"invalid input: " +
                "\n please take note" +
                "\n course unit must be betweem the range (0-5)\n ";
            string courseScoreerrMSG = $"invalid score: " +
              "\n please take note" +
              "\n course score must be betweem the range (0-100)\n ";
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine(numberOfCourseMSG);
            string numOfCourses = Console.ReadLine();

            byte length;
            while (!byte.TryParse(numOfCourses, out length) || length < 1 || length > 100)
            {
                Console.WriteLine(numberOfCourseMSGerrMSG);
                numOfCourses = Console.ReadLine();
            }

            Course[] courseArray = new Course[length];

            bool input = true;
            int count = 0;

            while (input)
            {
                for (int i = 0; i < courseArray.Length; i++)
                {
                    Console.WriteLine($"Enter course {i+1} code e.g MTH101, COM201 ");
                    string courseCodeInput = Console.ReadLine();
                    string courseCode;

                    Validator validator = new Validator(courseArray);
                    
                    while (!validator.Match(courseCodeInput) || validator.Exist(courseCodeInput.ToUpper()))
                    {
                        Console.WriteLine(courseCodeMSG + $"\n\n Enter course {i + 1} code");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();

                    Console.WriteLine($"Enter course {i + 1} unit within the range (0-5)");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;

                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 5)
                    {
                        Console.WriteLine(courseUniterrMSG + $"\n\n Enter course {i + 1} unit");
                        courseUnitInput = Console.ReadLine();
                    }


                    Console.WriteLine($"Enter course {i + 1} score within the range (0-100)");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;

                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.WriteLine(courseScoreerrMSG + $"\n\n Enter course {i + 1} score");
                        courseScoreInput = Console.ReadLine();
                    }

                    courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                    count++;
                }

                if(count == length)
                {
                    input = false;
                }
            }

            PrintTable printTable = new PrintTable(courseArray);
            printTable.Table();
            Console.ReadKey();
             
        }
    }
}

        
 