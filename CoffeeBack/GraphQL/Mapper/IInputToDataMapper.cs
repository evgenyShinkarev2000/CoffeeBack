namespace _66BitTaskApi.GraphQL.Mappers
{
    public interface IInputToDataMapper<Tin, Tout>
    {
        public Tout Map(Tin input);
    }
}
