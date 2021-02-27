using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ratingcore.Models;

namespace ratingcore.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase 
    {
        private readonly RatingContext _context;

        public CarsController(RatingContext context){
            _context = context;
        }

        //GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        //GET: api/cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarItem(long id)
        {
            var carItem = await _context.Cars.FindAsync(id);

            if (carItem == null)
            {
                return NotFound();
            }

            return carItem;
        }

        //PUT: api/cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Car carItem)
        {
            if (id != carItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(carItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarItemExists(id))
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

        //POST: api/cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostTodoItem(Car carItem)
        {
            _context.Cars.Add(carItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetCarItem), new { id = carItem.Id }, carItem);
        }

        //DELETE: api/cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var carItem = await _context.Cars.FindAsync(id);
            if (carItem == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(carItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarItemExists(long id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}