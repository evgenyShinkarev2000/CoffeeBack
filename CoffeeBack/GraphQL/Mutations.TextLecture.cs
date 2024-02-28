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
    }
}
