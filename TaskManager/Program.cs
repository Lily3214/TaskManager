
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TaskManager;
// ==================================
// MAIN PROGRAM
// ==================================

Console.WriteLine("Welcome to C# Task Manager!");

Console.Write("What is your name? ");
string? userName = Console.ReadLine();

Console.WriteLine("Hello, " + userName + "!");

// Create an object
TaskManagerMethod manager = new TaskManagerMethod();

bool isRunning = true;

// Repeat the menu until the user exits
while (isRunning)
{
    ShowMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter task name: ");
            string? taskName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(taskName))
            {
                manager.AddTask(taskName);
            }
            else
            {
                Console.WriteLine("Task name cannot be empty.");
            }
            break;

        case "2":
            manager.ShowTasks();
            break;

        case "3":
            manager.CheckTaskCount();
            break;

        case "4":
            manager.DisplayTaskNumbers();
            break;

        case "5":
            isRunning = false;
            Console.WriteLine("Goodbye!");
            break;

        case "6":
            Console.Write("Enter task name to search: ");
            string? searchName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                bool exists = manager.TaskExists(searchName);

                if (exists)
                {
                    Console.WriteLine("Task exists!");
                }
                else
                {
                    Console.WriteLine("Task does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a task name.");
            }
            break;

        case "7":
            Console.WriteLine("Enter task ID to complete: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int taskId))
            {
                manager.CompleteTask(taskId);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

// ==================================
// METHOD 1: SHOW MENU
// ==================================


static void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== TASK MANAGER =====");
    Console.WriteLine("1. Add a task");
    Console.WriteLine("2. View all tasks");
    Console.WriteLine("3. Check task count");
    Console.WriteLine("4. Display task numbers");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Check if a task exists");
    Console.WriteLine("7. Complete a task");
}


