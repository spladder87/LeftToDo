using System;

namespace LeftToDo
{
    public class TaskDate : Task
    {
        private string date;

        public string GetTaskTodoDate()
        {
            return date;

        }
        public void CreateTask(string date, string task)
        {
            this.task = task;
            this.date = date;
        }

    }
}
