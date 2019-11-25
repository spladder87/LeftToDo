using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftToDo
{
    public class Program
    {

        public static List<TaskDate> taskDate = new List<TaskDate>();
        public static List<TaskCheckList> taskCheckList = new List<TaskCheckList>();

        static void Main(string[] args)
        {
            while (true)
            {
                StartMenu();
            }
        }


        void TaskMenu(List<TaskDate> taskDate)
        {
            int count = 0;
            foreach (TaskDate task in taskDate)
            {
                count++;
                Console.WriteLine($"[{count}]: {task.GetTask()}");
            }
        }

        void TaskMenu(List<TaskCheckList> taskCheckList)
        {
            int count = 0;
            foreach (TaskCheckList task in taskCheckList)
            {
                count++;
                Console.WriteLine($"[{count}]: {task.GetTask()}");
            }

        }

        public static void AddNewTask()
        {
            Console.Clear();
            Console.WriteLine("Please enter the number of Task you want to add)");
            Console.WriteLine("[0]\tTask with Last Todo date");
            Console.WriteLine("[1]\tTask with Checklist");
            Console.WriteLine("[2]\tBack to Menu");

            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Please enter Task to Add");
                    string taskDateToAdd = Console.ReadLine();
                    string date = DateFormat.CreateDate();
                    TaskDate newTaskDate = new TaskDate();
                    newTaskDate.CreateTask(date,taskDateToAdd);
                    taskDate.Add(newTaskDate);
                    Console.Clear();
                    StartMenu();
                    break;
                case "1":
                    Console.WriteLine("Please enter Task to Add");
                    string taskToAdd = Console.ReadLine();
                    TaskCheckList newTaskCheckList = new TaskCheckList();
                    newTaskCheckList.CreateTask(taskToAdd);
                    taskCheckList.Add(newTaskCheckList);
                    Console.Clear();
                    StartMenu();
                    break;
                case "2":
                    Console.Clear();
                    StartMenu();
                    break;
                default:
                    Console.WriteLine("Please Try Again!");
                    Console.Clear();
                    AddNewTask();
                    break;
            }
        }

        public static void StartMenu()
        {
            List<string> menu = new List<string>();
            menu.Add("Add new task");
            menu.Add("List all tasks");
            menu.Add("Archive all done task");
            menu.Add("Quit program");


            bool running = true;

            while (running)
            {
                Console.WriteLine("\nLeft Todo");
                int count = 0;
                foreach (string menuItem in menu)
                {
                    count++;
                    Console.WriteLine($"[{count}]: {menuItem}");

                }
                Console.WriteLine("Choose:");

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        AddNewTask();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Enter a number between 1-4");
                        break;
                }
            }
        }

    }
}









