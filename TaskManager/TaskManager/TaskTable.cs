using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class TaskTable
    {

        public int Id { get; set; }

        public string Date { get; set; }


        public string ShortName { get; set; }


        public string TaskContent { get; set; }


        public int Priority { get; set; }



        public string Status { get; set; }



        public TaskTable() { }

        public TaskTable(string date, string shortName, string taskContent, int priority, string status)
        {
            Date = date;
            ShortName = shortName;
            TaskContent = taskContent;
            Priority = priority;
            Status = status;
        }


    }
}
