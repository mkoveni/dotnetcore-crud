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

    }
}