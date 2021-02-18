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
    public class TodoController : BaseController
    {
        private ITodoEngine _todoEngine;
        public TodoController(ITodoEngine todoEngine)
        {
            _todoEngine = todoEngine;
        }

        public IActionResult ListDetails(int listId)
        {
            var operationMessage = (TempData["OperationMessage"] ?? "").ToString();

            if (!string.IsNullOrWhiteSpace(operationMessage))
            {
                ViewBag.OperationMessage = operationMessage;
            }
            var list = _todoEngine.GetListById(listId);
            return View(list);
        }

        public IActionResult CreateList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateList(TodoListModel model)
        {
            if (ModelState.IsValid)
            {
                var todoList = new TodoList()
                {
                    Name = model.Name
                };
                var result = _todoEngine.CreateTodoList(todoList);
                if (result != null)
                {
                    ViewBag.OperationMessage = "List Created! | " + model.Name;
                    model.Id = result.Id;
                }
                else
                {
                    ModelState.AddModelError("", "An Error occurred when list attempting to create");
                }
            }
            return View(model);
        }

        public IActionResult UpdateList(int listId)
        {
            var list = _todoEngine.GetListById(listId);
            var listModel = new TodoListModel()
            {
                Name = list.Name,
                Id = list.Id
            };
            return View(listModel);
        }

        [HttpPost]
        public IActionResult UpdateList(TodoListModel model)
        {
            if (ModelState.IsValid)
            {
                var list = _todoEngine.GetListById(model.Id);
                if (list != null)
                {
                    list.Name = model.Name;
                    var result = _todoEngine.UpdateTodoList(list);
                    if (result != null)
                    {
                        ViewBag.OperationMessage = model.Name + " List Updated!";
                        model.Id = result.Id;
                    }
                    else
                    {
                        ModelState.AddModelError("", "An Error occurred when list attempting to update");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Todo list not found!");
                }
            }
            return View(model);
        }

        public IActionResult DeleteList(int listId)
        {
            var list = _todoEngine.GetListById(listId);
            string listName = list.Name;
            _todoEngine.DeleteTodoList(listId);
            var operationMessage = listName + " List deleted successfully!";
            TempData["OperationMessage"] = operationMessage;
            return RedirectToAction("index", "home");
        }
    }
}
