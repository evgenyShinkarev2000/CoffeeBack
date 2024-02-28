using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IRemovePersonInputToData : IInputToDataMapper<RemovePersonInput, Person>;

    public class RemovePersonInputToData : IRemovePersonInputToData
    {
        private readonly IMapper mapper;

        public RemovePersonInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Person Map(RemovePersonInput input)
            => mapper.Map<Person>(input);
    }
}
