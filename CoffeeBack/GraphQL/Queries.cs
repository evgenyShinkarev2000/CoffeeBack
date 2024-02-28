using CoffeeBack.Authorization;
using CoffeeBack.Data.Models;
using CoffeeBack.Data.Repositories;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace CoffeeBack.GraphQL
{
    public class Queries
    {
        [UseServiceScope]
        [UseProjection]
        //[Authorize(Policy ="RoleAtLeastIntern")]
        public IQueryable<TextLecture> TextLectures([Service(ServiceKind.Resolver)] ITextLectureRepository textLectureRepository)
            => textLectureRepository.Raw;

        [UseServiceScope]
        [UseProjection]
        public IQueryable<VideoLecture> VideoLectures([Service(ServiceKind.Resolver)] IVideoLectureRepository videoLectureRepository)
            => videoLectureRepository.Raw;

        [UseServiceScope]
        [UseProjection]
        public IQueryable<Person> People([Service(ServiceKind.Resolver)] IPersonRepository personRepository)
            => personRepository.Raw;

    }
}
