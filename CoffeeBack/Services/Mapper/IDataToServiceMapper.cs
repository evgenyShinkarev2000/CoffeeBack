namespace CoffeeBack.Services.Mapper
{
    public interface IDataToServiceMapper<Tin, Tout>
    {
        Tout Map(Tin data);
    }
}
