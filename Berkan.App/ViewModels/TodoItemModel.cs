using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berkan.App.ViewModels
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Item Text Required")]
        public string Text { get; set; }

        public DateTime EndDate { get; set; }
        public int TodoListId { get; set; }
        public string TodoListName { get; set; }
        public bool Completed { get; set; }
    }
}
