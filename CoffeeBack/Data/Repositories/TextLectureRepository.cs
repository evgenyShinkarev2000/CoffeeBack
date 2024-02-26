using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Data.Repositories
{
    public interface ITextLectureRepository: IRawQueryable<TextLecture>, ISave
    {
        public TextLecture Add(TextLecture textLecture);
        public TextLecture Update(TextLecture textLecture);
    }

    public class TextLectureRepository : ITextLectureRepository
    {
        public IQueryable<TextLecture> Raw => appDbContext.TextLectures.AsNoTracking();

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

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
