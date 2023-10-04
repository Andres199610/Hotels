using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController: ControllerBase
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cities.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {

                return NotFound();
            }

            return Ok(city);

        }


        [HttpPost]
        public async Task<ActionResult> Post(City city)
        {

            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }

        [HttpPut]
        public async Task<ActionResult> Put(City city)
        {

            _context.Update(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Cities
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
