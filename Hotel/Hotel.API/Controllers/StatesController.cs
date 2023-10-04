using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{

    [ApiController]
    [Route("api/states")]
    public class StatesController: ControllerBase
    {


        private readonly DataContext _context;

        public StatesController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.States.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var state = await _context.States.FirstOrDefaultAsync(x => x.Id == id);
            if (state == null)
            {

                return NotFound();
            }

            return Ok(state);

        }


        [HttpPost]
        public async Task<ActionResult> Post(State state)
        {

            _context.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpPut]
        public async Task<ActionResult> Put(State state)
        {

            _context.Update(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.States
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
