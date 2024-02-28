using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Data.Repositories
{
    public interface IVideoLectureRepository : IRawQueryable<VideoLecture>, ISave
    {
        public VideoLecture Add(VideoLecture videoLecture);
        public VideoLecture Update(VideoLecture videoLecture);
        public VideoLecture Remove(VideoLecture videoLecture);
    }

    public class VideoLectureRepository : IVideoLectureRepository
    {
        public IQueryable<VideoLecture> Raw => appDbContext.VideoLectures.AsNoTracking();

        private readonly AppDbContext appDbContext;

        public VideoLectureRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public VideoLecture Add(VideoLecture videoLecture)
        {
            return appDbContext.VideoLectures.Add(videoLecture).Entity;
        }

        public VideoLecture Update(VideoLecture videoLecture)
        {
            return appDbContext.VideoLectures.Update(videoLecture).Entity;
        }

        public VideoLecture Remove(VideoLecture videoLecture)
        {
            return appDbContext.VideoLectures.Remove(videoLecture).Entity;
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
