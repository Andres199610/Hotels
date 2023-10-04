using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController:ControllerBase

    {

        private readonly DataContext _context;

        public CompaniesController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Companies.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {

                return NotFound();
            }

            return Ok(company);

        }


        [HttpPost]
        public async Task<ActionResult> Post(Company company)
        {

            _context.Add(company);
            await _context.SaveChangesAsync();
            return Ok(company);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Company company)
        {

            _context.Update(company);
            await _context.SaveChangesAsync();
            return Ok(company);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Companies
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
