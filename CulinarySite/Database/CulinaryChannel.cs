using System.Collections.Generic;

namespace Database
{
    public class CulinaryChannel : BaseEntity
    {
        public string Name { get; set; }

        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
