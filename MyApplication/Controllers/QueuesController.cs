using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApplication.Data;
using MyApplication.Models;
using MyApplication.Services;

namespace MyApplication.Controllers
{
    /// <summary>
    /// Контроллер очереди
    /// </summary>
    [Authorize]
    public class QueuesController : Controller
    {
        private readonly IQueueService _que;
        public QueuesController(IQueueService que)
        {
            _que = que;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await this._que.GetQueue(HttpContext.User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MicrowaveId = new SelectList(await _que.GetMicrowave(), "MicrowaveId", "Mark");
            ViewBag.UsingTimeId = new SelectList(await _que.GetUsingTime(), "UsingTimeId", "Value");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Queue queue)
        {
            if (ModelState.IsValid)
            {
                await _que.CreateQue(queue);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MicrowaveId = new SelectList(await _que.GetMicrowave(), "MicrowaveId", "Mark", queue.MicrowaveId);
            ViewBag.UsingTimeId = new SelectList(await _que.GetUsingTime(), "MicrowaveId", "Mark", queue.UsingTimeId);
            return View(queue);
        }

    }
}
