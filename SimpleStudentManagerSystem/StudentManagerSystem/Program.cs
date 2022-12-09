using SimpleStudentManagementProgram;

ManageStudent stud = new ManageStudent();
int key;
do
{
    Console.WriteLine("\nSTUDENT MANAGEMENT PROGRAM");
    Console.WriteLine(" ____________________________________________________________");
    Console.WriteLine(" |                           MENU                           |");
    Console.WriteLine(" |__________________________________________________________|");
    Console.WriteLine(" | 1. | Add student.                                        |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 2. | Sort a student list by Grade Point Average (GPA).   |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 3. | Display student list.                               |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 0. | Exit.                                               |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.Write("\nYour selection: ");
    key = int.Parse(Console.ReadLine());
    switch (key)
    {
        case 1:
            Console.WriteLine("\n1. Add student.");
            stud.inputStudentInfo();
            Console.WriteLine("\nCompleted add new student!");
            break;
        case 2:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n2. Sort a student list by Grade Point Average (GPA).");
                stud.SortByGPA();
                stud.DisplayStudentList(stud.getStudentList());
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 3:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n3. Display student list.");
                stud.DisplayStudentList(stud.getStudentList());
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 0:
            Console.WriteLine("\nYou choose exit program!\nGOODBYE");
            return;
        default:
            Console.WriteLine("\nThere is no this option!");
            Console.WriteLine("\nPlease choose option in menu.");
            break;
    }
} while (key != 0) ;


