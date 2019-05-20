using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListV5.Models
{
    public class InMemoryTaskRepository:ITaskRepository
    {
        readonly List<ListTask> tasks;

        public InMemoryTaskRepository()
        {
            if (tasks == null)
            {
                tasks = new List<ListTask>()
                    {
                        new ListTask { Id= 1, Description="Call Mum",Status=false},
                        new ListTask { Id= 2, Description="Book holidays",Status=true},
                    };
            }
        }


        public ListTask Add(ListTask newTask)
        {
            if (newTask != null)
            {
                tasks.Add(newTask);
                newTask.Id = tasks.Max(r => r.Id) + 1;
                newTask.Status = false;
            }
            return newTask;
        }

        public IEnumerable<ListTask> GetAll()
        {
            return tasks.OrderByDescending(r => r.Description);
        }

        public ListTask Remove(int removeTaskId)
        {
            ListTask task = tasks.SingleOrDefault(r => r.Id == removeTaskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return task;
        }

        public ListTask UpdateStatus(int updateTaskId)
        {
            ListTask task = tasks.SingleOrDefault(r => r.Id == updateTaskId);
            if (task != null)
            {
                task.Status = !task.Status;
            }
            return task;

        }
    }
}
