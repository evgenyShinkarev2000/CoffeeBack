using CoffeeBack.Data.Repositories;
using CoffeeBack.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoffeeBack.Services
{
    public interface ITextLectureService
    {
        Task<IEnumerable<TextLectureWithIsRead>> GetTextLecturesWithIsReadByPerson(int personId);
        Task<TextLectureWithIsRead> SetTextLectureRead(int textLectureId, int personId, bool isRead);
    }

    public class TextLectureService : ITextLectureService
    {
        private readonly ITextLectureRepository textLectureRepository;
        private readonly IPersonRepository personRepository;

        public TextLectureService(
            ITextLectureRepository videoLectureRepository,
            IPersonRepository personRepository)
        {
            this.textLectureRepository = videoLectureRepository;
            this.personRepository = personRepository;
        }

        public async Task<TextLectureWithIsRead> SetTextLectureRead(int textLectureId, int personId, bool isRead)
        {
            var textLecture = await textLectureRepository.Tracked
                .Include(tl => tl.LearnedPeople)
                .FirstOrDefaultAsync(tl => tl.Id == textLectureId);
            if (textLecture == null)
            {
                throw new Exception("Can't find text lecture");
            }

            var currentUser = await personRepository.Untracked.FirstOrDefaultAsync(p => p.Id == personId);

            if (currentUser == null)
            {
                throw new Exception("Can't find user");
            }
            if (isRead)
            {
                textLecture.LearnedPeople.Add(currentUser);
            }
            else
            {
                textLecture.LearnedPeople.Remove(currentUser);
            }

            textLectureRepository.Update(textLecture);
            await textLectureRepository.Save();

            return new TextLectureWithIsRead(textLecture.Id, textLecture.Name, textLecture.Content, isRead);
        }

        public async Task<IEnumerable<TextLectureWithIsRead>> GetTextLecturesWithIsReadByPerson(int personId)
        {
            return await textLectureRepository.Untracked
                .Include(vl => vl.LearnedPeople)
                .Select(vl => new TextLectureWithIsRead(vl.Id, vl.Name, vl.Content, vl.LearnedPeople.Any(lp => lp.Id == personId)))
                .ToArrayAsync();
        }
    }
}
