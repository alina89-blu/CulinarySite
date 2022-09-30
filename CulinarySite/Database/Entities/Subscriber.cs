using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Subscriber : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
