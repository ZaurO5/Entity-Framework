using Azure;
using Entity_Framework.Constants;
using Entity_Framework.Services;

namespace Entity_Framework
{
    public static class Program 
    {
        public static void Main()
        {
            while (true)   
            {
                ShowMenu();

                Messages.InputMessage("Choice");
                string choiceInput = Console.ReadLine();
                int choice;
                bool isSucceeded = int.TryParse(choiceInput, out choice);
                if (isSucceeded)
                {
                    switch ((Operations)choice)
                    {
                        case Operations.AllTeachers:
                            TeacherService.GetAllTeachers();
                            break;
                        case Operations.CreateTeacher:
                            TeacherService.AddTeacher();
                            break;
                        case Operations.UpdateTeacher:
                            TeacherService.UpdateTeacher();
                            break;
                        case Operations.RemoveTeacher:
                            TeacherService.DeleteTeahcer();
                            break;
                        case Operations.DetailsOfTeacher:
                            TeacherService.GetTeacherDetails();
                            break;
                        case Operations.AllStudents:
                            StudentService.GetAllStudents();
                            break;
                        case Operations.CreateStudent:
                            StudentService.AddStudent();
                            break;
                        case Operations.UpdateStudent:
                            StudentService.UpdateStudent();
                            break;
                        case Operations.RemoveStudent:
                            StudentService.DeleteStudent();
                            break;
                        case Operations.DetailsOfStudent:
                            StudentService.GetStudentDetails();
                            break;
                        case Operations.Exit:
                            return;
                        default:
                            Messages.InvalidInputMessage("Choice");
                            break;
                    }
                }
                else
                    Messages.InvalidInputMessage("Choice");
            }

        }

        private static void ShowMenu()
        {
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1. All Teachers");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Update Teacher");
            Console.WriteLine("4. Delete Teacher");
            Console.WriteLine("5. Detail of Teacher");
            Console.WriteLine("6. All Students");
            Console.WriteLine("7. Add Student");
            Console.WriteLine("8. Update Student");
            Console.WriteLine("9. Delete Student");
            Console.WriteLine("10. Detail of student");
            Console.WriteLine("0. Exit");
        }
    }
}