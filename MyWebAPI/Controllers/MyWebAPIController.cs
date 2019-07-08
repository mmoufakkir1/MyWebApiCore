using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebAPIController : ControllerBase
    {
        private readonly MyAPIContext _context;

        public MyWebAPIController(MyAPIContext context)
        {
            _context = context;

            if (_context.MyAPIitems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.MyAPIitems.Add(new MyAPIitem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyAPIitem>>> GetMyAPIitem()
        {
            return await _context.MyAPIitems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyAPIitem>> GetMyAPIitem(long id)
        {
            var myAPIitem = await _context.MyAPIitems.FindAsync(id);

            if (myAPIitem == null)
            {
                return NotFound();
            }

            return myAPIitem;
        }
    }
}
