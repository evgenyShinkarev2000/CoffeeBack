using CoffeeBack.Data.Repositories;
using CoffeeBack.GraphQL.Schema;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate;
using System.Threading.Tasks;
using CoffeeBack.Data.Models;
using CoffeeBack.Authorization;
using HotChocolate.Authorization;
using CoffeeBack.GraphQL.Mapper;
using CoffeeBack.Services.Models;
using CoffeeBack.Services;

namespace CoffeeBack.GraphQL
{
    public partial class Mutations
    {
        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<TextLecture> AddTextLecture(
            [Service(ServiceKind.Resolver)] ITextLectureRepository textLectureRepository,
            [Service] IAddTextLectureInputToData addTextLectureInputToData,
            AddTextLectureInput addTextLectureInput)
        {
            var textLecture = addTextLectureInputToData.Map(addTextLectureInput);
            textLectureRepository.Add(textLecture);
            await textLectureRepository.Save();

            return textLecture;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<TextLecture> UpdateTextLecture(
            [Service(ServiceKind.Resolver)] ITextLectureRepository textLectureRepository,
            [Service] IUpdateTextLectureInputToData updateTextLectureInputToData,
            UpdateTextLectureInput updateTextLectureInput)
        {
            var textLecture = updateTextLectureInputToData.Map(updateTextLectureInput);
            textLectureRepository.Update(textLecture);
            await textLectureRepository.Save();

            return textLecture;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.HRManager)]
        public async Task<TextLecture> RemoveTextLecture(
            [Service(ServiceKind.Resolver)] ITextLectureRepository textLectureRepository,
            [Service] IRemoveTextLectureInputToData removeTextLectureInputToData,
            RemoveTextLectureInput removeTextLectureInput)
        {
            var textLecture = removeTextLectureInputToData.Map(removeTextLectureInput);
            textLectureRepository.Remove(textLecture);
            await textLectureRepository.Save();

            return textLecture;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Intern)]
        public async Task<TextLectureWithIsRead> SetTextLectureRead(
            [Service(ServiceKind.Resolver)] ITextLectureService textLectureService,
            [Service] ICurrentUserService currentUserService,
            SetTextLectureReadInput setTextLectureReadInput)
        {
            return await textLectureService.SetVideoLectureWatched(
                setTextLectureReadInput.TextLecture.Id,
                currentUserService.Id,
                setTextLectureReadInput.IsWatched);
        }
    }
}
