using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_WindowsForm_LINQ
{
    class Species
    {
        public Guid SpeciesId { get; set; }
        public String Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
