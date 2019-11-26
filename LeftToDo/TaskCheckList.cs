using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftToDo
{
    public class TaskCheckList : Task
    {
        private List<CheckListTask> checkListTasks = new List<CheckListTask>();

        public void AddCheckListTask(CheckListTask checkListTask)
        {
            checkListTasks.Add(checkListTask);
        }
        public void AddCheckListTask(string task)
        {
            Console.WriteLine($"Adding {task}");
            CheckListTask newCheckListTask = new CheckListTask();
            newCheckListTask.CreateTask(task);
            checkListTasks.Add(newCheckListTask);

        }

        public List<CheckListTask> GetTaskCheckList()
        {
            return checkListTasks;
        }
        public void ChangeCheckListTask(int index, CheckListTask CheckListTask)
        {
            checkListTasks[index] = CheckListTask;
        }


    }
}
