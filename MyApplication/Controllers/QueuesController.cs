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

namespace MyApplication.Controllers
{
    [Authorize]
    public class QueuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Queues
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Queues.Include(q => q.Microwave).Include(q => q.UsingTime);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["MicrowaveId"] = new SelectList(_context.Microwaves, "MicrowaveId", "Mark");
            ViewData["UsingTimeId"] = new SelectList(_context.UsingTimes, "UsingTimeId", "Value");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QueueId,User,StartDate,UsingTimeId,MicrowaveId")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MicrowaveId"] = new SelectList(_context.Microwaves, "MicrowaveId", "MicrowaveId", queue.MicrowaveId);
            ViewData["UsingTimeId"] = new SelectList(_context.UsingTimes, "UsingTimeId", "UsingTimeId", queue.UsingTimeId);
            return View(queue);
        }

        private bool QueueExists(int id)
        {
            return _context.Queues.Any(e => e.QueueId == id);
        }
    }
}
