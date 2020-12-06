using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DiaSmartApi.Models;
using DiaSmartApi.Services;

namespace DiaSmartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealItemsController : ControllerBase
    {
        private readonly MealItemsService _mealItemsService;

        public MealItemsController(MealItemsService mealItemsService)
        {
            _mealItemsService = mealItemsService;
        }

        // GET: api/MealItems
        [HttpGet]
        public ActionResult<List<MealItem>> Get() =>
            _mealItemsService.Get();

        // GET: api/MealItems/5
        [HttpGet("{id:length(24)}")]
        public ActionResult<MealItem> Get(string id)
        {
            var mealItem = _mealItemsService.Get(id);

            if (mealItem == null)
            {
                return NotFound();
            }

            return mealItem;
        }

        // POST: api/MealItems
        [HttpPost]
        public ActionResult<MealItem> Create(MealItem mealItemIn)
        {
            var mealItem = _mealItemsService.Create(mealItemIn);

            return CreatedAtAction("Get", new { id = mealItem.Id }, mealItem);
        }

        // PUT: api/MealItems/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, MealItem mealItemIn)
        {
            var mealItem = _mealItemsService.Get(id);

            if (id != mealItem.Id)
            {
                return NotFound();
            }

            _mealItemsService.Update(id, mealItemIn);

            return NoContent();
        }


        // DELETE: api/MealItems/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteMealItem(string id)
        {
            var mealItem = _mealItemsService.Get(id);
            if (mealItem == null)
            {
                return NotFound();
            }

            _mealItemsService.Remove(mealItem.Id);

            return NoContent();
        }
    }
}
