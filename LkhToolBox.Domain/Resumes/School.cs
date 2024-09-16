using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Domain.Resumes
{
    public record School(
        int Id,
        string SchoolId,
        string SchoolName,
        string ProvinceId,
        string ProvinceName,
        string CityId,
        string CityName,
        string Level,
        string Department,
        string Other
        );
   
}
