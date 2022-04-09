using System.ComponentModel;
using Grpc.Core;

namespace GrpcService.Services
{
    public class MovieService : Movies.MoviesBase
    {
        private readonly IMovieDbService _movieDbService;

        public MovieService(IMovieDbService movieDbService)
        {
            _movieDbService = movieDbService;
        }

        public override Task<MovieInfoReply> GetInfo(MovieInfoRequest request, ServerCallContext context)
        {
            MovieInfoReply movieInfoReply;
            switch (request.CriteriaCase)
            {
                case MovieInfoRequest.CriteriaOneofCase.Id:
                    movieInfoReply = _movieDbService.GetMovieInfo(request.Id);
                    break;
                case MovieInfoRequest.CriteriaOneofCase.Name:
                    movieInfoReply = _movieDbService.GetMovieInfo(request.Name);
                    break;
                default:
                    var invalidEnum = request.CriteriaCase;
                    throw new InvalidEnumArgumentException(
                        argumentName: nameof(invalidEnum),
                        invalidValue: (int)invalidEnum, 
                        enumClass: invalidEnum.GetType());
            }

            return Task.FromResult(movieInfoReply);
        }

        public override Task<MovieInfoListReply> GetGenreInfoList(MovieInfoListRequest request, ServerCallContext context)
        {
            var movieInfoList = _movieDbService.GetMovieInfoList(request.Genre);
            return Task.FromResult(new MovieInfoListReply()
            {
                MoviesList = { movieInfoList }
            });
        } 
    }
}
