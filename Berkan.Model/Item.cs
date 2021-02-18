using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Berkan.Model
{
    [Table("TodoItems")]
    public class TodoItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime EndDate { get; set; }
        public virtual TodoList TodoList { get; set; }
        public int TodoListId { get; set; }
        public bool Completed { get; set; }
    }
}
