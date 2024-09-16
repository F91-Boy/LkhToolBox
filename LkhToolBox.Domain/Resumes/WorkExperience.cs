using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Domain.Resumes
{
    public class WorkExperience
    {
        public int Id { get; private set; }

        public string Title { get; private set; } =default!;

        public string Description { get; private set; } = default!;

        public string Company { get; private set; } = default!;

        public string Job { get; private set; } = default!;

        public DateOnly StartTime { get; private set; }

        public DateOnly StopTime { get; private set; }


        public WorkExperience()
        {
                
        }
    }
}
