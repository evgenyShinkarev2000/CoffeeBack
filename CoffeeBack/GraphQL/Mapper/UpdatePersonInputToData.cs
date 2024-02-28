using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IUpdatePersonInputToData: IInputToDataMapper<UpdatePersonInput, Person>;
    public class UpdatePersonInputToData : IUpdatePersonInputToData
    {
        private readonly IMapper mapper;

        public UpdatePersonInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Person Map(UpdatePersonInput input)
            => mapper.Map<Person>(input);
    }
}
