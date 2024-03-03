using CoffeeBack.Authorization;
using CoffeeBack.Data.Models;
using CoffeeBack.Data.Repositories;
using CoffeeBack.Services;
using CoffeeBack.Services.Models;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.GraphQL
{
    public class Queries
    {
        [UseServiceScope]
        [UseProjection]
        public IQueryable<TextLecture> TextLectures([Service(ServiceKind.Resolver)] ITextLectureRepository textLectureRepository)
            => textLectureRepository.Untracked;

        [UseServiceScope]
        [UseProjection]
        public IQueryable<VideoLecture> VideoLectures([Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository)
            => videoLectureRepository.Untracked;

        [UseServiceScope]
        [UseFiltering]
        public async Task<IEnumerable<VideoLectureWithIsWatched>> VideoLecturesWithIsWatchedByCurrentPerson(
            [Service(ServiceKind.Resolver)] IVideoLectureService videoLectureService,
            [Service] ICurrentUserService currentUserService)
            => await videoLectureService.GetVideoLecturesWithIsWatchedByPerson(currentUserService.Id);

        [UseServiceScope]
        [UseProjection]
        public IQueryable<Person> People([Service(ServiceKind.Resolver)] IPersonRepository personRepository)
            => personRepository.Untracked;

        [UseServiceScope]
        public async Task<IEnumerable<string>> KnownRoles([Service] IUserService userService)
            => await userService.GetKnownRoles();

    }
}
