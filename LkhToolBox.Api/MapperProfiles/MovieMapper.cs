using AutoMapper;
using LkhToolBox.Contracts.Movies.Requests;
using LkhToolBox.Contracts.Movies.Responses;
using LkhToolBox.Domain.Movies;
using System.Threading;

namespace LkhToolBox.Api.MapperProfiles
{
    public class MovieMapper:Profile
    {
        public MovieMapper()
        {
            CreateMap<CreateMovieRequest, Movie>();
            CreateMap<UpdateMovieRequest, Movie>();
            CreateMap<GetAllMoviesRequest, GetAllMoviesOptions>()
                .ForMember(option=>option.SortField,request=>request.MapFrom(src=>
               SortByStringToEnum(src.SortBy)))
                 .ForMember(option => option.SortOrder, request => request.MapFrom(src =>
               SortOrderStringToEnum(src.SortOrder)))
                 .ForMember(option=>option.YearOfRelease,request=>request.MapFrom(src=>
                 src.Year))
                ;

            CreateMap<Movie, MovieResponse>();
        }

        private SortField SortByStringToEnum(string? value)
        {
            if (value is null) return SortField.DefaultSort;
            //true表示忽略大小写
           var isSuccess =  Enum.TryParse(typeof(SortField), value, true,out var parseResult);

            return isSuccess ? (SortField)parseResult! : SortField.DefaultSort;
        }

        private SortOrder SortOrderStringToEnum(string? value)
        {
            if (value is null) return SortOrder.Unsorted;
            //true表示忽略大小写
            var isSuccess = Enum.TryParse(typeof(SortOrder), value, true, out var parseResult);

            return isSuccess ? (SortOrder)parseResult! : SortOrder.Unsorted;
        }
    }
}
