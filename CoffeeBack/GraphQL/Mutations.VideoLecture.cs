using CoffeeBack.Data.Repositories;
using CoffeeBack.GraphQL.Mapper;
using CoffeeBack.GraphQL.Schema;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate;
using System.Threading.Tasks;
using CoffeeBack.Data.Models;

namespace CoffeeBack.GraphQL
{
    public partial class Mutations
    {
        [UseServiceScope]
        [UseProjection]
        public async Task<VideoLecture> AddVideoLecture(
            [Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository,
            [Service] IAddVideoLectureInputToData addVideoLectureInputToData,
            AddVideoLectureInput addVideoLectureInput)
        {
            var videoLecture = addVideoLectureInputToData.Map(addVideoLectureInput);
            videoLectureRepository.Add(videoLecture);
            await videoLectureRepository.Save();

            return videoLecture;
        }

        [UseServiceScope]
        [UseProjection]
        public async Task<VideoLecture> UpdateVideoLecture(
            [Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository,
            [Service] IUpdateVideoLectureInputToData updateVideoLectureInputToData,
            UpdateVideoLectureInput updateVideoLectureInput)
        {
            var videoLecture = updateVideoLectureInputToData.Map(updateVideoLectureInput);
            videoLectureRepository.Add(videoLecture);
            await videoLectureRepository.Save();

            return videoLecture;
        }
    }
}
