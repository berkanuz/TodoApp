using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Berkan.Model
{
    [Table("TodoLists")]
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
