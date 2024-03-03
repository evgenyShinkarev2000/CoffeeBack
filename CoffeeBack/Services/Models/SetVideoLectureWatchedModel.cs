namespace CoffeeBack.Services.Models
{
    public record SetVideoLectureWatchedModel(int VideoLectureId, int PersonId, bool IsWatched);
}
