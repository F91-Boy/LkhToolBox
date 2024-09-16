using AutoMapper;
using LkhToolBox.Contracts.Movies.Requests;
using LkhToolBox.Contracts.Movies.Responses;
using LkhToolBox.Domain.Movies;

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

        private SortFieldEnum SortByStringToEnum(string? value)
        {
            if (value is null) return SortFieldEnum.DefaultSort;
            //true表示忽略大小写
           var isSuccess =  Enum.TryParse(typeof(SortFieldEnum), value, true,out var parseResult);

            return isSuccess ? (SortFieldEnum)parseResult! : SortFieldEnum.DefaultSort;
        }

        private SortOrderEnum SortOrderStringToEnum(string? value)
        {
            if (value is null) return SortOrderEnum.Unsorted;
            //true表示忽略大小写
            var isSuccess = Enum.TryParse(typeof(SortOrderEnum), value, true, out var parseResult);

            return isSuccess ? (SortOrderEnum)parseResult! : SortOrderEnum.Unsorted;
        }
    }
}
