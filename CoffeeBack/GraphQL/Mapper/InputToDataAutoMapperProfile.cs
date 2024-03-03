using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace CoffeeBack.GraphQL.Mapper
{
    public class InputToDataAutoMapperProfile : Profile
    {
        public InputToDataAutoMapperProfile()
        {
            CreateMap<IIdInput, TextLecture>();
            CreateMap<AddTextLectureInput, TextLecture>();
            CreateMap<UpdateTextLectureInput, TextLecture>();

            CreateMap<IIdInput, VideoLecture>();
            CreateMap<AddVideoLectureInput, VideoLecture>();
            CreateMap<UpdateVideoLectureInput, VideoLecture>();

            CreateMap<IIdInput, Person>();
            CreateMap<AddPersonInput, Person>();
            CreateMap<UpdatePersonInput, Person>();
        }
    }
}
