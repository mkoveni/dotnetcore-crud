using System.ComponentModel.DataAnnotations;

namespace example_app.Database.Resources
{
    public class RoleResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}