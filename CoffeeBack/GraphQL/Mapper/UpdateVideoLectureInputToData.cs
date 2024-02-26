using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IUpdateVideoLectureInputToData : IInputToDataMapper<UpdateVideoLectureInput, VideoLecture>;

    public class UpdateVideoLectureInputToData : IUpdateVideoLectureInputToData
    {
        private readonly IMapper mapper;

        public UpdateVideoLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public VideoLecture Map(UpdateVideoLectureInput input)
            => mapper.Map<VideoLecture>(input);
    }
}
