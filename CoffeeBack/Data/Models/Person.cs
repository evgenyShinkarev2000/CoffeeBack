using System.Collections.Generic;

namespace CoffeeBack.Data.Models
{
    public class Person : Entity<Person>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<Document> Documents { get; set; } = [];
        public List<TextLecture> CompleatedTextLectures { get; set; } = [];
        public List<VideoLecture> CompleatedVideoLectures { get; set; } = [];
    }
}
