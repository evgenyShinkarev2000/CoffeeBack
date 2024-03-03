namespace CoffeeBack.GraphQL.Schema
{
    public record SetVideoLectureWatchedAdminInput(IdInput VideoLecture, IdInput Person, bool IsWatched);
}
