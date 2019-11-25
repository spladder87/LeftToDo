using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftToDo
{
    public class TaskCheckList : Task
    {
        private List<CheckListTask> CheckListTasks = new List<CheckListTask>();

        public void AddCheckListTask(CheckListTask checkListTask)
        {
            CheckListTasks.Add(checkListTask);
        }
        public void AddCheckListTask(string task)
        {
            CheckListTask newCheckListTask = new CheckListTask();
            newCheckListTask.CreateTask(task);
            CheckListTasks.Add(newCheckListTask);
        }

        public List<CheckListTask> GetTaskCheckList()
        {
            return CheckListTasks;
        }
        public void ChangeCheckListTask(int index, CheckListTask CheckListTask)
        {
            CheckListTasks[index] = CheckListTask;
        }


    }
}
