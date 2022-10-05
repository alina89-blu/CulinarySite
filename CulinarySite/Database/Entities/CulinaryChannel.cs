using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class CulinaryChannel : BaseEntity
    {  
        public string Name { get; set; }      
        public string Content { get; set; }
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
