using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListV5.Models
{
    public class ListTask
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(512)]
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
