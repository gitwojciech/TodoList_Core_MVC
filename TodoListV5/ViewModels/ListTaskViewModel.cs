using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListV5.Models;

namespace TodoListV5.ViewModels
{
    public class ListTaskViewModel
    {
        public List<ListTask> ListTasks { get; set; }
        public ListTask ListTask { get; set; }
    }
}
