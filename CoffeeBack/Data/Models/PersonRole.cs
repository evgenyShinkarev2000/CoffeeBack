using System;

namespace CoffeeBack.Data.Models
{
    [Obsolete]
    public class PersonRole: Entity<PersonRole>
    {
        public string Name { get; set; }
        public Person Person { get; set; }
        public int AccessLevel { get; set; }
    }
}
