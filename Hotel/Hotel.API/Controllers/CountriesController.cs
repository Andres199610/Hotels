using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {

        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {



            _context = context;
        }
        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Countries.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries
        .Include(x => x.States)
        .ToListAsync());

        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var country = await _context.Countries
               .Include(x => x.States!)
               .ThenInclude(x => x.Cities!)
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (country is null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .ToListAsync());
        }




        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {

            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Country country)
        {

            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Countries
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