using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Restaurant : BaseEntity
    {       
        public string Name { get; set; }
        public List<Telephone> Telephones { get; set; } = new List<Telephone>();
        public List<Comment> Comments { get; set; } = new List<Comment>();       
        public int AddressId { get; set; }       
        public Address Address { get; set; }
    }
}
