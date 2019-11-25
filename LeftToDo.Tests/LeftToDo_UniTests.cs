using System;
using Xunit;
using System.Collections.Generic;
using LeftToDo;

namespace LeftToDo.Tests
{
    public class LeftToDo_UniTests
    {

        private readonly Program _leftToDo;

        public LeftToDo_UniTests()
        {
            _leftToDo = new Program();
        }

        [Fact]
        public void CreateTaskDate()
        {
            TaskDate taskDate = new TaskDate();
            taskDate.CreateTask("26/14/2019", "CreateTaskDate");
            bool result = false;
            if (taskDate.GetTask().Contains("CreateTaskDate") &&
            taskDate.GetTaskTodoDate().Contains("26/14/2019"))
            {
                result = true;
            }
            Assert.True(result, "result dont contain string");

        }

        [Fact]
        public void CreateTaskCheckListSendObject()
        {
            TaskCheckList taskCheckList = new TaskCheckList();
            taskCheckList.CreateTask("CreateTaskCheckListSendObject");
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.CreateTask("checkListTask");
            taskCheckList.AddCheckListTask(checkListTask);
            List<CheckListTask> ListCheckList = taskCheckList.GetTaskCheckList();

            bool result = false;
            if (taskCheckList.GetTask().Contains("CreateTaskCheckListSendObject") &&
            ListCheckList[0].GetTask().Contains("checkListTask"))
            {
                result = true;
            }
            Assert.True(result, "result dont contain string");

        }
        [Fact]
        public void CreateTaskCheckListSendTask()
        {
            TaskCheckList taskCheckList = new TaskCheckList();
            taskCheckList.CreateTask("CreateTaskCheckListSendTask");
            taskCheckList.AddCheckListTask("checkListTask");
            List<CheckListTask> ListCheckList = taskCheckList.GetTaskCheckList();

            bool result = false;
            if (taskCheckList.GetTask().Contains("CreateTaskCheckListSendTask") &&
            ListCheckList[0].GetTask().Contains("checkListTask"))
            {
                result = true;
            }
            Assert.True(result, "result dont contain string");

        }

    }
}
