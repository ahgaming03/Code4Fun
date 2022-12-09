using StudentManagementProgram;

Manage stud = new Manage();

while (true)
{
    Console.WriteLine("\nSTUDENT MANAGEMENT PROGRAM");
    Console.WriteLine(" ____________________________________________________________");
    Console.WriteLine(" |                           MENU                           |");
    Console.WriteLine(" |__________________________________________________________|");
    Console.WriteLine(" | 1. | Add student.                                        |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 2. | Update student information by ID.                   |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 3. | Delete a student by ID.                             |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 4. | Find student by Name.                               |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 5. | Sort a student list by Grade Point Average (GPA).   |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 6. | Sort a student list by Name.                        |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 7. | Sort a student list by ID.                          |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 8. | Display student list.                               |");
    Console.WriteLine(" |____|_____________________________________________________|");
    Console.WriteLine(" | 0. | Exit.                                               |");
    Console.WriteLine(" |____|_____________________________________________________|");
    
    Console.Write("\nYour selection: ");
    int key = int.Parse(Console.ReadLine());
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
                int id;
                Console.WriteLine("\n2. Update student information. ");
                Console.Write("\nEnter ID: ");
                id = int.Parse(Console.ReadLine());
                stud.UpdateStudentInformation(id);
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 3:
            if (stud.NumbersOfStudent() > 0)
            {
                int id;
                Console.WriteLine("\n3. Delete a student.");
                Console.Write("\nEnter ID: ");
                id = int.Parse(Console.ReadLine());
                if (stud.isDeleteById(id))
                {
                    Console.WriteLine("\nStudent have id = {0} is deleted.", id);
                }
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 4:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n4. Find student by ten.");
                Console.Write("\nEnter the name to find: ");
                string name = Console.ReadLine();
                List<StudentInfo> searchResult = stud.FindByName(name);
                stud.ShowStudentList(searchResult);
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 5:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n5. Sort a student list by Grade Point Average (GPA).");
                stud.SortByGPA();
                stud.ShowStudentList(stud.getStudentList());
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 6:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n6. Sort a student list by Name.");
                stud.SortByName();
                stud.ShowStudentList(stud.getStudentList());
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 7:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n7. Sort a student list by ID.");
                stud.SortByID();
                stud.ShowStudentList(stud.getStudentList());
            }
            else
            {
                Console.WriteLine("\nList of empty students!");
            }
            break;
        case 8:
            if (stud.NumbersOfStudent() > 0)
            {
                Console.WriteLine("\n8. Display student list.");
                stud.ShowStudentList(stud.getStudentList());
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
}


