using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoListApp
{
    public class TaskManager
    {
        private List<Task> tasks;
        private const string fileName = "tasks.txt";

        public TaskManager()
        {
            tasks = new List<Task>();
            LoadTasksFromFile();
        }

        public void AddTask(string description)
        {
            tasks.Add(new Task(description));
            SaveTasksToFile();
        }

        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        public void MarkTaskAsCompleted(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid task index.");
                return;
            }

            tasks[index].MarkAsCompleted();
            SaveTasksToFile();
        }

        public void DeleteTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid task index.");
                return;
            }

            tasks.RemoveAt(index);
            SaveTasksToFile();
        }

        public void FilterTasks(bool showCompleted)
        {
            var filteredTasks = tasks.Where(t => t.IsCompleted == showCompleted).ToList();

            if (!filteredTasks.Any())
            {
                Console.WriteLine("No tasks match the filter.");
                return;
            }

            for (int i = 0; i < filteredTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filteredTasks[i]}");
            }
        }

        public void SaveTasksToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Description}|{task.IsCompleted}");
                }
            }
        }

        private void LoadTasksFromFile()
        {
            if (!File.Exists(fileName))
            {
                return;
            }

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        var description = parts[0];
                        var isCompleted = bool.Parse(parts[1]);
                        tasks.Add(new Task(description) { IsCompleted = isCompleted });
                    }
                }
            }
        }
    }
}
