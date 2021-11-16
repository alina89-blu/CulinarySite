using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Subscriber : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
