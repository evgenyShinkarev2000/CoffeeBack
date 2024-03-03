using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IAddVideoLectureInputToData : IInputToDataMapper<AddVideoLectureInput, VideoLecture>;

    public class AddVideoLectureInputToData : IAddVideoLectureInputToData
    {
        private readonly IMapper mapper;

        public AddVideoLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public VideoLecture Map(AddVideoLectureInput input)
            => mapper.Map<VideoLecture>(input);
    }
}
