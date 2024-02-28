namespace CoffeeBack.GraphQL.Schema
{
    public record UpdatePersonInput(int Id, string Name, string Surname, string Patronymic): IIdInput;
}
