using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IAddTextLectureInputToData : IInputToDataMapper<AddTextLectureInput, TextLecture>;

    public class AddTextLectureInputToData : IAddTextLectureInputToData
    {
        private readonly IMapper mapper;

        public AddTextLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TextLecture Map(AddTextLectureInput input)
            => mapper.Map<TextLecture>(input);
    }
}
