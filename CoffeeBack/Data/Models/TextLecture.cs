using HotChocolate.Types.Descriptors.Definitions;
using System.Collections.Generic;

namespace CoffeeBack.Data.Models
{
    public class TextLecture : Entity<TextLecture>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public List<Person> LearnedPeople { get; set; } = [];
    }
}
