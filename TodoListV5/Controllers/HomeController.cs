using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoListV5.Models;
using TodoListV5.ViewModels;

namespace TodoListV5.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITaskRepository _taskRepository;

          public HomeController(ITaskRepository taskRepository) => _taskRepository = taskRepository;

        public IActionResult Index()
        {
            var listTasks = _taskRepository.GetAll().OrderBy(p => p.Description); ;
            var taskViewModel = new ListTaskViewModel()
            {
                ListTasks = listTasks.ToList(),
                ListTask = new ListTask()
            };
            return View(taskViewModel);

        }

        [HttpPost]
        public IActionResult Create(ListTaskViewModel newTask)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.Add(newTask.ListTask);
                TempData["MessageOK"] = $"{newTask.ListTask.Description} Created";
            }
            return RedirectToAction("Index");
        }


        //[HttpPost]
        public IActionResult Delete(int taskId)
        {
            ListTask listTask = _taskRepository.Remove(taskId);

            if (listTask == null)
            {
                TempData["MessageError"] = "Task delete failed";
            }
            else
            {
                TempData["MessageOK"] = $"{listTask.Description} deleted";
            }
            return RedirectToAction("Index");
        }
        public IActionResult CheckBoxAction(int id,string status)
        {
            ListTask listTask = _taskRepository.UpdateStatus(id);

            if (listTask == null)
            {
                TempData["MessageError"] = "Task update failed";
            }
            else
            {
                TempData["MessageOK"] = $"{listTask.Description} status updated";
            }

            return RedirectToAction("Index");
        }
            

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
