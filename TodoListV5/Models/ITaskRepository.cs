using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListV5.Models
{
    public interface ITaskRepository
    {
        IEnumerable<ListTask> GetAll();
        ListTask Add(ListTask newTask);
        ListTask Remove(int removeTaskId);
        ListTask UpdateStatus(int updateTaskId);
    }
}
