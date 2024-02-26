using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IUpdateTextLectureInputToData: IInputToDataMapper<UpdateTextLectureInput, TextLecture>;

    public class UpdateTextLectureInputToData : IUpdateTextLectureInputToData
    {
        private readonly IMapper mapper;

        public UpdateTextLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TextLecture Map(UpdateTextLectureInput input)
            => mapper.Map<TextLecture>(input);
    }
}
