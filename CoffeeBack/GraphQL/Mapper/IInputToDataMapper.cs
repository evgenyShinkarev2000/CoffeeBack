namespace CoffeeBack.GraphQL.Mapper
{
    public interface IInputToDataMapper<Tin, Tout>
    {
        public Tout Map(Tin input);
    }
}
