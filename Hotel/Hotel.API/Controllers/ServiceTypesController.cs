using Hotel.API.Data;
using Hotel.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/servicetypes")]
    public class ServiceTypesController: ControllerBase
    {

        private readonly DataContext _context;

        public ServiceTypesController(DataContext context)
        {



            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ServiceTypes.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceType == null)
            {

                return NotFound();
            }

            return Ok(serviceType);

        }


        [HttpPost]
        public async Task<ActionResult> Post(ServiceType serviceType)
        {

            _context.Add(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ServiceType serviceType)
        {

            _context.Update(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.ServiceTypes
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
