using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/cancellations")]
    public class CancellationsController : ControllerBase
    {

        private readonly DataContext _context;

        public CancellationsController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cancellations.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var cancellation = await _context.Cancellations.FirstOrDefaultAsync(x => x.Id == id);
            if (cancellation == null)
            {

                return NotFound();
            }

            return Ok(cancellation);

        }


        [HttpPost]
        public async Task<ActionResult> Post(Cancellation cancellation)
        {

            _context.Add(cancellation);
            await _context.SaveChangesAsync();
            return Ok(cancellation);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Cancellation cancellation)
        {

            _context.Update(cancellation);
            await _context.SaveChangesAsync();
            return Ok(cancellation);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Cancellations
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
