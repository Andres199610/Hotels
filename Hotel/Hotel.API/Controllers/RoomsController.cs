using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/Rooms")]
    public class RoomsController:ControllerBase
    {
        private readonly DataContext _context;

        public RoomsController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Rooms.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (room == null)
            {

                return NotFound();
            }

            return Ok(room);

        }


        [HttpPost]
        public async Task<ActionResult> Post(Room room)
        {

            _context.Add(room);
            await _context.SaveChangesAsync();
            return Ok(room);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Room room)
        {

            _context.Update(room);
            await _context.SaveChangesAsync();
            return Ok(room);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Rooms
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
