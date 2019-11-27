using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftToDo
{

    public class TaskArchived
    {
        private List<TaskDate> TaskDate = new List<TaskDate>();
        private List<TaskCheckList> TaskCheckList = new List<TaskCheckList>();
        public void ListArchivedTask()
        {

        }
        public void ArchiveTask(TaskDate taskDate)
        {
            TaskDate.Add(taskDate);
        }

        public void ArchiveTask(TaskCheckList taskCheckList)
        {
            TaskCheckList.Add(taskCheckList);
        }

        public void ListArchiveTask()
        {
            Program.ListTask(TaskDate);
            Program.ListTask(TaskCheckList);
        }

    }
}
