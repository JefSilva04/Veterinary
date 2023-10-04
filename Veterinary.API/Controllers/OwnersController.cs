using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController:ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //200
            return Ok(await _context.Owners.ToListAsync());
        }

        //Get por parametro
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int Id)
        {
            //200
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == Id);
            
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        //Insertar un registro
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }
    }
}
