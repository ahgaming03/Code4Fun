using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementProgram
{
    internal class Manage
    {
        private List<StudentInfo> StudentList = null;


        public Manage()
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

        public int NumbersOfStudent()
        {
            int Count = 0;
            if (StudentList != null)
            {
                Count = StudentList.Count;
            }
            return Count;
        }

        public void inputStudentInfo()
        {
            // Create a new student
            StudentInfo inputInfo = new StudentInfo();
            inputInfo.ID = GenerateID();
            Console.Write("Name: ");
            inputInfo.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Gender: ");
            inputInfo.Gender = Convert.ToString(Console.ReadLine());

            Console.Write("Age: ");
            inputInfo.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Grade each subjects:");

            Console.Write("Math: ");
            inputInfo.Mathh = Convert.ToDouble(Console.ReadLine());

            Console.Write("Physical: ");
            inputInfo.Physical = Convert.ToDouble(Console.ReadLine());

            Console.Write("Chemical: ");
            inputInfo.Chemical = Convert.ToDouble(Console.ReadLine());

            CalculateGPA(inputInfo);
            Ranked(inputInfo);

            StudentList.Add(inputInfo);
        }

        /*Update student information by ID
         */
        public void UpdateStudentInformation(int ID)
        {
            // Find student in student list
            StudentInfo stud = FindByID(ID);
            // If students exist, update student information
            if (stud != null)
            {
                Console.WriteLine("Update this student information");
                Console.WriteLine("(If you do not enter anything, do not update this function)");
                Console.Write("Name: ");
                string name = Convert.ToString(Console.ReadLine());
                // If you do not enter anything, do not update name
                if (name != null && name.Length > 0)
                {
                    stud.Name = name;
                }

                Console.Write("Gender: ");
                // If you do not enter anything, do not update gender
                string gender = Convert.ToString(Console.ReadLine());
                if (gender != null && gender.Length > 0)
                {
                    stud.Gender = gender;
                }

                Console.Write("Age: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // If you do not enter anything, do not update age
                if (ageStr != null && ageStr.Length > 0)
                {
                    stud.Age = Convert.ToInt32(ageStr);
                }

                Console.WriteLine("Grade each subjects:");

                Console.Write("Math: ");
                string mathStr = Convert.ToString(Console.ReadLine());
                // If you do not enter anything, do not update math scores
                if (mathStr != null && mathStr.Length > 0)
                {
                    stud.Mathh = Convert.ToDouble(mathStr);
                }

                Console.Write("Physical: ");
                string physicalStr = Convert.ToString(Console.ReadLine());
                // If you do not enter anything, do not update physical scores
                if (physicalStr != null && physicalStr.Length > 0)
                {
                    stud.Physical = Convert.ToDouble(physicalStr);
                }

                Console.Write("Chemical: ");
                string chemicalStr = Convert.ToString(Console.ReadLine());
                // If you do not enter anything, do not update chemical scores
                if (chemicalStr != null && chemicalStr.Length > 0)
                {
                    stud.Chemical = Convert.ToDouble(chemicalStr);
                }

                CalculateGPA(stud);
                Ranked(stud);
            }
            else
            {
                Console.WriteLine("Student have ID = {0} does not exist.", ID);
            }
        }


        /*
         * Sort a student list according to the ID
         */
        public void SortByID()
        {
            StudentList.Sort(delegate (StudentInfo sv1, StudentInfo sv2)
            {
                return sv1.ID.CompareTo(sv2.ID);
            });
        }

        /**
         * Sort a student list according to the alphabet
         */
        public void SortByName()
        {
            StudentList.Sort(delegate (StudentInfo sv1, StudentInfo sv2)
            {
                return sv1.Name.CompareTo(sv2.Name);
            });
        }

        /**
         * Sort a student list according to the GPA
         */
        public void SortByGPA()
        {
            StudentList.Sort(delegate (StudentInfo sv1, StudentInfo sv2)
            {
                return sv1.GPA.CompareTo(sv2.GPA);
            });
        }

        /**
         * Find student by ID
         * Show a student in list
         */
        public StudentInfo FindByID(int ID)
        {
            StudentInfo searchResult = null;
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (StudentInfo studFind in StudentList)
                {
                    if (studFind.ID == ID)
                    {
                        searchResult = studFind;
                    }
                }
            }
            return searchResult;
        }                                        

        /**
         * Find student by name
         * Show a list of students
         */
        public List<StudentInfo> FindByName(String keyword)
        {
            List<StudentInfo> searchResult = new List<StudentInfo>();
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (StudentInfo studFind in StudentList)
                {
                    if (studFind.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(studFind);
                    }
                }
            }
            return searchResult;
        }

        /**
         * Delete a student by ID
         */
        public bool isDeleteById(int ID)
        {
            bool Deleted = false;
            // Find a student by ID
            StudentInfo studDelete = FindByID(ID);
            if (studDelete != null)
            {
                Deleted = StudentList.Remove(studDelete);
            }
            return Deleted;
        }

        /**
         * Calculate GPA
         */
        private void CalculateGPA(StudentInfo stud)
        {
            double GPA = (stud.Mathh + stud.Physical + stud.Chemical) / 3;
            stud.GPA = Math.Round(GPA, 2, MidpointRounding.AwayFromZero);
        }

        /**
         * Ranked of student
         */
        private void Ranked(StudentInfo studRank)
        {
            if (studRank.GPA >= 8)
            {
                studRank.Rate = "Excellence";
            }
            else if (studRank.GPA >= 6.5)
            {
                studRank.Rate = "Great";
            }
            else if (studRank.GPA >= 5)
            {
                studRank.Rate = "Good";
            }
            else
            {
                studRank.Rate = "Bad";
            }
        }

        /**
         * Show student list
         */
        public void ShowStudentList(List<StudentInfo> studentList)
        {
            // Display column title
            Console.WriteLine(" |{0, -5} | {1, -30} | {2, -7} | {3, 5} | {4, 6} | {5, 9} | {6, 5} | {7, 10} | {8, 10}|",
                              "ID", "Name", "Gender", "Age", "Math", "Physical", "Chemical", "GPA", "Rank");
            // Display student list
            if (studentList != null && studentList.Count > 0)
            {
                foreach (StudentInfo stud in studentList)
                {
                    Console.WriteLine(" |{0, -5} | {1, -30} | {2, -7} | {3, 5} | {4, 6} | {5, 9} | {6, 5} | {7, 10} | {8, 10}|",
                                      stud.ID, stud.Name, stud.Gender, stud.Age, stud.Mathh, stud.Physical, stud.Chemical,
                                      stud.GPA, stud.Rate);
                }
            }
            Console.WriteLine();
        }

        /*
         * Get a student list
         */
        public List<StudentInfo> getStudentList()
        {
            return StudentList;
        }
    }

}

