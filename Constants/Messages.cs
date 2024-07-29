using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Constants
{
    public static class Messages
    {
        public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid. Please try again.");
        public static void InputMessage(string title) => Console.WriteLine($"Please input {title}");
        public static void SuccessMessage(string title, string operation) => Console.WriteLine($"{title} successfuly {operation}");
        public static void ErrorOccuredMessage() => Console.WriteLine("Error occured. Please try again.");
        public static void NotFoundMessage(string title) => Console.WriteLine($"{title} not found");
        public static void WantToChangeMessage(string title) => Console.WriteLine($"Do you want to change {title}? (y or n)");
        public static void AlreadyExistMessage(string title) => Console.WriteLine($"{title} already exists, please try another one");
    }
}
