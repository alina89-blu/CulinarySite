using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinarySite.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Telephone> Telephones { get; set; } = new List<Telephone>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        [ForeignKey("Address")]
        public int AddressId { get; set; }
       
        public Address Address { get; set; }
    }
}
