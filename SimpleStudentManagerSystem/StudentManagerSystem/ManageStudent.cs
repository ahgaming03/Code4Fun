
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudentManagementProgram
{
    internal class ManageStudent
    {
        private List<StudentInfo> StudentList = null;


        public ManageStudent()
        {
            StudentList = new List<StudentInfo>();
        }

        /*
         * Generate ID for each student
         */
        private int GenerateID()
        {
            int max = 1;
            if (StudentList != null && StudentList.Count > 0)
            {
                max = StudentList[0].ID;
                foreach (StudentInfo studID in StudentList)
                {
                    if (max < studID.ID)
                    {
                        max = studID.ID;
                    }
                }
                max++;
            }
            return max;
        }

        /*
         * Return current number of student
         */
        public int NumbersOfStudent()
        {
            int Count = 0;
            if (StudentList != null)
            {
                Count = StudentList.Count;
            }
            return Count;
        }

        /*
         * Input student information
         */
        public void inputStudentInfo()
        {
            // Create a new student
            StudentInfo inputInfo = new StudentInfo();

            inputInfo.ID = GenerateID();
            Console.Write("Name: ");
            inputInfo.Name = Console.ReadLine();

            Console.Write("Gender (M/F): ");
            inputInfo.Gender = CheckGender();

            Console.Write("Age: ");
            inputInfo.Age = CheckAge();

            Console.WriteLine("\nGrade each subjects:");

            Console.Write("Math: ");
            inputInfo.Mathh = CheckMark();

            Console.Write("Physical: ");
            inputInfo.Physical = CheckMark();

            Console.Write("Chemical: ");
            inputInfo.Chemical = CheckMark();

            CalculateGPA(inputInfo);

            StudentList.Add(inputInfo);
        }

        /*
         * Check mark
         */
        public double CheckMark()
        {
            double mark = double.Parse(Console.ReadLine());
            while (mark < 0 || mark > 10)
            {
                Console.Write("Invalid!!!\nPlease enter again: ");
                mark = double.Parse(Console.ReadLine());
            }
            return mark;
        }

        /*
         * Check age
         */
        public int CheckAge()
        {
            int age = int.Parse(Console.ReadLine());
            while (age < 1 || age > 120)
            {
                Console.Write("Invalid!!!\nPlease enter again: ");
                age = int.Parse(Console.ReadLine());
            }
            return age;
        }

        /*
         * Check gender
         */
        public string CheckGender()
        {
            string gender = "";
            do
            {
                char G = char.Parse(Console.ReadLine());
                switch (G)
                {
                    case 'F':
                        {
                            gender = "Female";
                            break;
                        }
                    case 'M':
                        {
                            gender = "Male";
                            break;
                        }
                    default:
                        {
                            Console.Write("Invalid!!!\nPlease enter again: ");

                            break;
                        }
                }
            } while (gender == "");
            return gender;
        }

        /*
         * Calculate GPA
         */
        private void CalculateGPA(StudentInfo stud)
        {
            double GPA = (stud.Mathh + stud.Physical + stud.Chemical) / 3;
            stud.GPA = Math.Round(GPA, 2, MidpointRounding.AwayFromZero);
        }

        /*
         * Sort a student list according to the GPA
         */
        public void SortByGPA()
        {
            StudentList.Sort(delegate (StudentInfo stud1, StudentInfo stud2)
            {
                return stud1.GPA.CompareTo(stud2.GPA);
            });
        }

        /*
         * Show student list
         */
        public void DisplayStudentList(List<StudentInfo> studentList)
        {
            // Display column title
            Console.WriteLine(" |{0, -5} | {1, -30} | {2, -7} | {3, 5} | {4, 6} | {5, 9} | {6, 9} | {7, 10} |",
                              "ID", "Name", "Gender", "Age", "Math", "Physical", "Chemical", "GPA");
            // Display student in list
            if (studentList != null && studentList.Count > 0)
            {
                foreach (StudentInfo stud in studentList)
                {
                    Console.WriteLine(" |{0, -5} | {1, -30} | {2, -7} | {3, 5} | {4, 6} | {5, 9} | {6, 9} | {7, 10} |",
                                      stud.ID, stud.Name, stud.Gender, stud.Age, stud.Mathh, stud.Physical, stud.Chemical, stud.GPA);
                }
            }
            Console.WriteLine();
        }

        /*
         * Return the current list of students
         */
        public List<StudentInfo> getStudentList()
        {
            return StudentList;
        }
    }

}

