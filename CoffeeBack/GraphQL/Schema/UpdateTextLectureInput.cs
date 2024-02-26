namespace CoffeeBack.GraphQL.Schema
{
    public record UpdateTextLectureInput(int Id, string Name, string Content) : IIdInput;
}
