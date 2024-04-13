using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace ForEachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> todo = new List<string>
            {
                "respond to email",
                "make wireframe",
                "program feature",
                "fix bugs"
            };

            while (true)
            {
                Console.WriteLine("" +
                    "\nType 1 to see todos" +
                    "\nType 2 to add todo " +
                    "\nType 3 to view the last added Todo" +
                    "\nType 4 to remvoe todo");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Enter a number betwen 1 and 3: ");
                }

                switch (choice)
                {
                    case 1:
                        ShowTodos(todo);
                        break;
                    case 2:
                        AddToTodoList(todo);
                        break;
                    case 3:
                        viewTheLastAddedTodo(todo);
                        break;
                    case 4:
                        RemoveTodo(todo);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowTodos(List<string> todo)
        {
            Console.WriteLine("Todo List:");

            int i = 0;
            foreach (string item in todo)
            {
                Console.WriteLine($"{i + 1} {item}");
                i++;
            }
        }

        static void AddToTodoList(List<string> todo)
        {
            Console.WriteLine("Enter your todo:");
            string addedTodo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(addedTodo))
            {
                todo.Add(addedTodo);
            }
        }

        static void viewTheLastAddedTodo(List<string> todo)
        {
            if (todo.Count > 0)
            {
                string lastElement = todo[todo.Count - 1];
                Console.WriteLine("added todo:" + " " + lastElement);
            }
        }
        
        static void RemoveTodo(List<string> todo)
        {
            Console.WriteLine("Enter the number of the todo to remove:");

            if (!int.TryParse(Console.ReadLine(), out int removeTodoAtIndex) || removeTodoAtIndex < 1 || removeTodoAtIndex > todo.Count)
            {
                Console.WriteLine("Enter valid value");
            }

            string removedTodo = todo[removeTodoAtIndex - 1]; // saves todo before removing it 

            todo.RemoveAt(removeTodoAtIndex - 1); // actualy removing Todo
            Console.WriteLine($"Removed todo: {removedTodo}");
        }

    }
}

