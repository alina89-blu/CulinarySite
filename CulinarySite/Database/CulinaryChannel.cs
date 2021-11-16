using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CulinaryChannel : BaseEntity
    {
        public string Name { get; set; }

        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
