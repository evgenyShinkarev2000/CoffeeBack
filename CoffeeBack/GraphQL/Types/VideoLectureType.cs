using CoffeeBack.Authorization;
using CoffeeBack.Data.Models;
using HotChocolate.Types;

namespace CoffeeBack.GraphQL.Types
{
    public class VideoLectureType: ObjectType<VideoLecture>
    {
        protected override void Configure(IObjectTypeDescriptor<VideoLecture> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}
