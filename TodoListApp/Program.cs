using System;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("Todo List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Mark Task As Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Filter Tasks (Completed)");
                Console.WriteLine("6. Filter Tasks (Not Completed)");
                Console.WriteLine("7. Exit");

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        taskManager.AddTask(description);
                        break;

                    case "2":
                        taskManager.ViewTasks();
                        break;

                    case "3":
                        Console.Write("Enter task index to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int markIndex))
                        {
                            taskManager.MarkTaskAsCompleted(markIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter task index to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {
                            taskManager.DeleteTask(deleteIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "5":
                        taskManager.FilterTasks(true);
                        break;

                    case "6":
                        taskManager.FilterTasks(false);
                        break;

                    case "7":
                        taskManager.SaveTasksToFile();
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
