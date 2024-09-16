using AutoMapper;
using LkhToolBox.Domain.Movies;

namespace LkhToolBox.Api.MapperProfiles
{
    public class SortByStringToEnumTypeConverter : ITypeConverter<string, SortField>
    {
        public SortField Convert(string source, SortField destination, ResolutionContext context)
        {
            //true表示忽略大小写
            return (SortField)Enum.Parse(typeof(SortField), source, true);
        }


       
    }
}
