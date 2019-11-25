using System;

namespace LeftToDo
{

    public class TaskStatus
    {
        public bool done { get; set; }
        public bool todo { get; set; }
        public bool archive { get; set; }

        public TaskStatus ()
        {
            this.done = false;
            this.todo = true;
            this.archive = false;
        }

    }
}
