using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using example_app.Database.EF;
using example_app.Database.Models;
using example_app.Database.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace example_app.Controllers {
    [Route ("/roles")]
    public class RolesController : Controller {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public RolesController (AppDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<RoleResource>> GetRoles () {
            var roles = await context.Roles.ToListAsync ();

            return mapper.Map<List<Role>, List<RoleResource>>(roles);
        }
    }
}