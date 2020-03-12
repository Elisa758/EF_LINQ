using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_WindowsForm_LINQ
{
    class Animal
    {
        public Guid AnimalId { get; set; }
        public String Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
    }
}
