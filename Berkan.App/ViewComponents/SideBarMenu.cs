using Berkan.Engines.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkan.App.ViewComponents
{
    public class SideBarMenu : ViewComponent
    {
        private ITodoEngine _todoEngine;
        public SideBarMenu(ITodoEngine todoEngine)
        {
            _todoEngine = todoEngine;
        }
        public IViewComponentResult Invoke()
        {
            var todoLists = _todoEngine.GetAllLists();
            return View("/Views/Shared/SideBarMenu.cshtml", todoLists);
        }
    }
}
