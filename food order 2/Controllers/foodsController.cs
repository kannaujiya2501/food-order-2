using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using food_order_2.Models;

namespace food_order_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foodsController : ControllerBase
    {
        private readonly FoodsDbContext _context;

        public foodsController(FoodsDbContext context)
        {
            _context = context;
        }

        // GET: api/foods
        [HttpGet]
        public ActionResult<IEnumerable<food>> Getfoods()
        {
            return _context.foods.ToList();
        }

        // GET: api/foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<food>> Getfood(int id)
        {
            var food = await _context.foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // PUT: api/foods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfood(int id, food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!foodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/foods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<food>> Postfood(food food)
        {
            _context.foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfood", new { id = food.Id }, food);
        }

        // DELETE: api/foods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<food>> Deletefood(int id)
        {
            var food = await _context.foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.foods.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        private bool foodExists(int id)
        {
            return _context.foods.Any(e => e.Id == id);
        }
    }
}
