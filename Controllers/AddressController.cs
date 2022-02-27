#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _02_API;
using _02_API.Models.Entity;

namespace _02_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly SqlContext _context;

        public AddressController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressEntity>>> GetAdresses()
        {
            return await _context.Adresses.ToListAsync();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressEntity>> GetAddressEntity(int id)
        {
            var addressEntity = await _context.Adresses.FindAsync(id);

            if (addressEntity == null)
            {
                return NotFound();
            }

            return addressEntity;
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressEntity(int id, AddressEntity addressEntity)
        {
            if (id != addressEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Address
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressEntity>> PostAddressEntity(AddressEntity addressEntity)
        {
            _context.Adresses.Add(addressEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressEntity", new { id = addressEntity.Id }, addressEntity);
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressEntity(int id)
        {
            var addressEntity = await _context.Adresses.FindAsync(id);
            if (addressEntity == null)
            {
                return NotFound();
            }

            _context.Adresses.Remove(addressEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressEntityExists(int id)
        {
            return _context.Adresses.Any(e => e.Id == id);
        }
    }
}
