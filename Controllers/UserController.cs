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
using _02_API.Models;
using _02_API.Filters;
using _02_API.Filters.Filters;

namespace _02_API.Controllers
{
    [APIKey]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/User
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserUtPutModel>>> GetUsers()
        {
            var users = new List<UserUtPutModel>();
            foreach (var item in await _context.Users.Include(x => x.Address).ToListAsync())
                users.Add(new UserUtPutModel(
                      item.Id,
                      item.FirstName,
                      item.LastName,
                      item.Email,
                      new AddressModel(item.Address.StreetName, item.Address.PostalCode, item.Address.City)
                  ));


          return users;

        }

        // GET: api/User/5
        [_02_API_withKey
        [HttpGet("{id}")]
        public async Task<ActionResult<UserUtPutModel>> GetUserEntity(int id)
        {
            var userEntity = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

            if (userEntity == null)
            {
                return NotFound();
            }

            return new UserUtPutModel(
                      userEntity.Id,
                      userEntity.FirstName,
                      userEntity.LastName,
                      userEntity.Email,
                      new AddressModel(userEntity.Address.StreetName, userEntity.Address.PostalCode, userEntity.Address.City)
                  ); 
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEntity(int id, UserEntity userEntity)
        {
            if (id != userEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(userEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserEntity>> PostUserEntity(UserModel model)
        {
            if (await _context.Users.AnyAsync(x => x.Email == model.Email))
                return BadRequest();

            var userEntity = new UserEntity(model.FirstName, model.LastName, model.Email,model.Password);

            var address = await _context.Adresses.FirstOrDefaultAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode);
            if (address != null)
                userEntity.AddressId = address.Id;
            else
                userEntity.Address = new AddressEntity(model.StreetName, model.PostalCode, model.City);


            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEntity", new { id = userEntity.Id }, new UserUtPutModel(
                    userEntity.Id,
                    userEntity.FirstName,
                    userEntity.LastName,
                    userEntity.Email,
                    new AddressModel(userEntity.Address.StreetName, userEntity.Address.PostalCode, userEntity.Address.City)));
        }

        // DELETE: api/User/5
        [_02_API_withKey]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEntity(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            userEntity.FirstName = "";
            userEntity.LastName = "";
            userEntity.Email = "";
            userEntity.Password = "";

            userEntity.Address.StreetName = "";

            userEntity.Address.City = "";
            userEntity.Address.PostalCode = "";
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
