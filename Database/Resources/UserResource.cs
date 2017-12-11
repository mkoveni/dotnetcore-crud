using System.ComponentModel.DataAnnotations;
using example_app.Database.Models;

namespace example_app.Database.Resources
{
    public class UserResource
    {
        public int Id { get; set; } 

       [Required]
       [StringLength(255)]
       public string Name { get; set; }

       [Required]    
       [StringLength(255)]
       public string Email { get; set; }

       [Required]
       [StringLength(255)]
       public string Password { get; set; }
       
       public int RoleId { get; set; }
       public Role Role { get; set; }
    }
}