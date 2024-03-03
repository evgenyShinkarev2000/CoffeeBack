using System.Collections.Generic;

namespace CoffeeBack.Data.Models
{
    public class Document : Entity<Document>
    {
        public DocumentKind DocumentKind { get; set; }
        public string ExternalId { get; set; }
        public List<Person> People { get; set; } = [];
    }
}
