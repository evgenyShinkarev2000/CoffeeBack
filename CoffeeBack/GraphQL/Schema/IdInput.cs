namespace CoffeeBack.GraphQL.Schema
{
    interface IIdInput
    {
        int Id { get; }
    }
    public record IdInput(int Id) : IIdInput;
}
