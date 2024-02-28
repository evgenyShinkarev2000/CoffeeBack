using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IAddPersonInputToData: IInputToDataMapper<AddPersonInput, Person>;

    public class AddPersonInputToData : IAddPersonInputToData
    {
        private readonly IMapper mapper;

        public AddPersonInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Person Map(AddPersonInput input)
            => mapper.Map<Person>(input);
    }
}
