
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

manager.AddTask("Learn Variables");
manager.AddTask("Learn Methods");
manager.AddTask("Learn Classes");

TaskItem? task = manager.FindTaskById(2);
if (task != null) {
    Console.WriteLine(task.Name);
}
else
{
    Console.WriteLine("Task not found.");
}

manager.UpdateTask(2, "Practice CRUD");
manager.ShowTasks();

manager.DeleteTask(2);
manager.ShowTasks();

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
            Console.WriteLine("Enter task name to search: ");
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
                Console.WriteLine("Task name cannot be empty.");
            }
            break;

        // UPDATE: Complete task
        case "6":
            Console.Write("Enter task ID to complete: ");
            string? completeInput = Console.ReadLine();

            if (int.TryParse(completeInput, out int completeId))
            {
                manager.CompleteTask(completeId);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
            break;

        // UPDATE: Rename task

        case "7":
            Console.WriteLine("Enter task ID to complete: ");
            string? updateInput = Console.ReadLine();

            if (int.TryParse(updateInput, out int updateId))
            {
                Console.Write("Enter new task name: ");
                string? newName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    manager.UpdateTask(updateId, newName);
                }
                else
                {
                    Console.WriteLine("Task name cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
            break;

        // DELETE
        case "8":
            Console.Write("Enter task ID to delete: ");
            string? deleteInput = Console.ReadLine();

            if (int.TryParse(deleteInput, out int deleteId))
            {
                manager.DeleteTask(deleteId);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
            break;

        // EXIT
        case "9":
            isRunning = false;
            Console.WriteLine("Goodbye!");
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


