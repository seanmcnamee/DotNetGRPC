using AutoMapper;
using GrpcService.Services;

namespace GrpcService.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDbService.MovieDto, MovieInfoReply>();
        }
    }
}
