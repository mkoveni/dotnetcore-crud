using System.ComponentModel.DataAnnotations;

namespace example_app.Database.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}