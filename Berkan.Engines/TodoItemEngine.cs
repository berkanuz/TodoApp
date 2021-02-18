using Berkan.Data;
using Berkan.Engines.Interfaces;
using Berkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berkan.Engines
{
    public class TodoItemEngine : ITodoItemEngine
    {
        private DAL _dal;
        public TodoItemEngine(DAL dal)
        {
            _dal = dal;
        }

        public TodoItem CreateTodoItem(TodoItem item)
        {
            _dal.TodoItems.Add(item);
            var result = _dal.SaveChanges();
            if (result != 1)
            {
                item = null;
            }
            return item;
        }

        public TodoItem UpdateTodoItem(TodoItem item)
        {
            _dal.TodoItems.Update(item);
            var result = _dal.SaveChanges();
            if (result != 1)
            {
                item = null;
            }
            return item;
        }

        public TodoItem GetItemById(int itemId)
        {
            var item = _dal.TodoItems.Where(item => item.Id == itemId).FirstOrDefault();
            return item;
        }

        public bool DeleteTodoItem(int itemId)
        {
            var item = GetItemById(itemId);
            if (item == null)
            {
                return false;
            }
            _dal.TodoItems.Remove(item);
            var result = _dal.SaveChanges();
            return true;
        }
    }
}
