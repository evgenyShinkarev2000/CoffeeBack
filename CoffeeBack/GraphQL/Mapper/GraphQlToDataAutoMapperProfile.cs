using AutoMapper;
using CoffeeBack.Data.Models;
using CoffeeBack.GraphQL.Schema;

namespace _66BitTaskApi.GraphQL.Mappers
{
    public class GraphQlToDataAutoMapperProfile : Profile
    {
        public GraphQlToDataAutoMapperProfile()
        {
            CreateMap<IdInput, TextLecture>();
            CreateMap<AddTextLectureInput, TextLecture>();
            CreateMap<UpdateTextLectureInput, TextLecture>();

            CreateMap<IdInput, VideoLecture>();
            CreateMap<AddVideoLectureInput, VideoLecture>();
            CreateMap<UpdateVideoLectureInput, VideoLecture>();
        }
    }
}
