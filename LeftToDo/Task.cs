using System;

using System.Collections.Generic;

namespace LeftToDo
{
    public abstract class Task
    {
        protected string task { get; set; }
        public TaskStatus TaskStatus = new TaskStatus();

        public void CreateTask(string task)
        {
            this.task = task;
        }

        public string GetTask()
        {
            return task;
        }
        public TaskStatus GetTaskStatus()
        {
            return TaskStatus;
        }
        public void SetTaskStatus(bool done, bool todo, bool archive)
        {
            TaskStatus.done = done;
            TaskStatus.todo = todo;
            TaskStatus.archive = archive;
        }


    }
}
