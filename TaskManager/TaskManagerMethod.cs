using System;
using System.Collections.Generic;

namespace TaskManager
{
	public class TaskManagerMethod
	{
		// Store the tasks
		private List<TaskItem> tasks = new List<TaskItem>();

		private int nextId = 1;

		// Constructur
		public TaskManagerMethod() {
			Console.WriteLine("Task Manager initialized.");
		}
		// Add a task
		public void AddTask(string name)
		{
			TaskItem task = new TaskItem(nextId, name);

			tasks.Add(task);
			nextId++;

			Console.WriteLine("Task added!");
		}

		// Display all tasks
		public void ShowTasks()
		{
			if (tasks.Count == 0)
			{
				Console.WriteLine("No tasks available.");
				return;
			}

			Console.WriteLine("Your Tasks:");

			foreach (TaskItem task in tasks) {
				Console.WriteLine(task.Name);
			}
		}

		// Return total number of tasks
		public int GetTaskCount()
		{
			return tasks.Count;
		}

		// Check number of tasks
		public void CheckTaskCount()
		{
			int count = GetTaskCount();
			if (count == 0)
			{
				Console.WriteLine("You have no tasks.");
			}
			else if (count == 1)
			{
				Console.WriteLine("You have exactly 1 task.");
			}
			else
			{
				Console.WriteLine("You have multiple tasks.");
			}
		}
		// Display task numbers
		public void DisplayTaskNumbers()
		{
			foreach (TaskItem task in tasks)
			{
				Console.WriteLine($"{task.Id}. {task.Name}");
			}
		}

		// Check whether a task exists
		public bool TaskExists(string name)
		{
			foreach (TaskItem task in tasks)
			{
				if (string.Equals(
					task.Name,
					name,
					StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		// Complete a task by ID
		public void CompleteTask(int id)
		{
			foreach (TaskItem task in tasks)
			{
				if (task.Id == id) {
					task.IsCompleted = true;
					Console.WriteLine("Task completed!");
					return;
				}
			}
			Console.WriteLine("Task not found.");
		}
	}
}
