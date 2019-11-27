using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftToDo
{
    public class Program
    {

        public static List<TaskDate> taskDate = new List<TaskDate>();
        public static List<TaskCheckList> taskCheckList = new List<TaskCheckList>();
        public static TaskArchived taskArchived = new TaskArchived();
        public static bool StartMenuRun = true;

        static void Main(string[] args)
        {
            while (StartMenuRun)
            {
                StartMenu();
            }
        }
        static void UpdateTaskStatus(int taskType, int taskIndex)
        {
            if (taskType == 0)
            {
                taskCheckList[taskIndex].SetTaskStatus(true, false, false);
            }
            else
            {
                taskDate[taskIndex].SetTaskStatus(true, false, false);
            }


        }

        public static int ArchiveAllDoneTask()
        {
            int taskDateArchived = 0;
            int taskCheckListArchived = 0;

            for (int i = taskDate.Count - 1; i >= 0; i--)
            {
                if (taskDate[i].TaskStatus.done == true)
                {
                    taskDate[i].TaskStatus.archive = true;
                    taskArchived.ArchiveTask(taskDate[i]);
                    taskDate.RemoveAt(i);
                    taskDateArchived = 1;
                }

            }

            for (int y = taskCheckList.Count - 1; y >= 0; y--)
            {
                if (taskCheckList[y].TaskStatus.done == true)
                {
                    taskCheckList[y].TaskStatus.archive = true;
                    taskArchived.ArchiveTask(taskCheckList[y]);
                    taskCheckList.RemoveAt(y);
                    taskCheckListArchived = 1;
                }

            }
            if (taskCheckListArchived == 1 || taskDateArchived == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public static void ListTask(List<TaskCheckList> taskCheckList)
        {
            int count = 0;
            Console.WriteLine("\nTaskCheckList Type=0");
            foreach (TaskCheckList task in taskCheckList)
            {
                Console.WriteLine("------------------------------------------------");
                TaskStatus taskStatus = task.GetTaskStatus();
                Console.WriteLine($"[{count}]: {task.GetTask()}\t\t Done={taskStatus.done} Todo={taskStatus.todo}");
                int checkCount = 0;
                List<CheckListTask> checkListTask = task.GetTaskCheckList();

                foreach (CheckListTask checkTask in checkListTask)
                {
                    TaskStatus checkTaskStatus = checkTask.GetTaskStatus();
                    Console.WriteLine($"\t[{checkCount}]: {checkTask.GetTask()}\t Done={checkTaskStatus.done} Todo={checkTaskStatus.todo}");
                    checkCount++;
                }
                Console.WriteLine("------------------------------------------------");
                count++;
            }

        }

        public static void ListTask(List<TaskDate> taskDate)
        {
            int count = 0;
            Console.WriteLine("\nTaskDate Type=1");
            Console.WriteLine("------------------------------------------------");
            foreach (TaskDate task in taskDate)
            {

                TaskStatus taskStatus = task.GetTaskStatus();
                Console.WriteLine($"[{count}]: {task.GetTask()}\t Last Todo Date={task.GetTaskTodoDate()} Done={taskStatus.done} Todo={taskStatus.todo}");

                count++;
            }
        }


        public static void AddNewTask()
        {
            Console.Clear();
            Console.WriteLine("Please enter the number of Task you want to add");
            Console.WriteLine("[0]\tTask with Last Todo date");
            Console.WriteLine("[1]\tTask with Checklist");
            Console.WriteLine("[2]\tBack to Menu");

            switch (Console.ReadLine())
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("Please enter Task to Add");
                    string taskDateToAdd = Console.ReadLine();
                    string date = DateFormat.CreateDate();
                    TaskDate newTaskDate = new TaskDate();
                    newTaskDate.CreateTask(date, taskDateToAdd);
                    taskDate.Add(newTaskDate);
                    Console.Clear();
                    StartMenu();
                    break;
                case "1":
                    Console.WriteLine("Please enter Task to Add");
                    string taskToAdd = Console.ReadLine();
                    TaskCheckList newTaskCheckList = new TaskCheckList();
                    newTaskCheckList.CreateTask(taskToAdd);
                    bool running = true;
                    while (running)
                    {
                        Console.WriteLine("Add checklistitem to task");
                        string subTask = Console.ReadLine();
                        newTaskCheckList.AddCheckListTask(subTask);
                        Console.WriteLine("Enter q to exit or press any other key to enter new task");
                        string quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            running = false;
                        }
                        Console.Clear();
                    }
                    taskCheckList.Add(newTaskCheckList);
                    Console.Clear();
                    StartMenu();
                    break;
                case "2":
                    Console.Clear();
                    StartMenu();
                    break;
                case "q":
                    Console.Clear();
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
            menu.Add("Show all archived task");
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
                        Console.Clear();
                        ListTask(taskCheckList);
                        ListTask(taskDate);
                        Console.WriteLine("\nTo change task-status please begin with enter the Type-number or q to quit");
                        string taskChoice = Console.ReadLine();
                        switch (taskChoice)
                        {
                            case "0":
                                Console.Clear();
                                ListTask(taskCheckList);
                                Console.WriteLine("\nPlease enter the number of task you want to mark as done or q to quit");
                                string index;
                                int number = -1;
                                bool success = false;
                                while (success == false)
                                {
                                    index = Console.ReadLine();
                                    success = Int32.TryParse(index, out number);

                                    if ((success && number <= taskCheckList.Count - 1) == true)
                                    {
                                        success = true;
                                    }
                                    else
                                    {
                                        if (index.Equals("q"))
                                        {
                                            Console.Clear();
                                            return;
                                        }
                                        success = false;
                                        Console.WriteLine("Please try and enter number again or q to quit");
                                    }
                                }
                                UpdateTaskStatus(0, number);
                                Console.Clear();
                                break;
                            case "1":
                                Console.Clear();
                                ListTask(taskDate);
                                Console.WriteLine("Please enter the number of task you want to mark as done or q to quit");
                                string indexDate;
                                int numberDate = -1;
                                bool successDate = false;
                                while (successDate == false)
                                {
                                    indexDate = Console.ReadLine();
                                    successDate = Int32.TryParse(indexDate, out numberDate);

                                    if ((successDate && numberDate <= taskDate.Count - 1) == true)
                                    {
                                        successDate = true;
                                    }
                                    else
                                    {
                                        if (indexDate.Equals("q"))
                                        {
                                            Console.Clear();
                                            return;
                                        }
                                        successDate = false;
                                        Console.WriteLine("Please try and enter number again or q to quit");
                                    }
                                }
                                UpdateTaskStatus(1, numberDate);
                                Console.Clear();
                                break;
                            case "q":
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Enter 0 for TaskCheckList or 1 for TaskDate or q to quit");
                                break;
                        }
                        break;
                    case "3":
                        ArchiveAllDoneTask();
                        break;
                    case "4":
                        taskArchived.ListArchiveTask();
                        Console.ReadKey();
                        break;
                    case "5":
                        StartMenuRun = false;
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Enter a number between 1-4");
                        break;
                }
            }
        }

    }
}









