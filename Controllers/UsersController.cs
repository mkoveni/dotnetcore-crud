using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using example_app.Database.EF;
using example_app.Database.Models;
using example_app.Database.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace example_app.Controllers
{
    [Route("/users")]
    public class UsersController: Controller
    {

        AppDbContext context;
        private readonly IMapper mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = await context.Users.Include(u => u.Role).ToListAsync();

            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserResource userResource) {

            var user = mapper.Map<UserResource, User>(userResource);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var resource = mapper.Map<User, UserResource>(user);

            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,[FromBody] UserResource userResource) {

            var toUpdate = await context.Users.FindAsync(id);
            
            if(toUpdate == null)
                return NotFound();
            mapper.Map<UserResource, User>(userResource, toUpdate);
            
            await context.SaveChangesAsync();

            var resource = mapper.Map<User,UserResource>(toUpdate);

            return Ok(resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await context.Users.Include(u => u.Role).SingleOrDefaultAsync(p => p.Id == id);

            if(user == null)
                return NotFound();

            var resource = mapper.Map<User, UserResource>(user);

            return Ok(user);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user  = await context.Users.FindAsync(id);
            
            if(user == null) 
                return NotFound();

            context.Users.Remove(user);

            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}