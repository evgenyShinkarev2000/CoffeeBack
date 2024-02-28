using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IRemoveTextLectureInputToData: IInputToDataMapper<RemoveTextLectureInput, TextLecture>;

    public class RemoveTextLectureInputToData : IRemoveTextLectureInputToData
    {
        private readonly IMapper mapper;

        public RemoveTextLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TextLecture Map(RemoveTextLectureInput input)
            => mapper.Map<TextLecture>(input);
    }
}
