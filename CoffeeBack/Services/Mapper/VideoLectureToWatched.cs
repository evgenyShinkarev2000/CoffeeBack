using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.Services.Models;

namespace CoffeeBack.Services.Mapper
{
    public interface IVideoLectureToWatched: IDataToServiceMapper<VideoLecture, VideoLectureWithIsWatched>;

    public class VideoLectureToWatched : IVideoLectureToWatched
    {
        private readonly IMapper mapper;

        public VideoLectureToWatched(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public VideoLectureWithIsWatched Map(VideoLecture data)
            => mapper.Map<VideoLectureWithIsWatched>(data);
    }
}
