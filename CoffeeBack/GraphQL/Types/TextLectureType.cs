using CoffeeBack.Authorization;
using CoffeeBack.Data.Models;
using HotChocolate.Types;

namespace CoffeeBack.GraphQL.Types
{
    public class TextLectureType: ObjectType<TextLecture>
    {
        protected override void Configure(IObjectTypeDescriptor<TextLecture> descriptor)
        {
            descriptor.Field(f => f.LearnedPeople).Authorize(KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Manager);

            base.Configure(descriptor);
        }
    }
}
