using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Subscriber : BaseEntity
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
