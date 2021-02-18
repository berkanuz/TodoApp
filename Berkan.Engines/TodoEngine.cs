using Berkan.Data;
using Berkan.Engines.Interfaces;
using Berkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berkan.Engines
{
    public class TodoEngine : ITodoEngine
    {
        private DAL _dal;
        public TodoEngine(DAL dal)
        {
            _dal = dal;
        }
        public List<TodoList> GetAllLists()
        {
            var lists = _dal.TodoLists.ToList();
            return lists;
        }

        public TodoList GetListById(int id)
        {
            var list = _dal.TodoLists.Where(list => list.Id == id).FirstOrDefault();
            return list;
        }

        public TodoList UpdateTodoList(TodoList item)
        {
            _dal.TodoLists.Update(item);
            var result = _dal.SaveChanges();
            if (result != 1)
            {
                item = null;
            }
            return item;
        }

        public bool DeleteTodoList(int id)
        {
            var list = GetListById(id);
            if (list == null)
            {
                return false;
            }
            _dal.TodoLists.Remove(list);
            var result = _dal.SaveChanges();
            return true;
        }

        public TodoList CreateTodoList(TodoList item)
        {
            _dal.TodoLists.Add(item);
            var result = _dal.SaveChanges();
            if (result != 1)
            {
                item = null;
            }
            return item;
        }
    }
}
