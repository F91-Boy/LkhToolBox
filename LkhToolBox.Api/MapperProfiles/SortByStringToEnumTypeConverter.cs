using AutoMapper;
using LkhToolBox.Domain.Movies;

namespace LkhToolBox.Api.MapperProfiles
{
    public class SortByStringToEnumTypeConverter : ITypeConverter<string, SortFieldEnum>
    {
        public SortFieldEnum Convert(string source, SortFieldEnum destination, ResolutionContext context)
        {
            //true表示忽略大小写
            return (SortFieldEnum)Enum.Parse(typeof(SortFieldEnum), source, true);
        }


       
    }
}
