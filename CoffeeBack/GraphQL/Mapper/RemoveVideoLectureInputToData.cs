using _66BitTaskApi.GraphQL.Mappers;
using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public interface IRemoveVideoLectureInputToData: IInputToDataMapper<RemoveVideoLectureInput, VideoLecture>;

    public class RemoveVideoLectureInputToData: IRemoveVideoLectureInputToData
    {
        private readonly IMapper mapper;

        public RemoveVideoLectureInputToData(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public VideoLecture Map(RemoveVideoLectureInput input)
            => mapper.Map<VideoLecture>(input);
    }
}
