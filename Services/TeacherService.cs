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
    public static class TeacherService
    {
        private static readonly AppDbContext _context;
        static TeacherService()
        {
            _context = new AppDbContext();
        }

        public static void GetAllTeachers()
        {
            foreach (var teacher in _context.Teachers.Where(t => !t.IsDeleted).ToList())
            {
                Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}, Surname: {teacher.Surname}");
            }
        }

        public static void AddTeacher()
        {
            TeacherNameInput:  Messages.InputMessage("Teacher name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Teacher name:");
                goto TeacherNameInput;
            }

            TeacherSurnameInput: Messages.InputMessage("Teacher surname:");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("teacher surname");
                goto TeacherSurnameInput;
            }

            Teacher teacher = new Teacher
            {
                Name = name,
                Surname = surname,
            };

            _context.Teachers.Add(teacher);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception) 
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Teacher", "added");
        }
        public static void UpdateTeacher()
        {
            GetAllTeachers();

            TeacherIdInput: Messages.InputMessage("teacher id");
            var id = Console.ReadLine();
            int teahcerId;
            bool isSucceeded = int.TryParse(id, out teahcerId);
            if (isSucceeded)
            {
                Messages.InvalidInputMessage("Teacher id");
                goto TeacherIdInput;
            }

            var teacher = _context.Teachers.Find(teahcerId);
            if (teacher is null)
            {
                Messages.NotFoundMessage("Teacher is not found");
                return;
            }

            TeacherNameInput: Messages.WantToChangeMessage("name");
            var choiceInput = Console.ReadLine();
            char choice;
            isSucceeded = char.TryParse(choiceInput, out choice);
            if (isSucceeded || !choice.IsValidChoice())
            {
                Messages.InvalidInputMessage("choice");
                goto TeacherNameInput;
            }

            string newName = string.Empty;
            if (choice == 'y')
            {
                Messages.InputMessage("new name");
                newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    goto TeacherNameInput;
                }
            }

            TeacherSurnameInput: Messages.WantToChangeMessage("surname");
            choiceInput = Console.ReadLine();
            isSucceeded = char.TryParse(choiceInput, out choice);
            if (!isSucceeded || !choice.IsValidChoice())
            {
                Messages.InvalidInputMessage("Choice");
                goto TeacherSurnameInput;
            }

            string newSurname = string.Empty;
            if (choice == 'y')
            {
            NewSurnameInput: Messages.InputMessage("new surname");
            newSurname = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newSurname))
                    goto NewSurnameInput;
            }

            if (!string.IsNullOrEmpty(newSurname)) teacher.Name = newName;
            if (!string.IsNullOrEmpty(newSurname)) teacher.Surname = newSurname;

            _context.Teachers.Update(teacher);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception) 
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Teacher", "updated");

        }
        public static void DeleteTeahcer()
        {
            GetAllTeachers();

            TeacherIdInput: Messages.InputMessage("Teacher id");
            var idInput = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(idInput, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Teacher id");
                goto TeacherIdInput;
            }

            var teacher = _context.Teachers.Find(id);
            if (teacher is null)
            {
                Messages.NotFoundMessage("Teacher");
                return;
            }

            teacher.IsDeleted = true;
            _context.Teachers.Update(teacher);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }

            Messages.SuccessMessage("Teacher","deleted");
        }
        public static void GetTeacherDetails()
        {
            GetAllTeachers();

        TeacherIdInput: Messages.InputMessage("Teacher id");
            var idInput = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(idInput, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Teacher id");
                goto TeacherIdInput;
            }

            var teacher = _context.Teachers.Find(id);
            if (teacher is null)
            {
                Messages.NotFoundMessage("Teacher");
                return;
            }

            Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}");
        }
    }
}
