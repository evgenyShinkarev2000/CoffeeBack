namespace CoffeeBack.GraphQL.Schema
{
    public record UpdateVideoLectureInput(int Id, string Name, string Emded): IIdInput;
}
