using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp
{
    class Db
    {

        AppContext dbConnect = new AppContext();

        /// <summary>
        /// Возвращает список экземпляров класса TaskTable
        /// </summary>
        /// <returns></returns>
        public static List<TaskTable> GetTaskList()
        {
            List<TaskTable> listOfTasks = new List<TaskTable>();
            using (AppContext dbConnect = new AppContext())
            {
                listOfTasks = dbConnect.TaskTable.ToList();
            }
            return listOfTasks;
        }


        /// <summary>
        /// Добавление записи в БД
        /// </summary>
        /// <param name="taskTable"></param>
        public void DbAdd(TaskTable taskTable)
        {
            dbConnect.TaskTable.Add(taskTable);
            dbConnect.SaveChanges();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>

        public void DbChange(TaskTable task)
        {

            using (AppContext dbConnect = new AppContext())
            {
                var result = dbConnect.TaskTable.ToList().Find(i => i.Date == task.Date);
                if (result != null)
                {
                    result.Date = task.Date;
                    result.ShortName = task.ShortName;
                    result.TaskContent = task.TaskContent;
                    result.Priority = task.Priority;
                    result.Status = task.Status;
                    dbConnect.SaveChanges();
                }
            }


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void DbOnDelete(TaskTable task)
        {
            using (AppContext dbConnect = new AppContext())
            {
                var result = dbConnect.TaskTable.ToList().Find(i => i.Date == task.Date);
                if (result != null)
                {
                    result.Status = "DELETE";
                    dbConnect.SaveChanges();
                }
            }




        }
    }

}