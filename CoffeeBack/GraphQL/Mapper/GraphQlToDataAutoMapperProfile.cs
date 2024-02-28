using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace _66BitTaskApi.GraphQL.Mappers
{
    public class GraphQlToDataAutoMapperProfile : Profile
    {
        public GraphQlToDataAutoMapperProfile()
        {
            CreateMap<IIdInput, TextLecture>();
            CreateMap<AddTextLectureInput, TextLecture>();
            CreateMap<UpdateTextLectureInput, TextLecture>();

            CreateMap<IIdInput, VideoLecture>();
            CreateMap<AddVideoLectureInput, VideoLecture>();
            CreateMap<UpdateVideoLectureInput, VideoLecture>();
        }
    }
}
