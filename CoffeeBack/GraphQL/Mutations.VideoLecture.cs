using CoffeeBack.Data.Repositories;
using CoffeeBack.GraphQL.Schema;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate;
using System.Threading.Tasks;
using CoffeeBack.Data.Models;
using HotChocolate.Authorization;
using CoffeeBack.Authorization;
using CoffeeBack.Services;
using CoffeeBack.Services.Models;
using CoffeeBack.GraphQL.Mapper;

namespace CoffeeBack.GraphQL
{
    public partial class Mutations
    {
        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
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
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<VideoLecture> UpdateVideoLecture(
            [Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository,
            [Service] IUpdateVideoLectureInputToData updateVideoLectureInputToData,
            UpdateVideoLectureInput updateVideoLectureInput)
        {
            var videoLecture = updateVideoLectureInputToData.Map(updateVideoLectureInput);
            videoLectureRepository.Update(videoLecture);
            await videoLectureRepository.Save();

            return videoLecture;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<VideoLecture> RemoveVideoLecture(
            [Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository,
            [Service] IRemoveVideoLectureInputToData removeVideoLectureInputToData,
            RemoveVideoLectureInput removeVideoLectureInput)
        {
            var videoLecture = removeVideoLectureInputToData.Map(removeVideoLectureInput);
            videoLectureRepository.Remove(videoLecture);
            await videoLectureRepository.Save();

            return videoLecture;
        }

        [UseServiceScope]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Intern)]
        public async Task<VideoLectureWithIsWatched> SetVideoLectureWatched(
            [Service(ServiceKind.Resolver)] IVideoLectureService videoLectureService,
            [Service] ICurrentUserService currentUserService,
            SetVideoLectureWatchedInput setVideoLectureWatchedInput)
        {
            return await videoLectureService.SetVideoLectureWatched(
                setVideoLectureWatchedInput.VideoLecture.Id,
                currentUserService.Id,
                setVideoLectureWatchedInput.IsWatched);
        }

        [UseServiceScope]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<VideoLectureWithIsWatched> SetVideoLectureWatchedAdmin(
            [Service(ServiceKind.Resolver)] IVideoLectureService videoLectureService,
            SetVideoLectureWatchedAdminInput setVideoLectureWatchedAdminInput)
        {
            return await videoLectureService.SetVideoLectureWatched(
                setVideoLectureWatchedAdminInput.VideoLecture.Id,
                setVideoLectureWatchedAdminInput.Person.Id,
                setVideoLectureWatchedAdminInput.IsWatched);
        }
    }
}
