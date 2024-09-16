using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Domain.Resumes
{
    public class Skill
    {
        public int Id { get; private set; }

        public string Title { get;   set; } = default!;

        public string Description { get; set; } = default!;
    }
}
