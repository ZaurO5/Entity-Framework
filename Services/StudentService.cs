using Entity_Framework.Constants;
using Entity_Framework.Contexts;
using Entity_Framework.Entities;
using Entity_Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Services
{
    public static class StudentService
    {
        private static readonly AppDbContext _context;


        static StudentService()
        {
            _context = new AppDbContext();
        }

        public static void GetAllStudents()
        {
            foreach (var student in _context.Teachers.Where(t => !t.IsDeleted).ToList())
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
            }
        }

        public static void AddStudent()
        {
            StudentNameInput: Messages.InputMessage("Student name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Student name:");
                goto StudentNameInput;
            }

            StudentSurnameInput: Messages.InputMessage("Student surname:");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("Student surname");
                goto StudentSurnameInput;
            }

            Student student = new Student
            {
                Name = name,
                Surname = surname,
            };

            _context.Students.Add(student);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Student", "added");
        }
        public static void UpdateStudent()
        {
            GetAllStudents();

            StudentIdInput: Messages.InputMessage("Student id");
            var id = Console.ReadLine();
            int studentId;
            bool isSucceeded = int.TryParse(id, out studentId);
            if (isSucceeded)
            {
                Messages.InvalidInputMessage("Student id");
                goto StudentIdInput;
            }

            var student = _context.Students.Find(studentId);
            if (student is null)
            {
                Messages.NotFoundMessage("Student is not found");
                return;
            }

            StudentNameInput: Messages.WantToChangeMessage("name");
            var choiceInput = Console.ReadLine();
            char choice;
            isSucceeded = char.TryParse(choiceInput, out choice);
            if (isSucceeded || !choice.IsValidChoice())
            {
                Messages.InvalidInputMessage("choice");
                goto StudentNameInput;
            }

            string newName = string.Empty;
            if (choice == 'y')
            {
                Messages.InputMessage("new name");
                newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    goto StudentNameInput;
                }
            }

            StudentSurnameInput: Messages.WantToChangeMessage("surname");
            choiceInput = Console.ReadLine();
            isSucceeded = char.TryParse(choiceInput, out choice);
            if (!isSucceeded || !choice.IsValidChoice())
            {
                Messages.InvalidInputMessage("Choice");
                goto StudentSurnameInput;
            }

            string newSurname = string.Empty;
            if (choice == 'y')
            {
            NewSurnameInput: Messages.InputMessage("new surname");
                newSurname = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newSurname))
                    goto NewSurnameInput;
            }

            if (!string.IsNullOrEmpty(newSurname)) student.Name = newName;
            if (!string.IsNullOrEmpty(newSurname)) student.Surname = newSurname;

            _context.Students.Update(student);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Student", "updated");

        }
        public static void DeleteStudent()
        {
            GetAllStudents();

            StudentIdInput: Messages.InputMessage("Student id");
            var idInput = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(idInput, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Student id");
                goto StudentIdInput;
            }

            var student = _context.Students.Find(id);
            if (student is null)
            {
                Messages.NotFoundMessage("Student");
                return;
            }

            student.IsDeleted = true;
            _context.Students.Update(student);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Student", "deleted");
        }
        public static void GetStudentDetails()
        {
            GetAllStudents();

            StudentIdInput: Messages.InputMessage("Student id");
            var idInput = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(idInput, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Student id");
                goto StudentIdInput;
            }

            var student = _context.Students.Find(id);
            if (student is null)
            {
                Messages.NotFoundMessage("Student");
                return;
            }

            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
        }
    }
}
