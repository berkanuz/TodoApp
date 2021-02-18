using Berkan.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Berkan.Engines.Interfaces
{
    public interface ITodoEngine
    {
        List<TodoList> GetAllLists();
        TodoList GetListById(int id);

        TodoList CreateTodoList(TodoList item);
        TodoList UpdateTodoList(TodoList item);
        bool DeleteTodoList(int id);
    }
}
