using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{

    [ApiController]
    [Route("api/bookings")]
    public class BookingsController:ControllerBase
    {
        private readonly DataContext _context;

        public BookingsController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Bookings.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (booking == null)
            {

                return NotFound();
            }

            return Ok(booking);

        }


        [HttpPost]
        public async Task<ActionResult> Post(Booking booking)
        {

            _context.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Booking booking)
        {

            _context.Update(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Bookings
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filaafectada == 0)
            {

                return NotFound();

            }

            return NoContent();



        }
    }
}
