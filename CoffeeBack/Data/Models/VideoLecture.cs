using System.Collections.Generic;

namespace CoffeeBack.Data.Models
{
    public class VideoLecture : Entity
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public List<Person> LearnedPeople { get; set; } = [];

    }
}
