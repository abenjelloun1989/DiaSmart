using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiaSmartApi.Models;

namespace DiaSmartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealItemsController : ControllerBase
    {
        private readonly MealItemContext _context;

        public MealItemsController(MealItemContext context)
        {
            _context = context;
        }

        // GET: api/MealItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealItem>>> GetMealItems()
        {
            return await _context.MealItems.ToListAsync();
        }

        // GET: api/MealItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealItem>> GetMealItem(long id)
        {
            var mealItem = await _context.MealItems.FindAsync(id);

            if (mealItem == null)
            {
                return NotFound();
            }

            return mealItem;
        }

        // PUT: api/MealItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealItem(long id, MealItem mealItem)
        {
            if (id != mealItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(mealItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealItemExists(id))
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

        // POST: api/MealItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealItem>> PostMealItem(MealItem mealItem)
        {
            _context.MealItems.Add(mealItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealItem", new { id = mealItem.Id }, mealItem);
        }

        // DELETE: api/MealItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealItem(long id)
        {
            var mealItem = await _context.MealItems.FindAsync(id);
            if (mealItem == null)
            {
                return NotFound();
            }

            _context.MealItems.Remove(mealItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealItemExists(long id)
        {
            return _context.MealItems.Any(e => e.Id == id);
        }
    }
}
