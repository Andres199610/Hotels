using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/roomimages")]
    public class RoomImagesController:ControllerBase
    {
        private readonly DataContext _context;

        public RoomImagesController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.RoomImages.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var roomImage = await _context.RoomImages.FirstOrDefaultAsync(x => x.Id == id);
            if (roomImage == null)
            {

                return NotFound();
            }

            return Ok(roomImage);

        }


        [HttpPost]
        public async Task<ActionResult> Post(RoomImage roomImage)
        {

            _context.Add(roomImage);
            await _context.SaveChangesAsync();
            return Ok(roomImage);
        }

        [HttpPut]
        public async Task<ActionResult> Put(RoomImage roomImage)
        {

            _context.Update(roomImage);
            await _context.SaveChangesAsync();
            return Ok(roomImage);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.RoomImages
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
