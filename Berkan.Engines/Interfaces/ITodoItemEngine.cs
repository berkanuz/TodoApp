using Berkan.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Berkan.Engines.Interfaces
{
    public interface ITodoItemEngine
    {
        TodoItem CreateTodoItem(TodoItem item);
        TodoItem UpdateTodoItem(TodoItem item);
        TodoItem GetItemById(int itemId);
        bool DeleteTodoItem(int itemId);
    }
}
