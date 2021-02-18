using Berkan.App.ViewModels;
using Berkan.Engines.Interfaces;
using Berkan.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkan.App.Controllers
{
    public class TodoItemController : BaseController
    {
        private ITodoItemEngine _todoitemEngine;
        private ITodoEngine _todoEngine;
        public TodoItemController(ITodoItemEngine todoitemEngine, ITodoEngine todoEngine)
        {
            _todoitemEngine = todoitemEngine;
            _todoEngine = todoEngine;
        }

        public IActionResult CreateItem(int listId)
        {
            var list = _todoEngine.GetListById(listId);
            var model = new TodoItemModel()
            {
                EndDate = DateTime.Now,
                TodoListId = list.Id,
                TodoListName = list.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateItem(TodoItemModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new TodoItem()
                {
                    Text = model.Text,
                    EndDate = model.EndDate,
                    TodoListId = model.TodoListId
                };
                var result = _todoitemEngine.CreateTodoItem(item);
                if (result != null)
                {
                    ViewBag.OperationMessage = "Item Created Successfully!";
                }
                else
                {
                    ModelState.AddModelError("", "An Error occurred when Item attempting to create");
                }
            }
            return View(model);
        }

        public IActionResult UpdateItem(int itemId)
        {
            var item = _todoitemEngine.GetItemById(itemId);
            var model = new TodoItemModel()
            {
                Id = item.Id,
                Text = item.Text,
                EndDate = item.EndDate,
                TodoListId = item.TodoList.Id,
                TodoListName = item.TodoList.Name,
                Completed = item.Completed
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateItem(TodoItemModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _todoitemEngine.GetItemById(model.Id);
                item.Text = model.Text;
                item.EndDate = model.EndDate;
                item.Completed = model.Completed;
                var result = _todoitemEngine.UpdateTodoItem(item);
                if (result != null)
                {
                    ViewBag.OperationMessage = "Item Updated Successfully!";
                }
                else
                {
                    ModelState.AddModelError("", "An Error occurred when Item attempting to upate");
                }
            }
            return View(model);
        }

        public IActionResult DeleteItem(int itemId)
        {
            var item = _todoitemEngine.GetItemById(itemId);
            var listId = item.TodoListId;
            _todoitemEngine.DeleteTodoItem(itemId);
            var operationMessage = "Item deleted successfully!";
            TempData["OperationMessage"] = operationMessage;
            return RedirectToAction("ListDetails", "Todo", new { listId = listId });
        }
    }
}
