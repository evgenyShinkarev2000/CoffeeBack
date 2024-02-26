using HotChocolate.Types.Descriptors.Definitions;

namespace CoffeeBack.Data.Models
{
    public class TextLecture : Entity
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
