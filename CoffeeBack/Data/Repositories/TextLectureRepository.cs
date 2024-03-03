using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Data.Repositories
{
    public interface ITextLectureRepository: IUntrackedQueryable<TextLecture>, ITrackedQueryable<TextLecture>, ISave
    {
        public TextLecture Add(TextLecture textLecture);
        public TextLecture Update(TextLecture textLecture);
        public TextLecture Remove(TextLecture textLecture);
    }

    public class TextLectureRepository : ITextLectureRepository
    {
        public IQueryable<TextLecture> Untracked => appDbContext.TextLectures.AsNoTracking();

        public IQueryable<TextLecture> Tracked => appDbContext.TextLectures;

        private readonly AppDbContext appDbContext;

        public TextLectureRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public TextLecture Add(TextLecture textLecture)
        {
            return appDbContext.TextLectures.Add(textLecture).Entity;
        }

        public TextLecture Update(TextLecture textLecture)
        {
            return appDbContext.TextLectures.Update(textLecture).Entity;
        }

        public TextLecture Remove(TextLecture textLecture)
        {
            return appDbContext.TextLectures.Remove(textLecture).Entity;
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
