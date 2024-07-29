using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Entities
{
    internal class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public String Surname { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
