using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Domain.Resumes
{
    public class ResumeInfo
    {
        public int UserId { get; private set; }

        public string Name { get; private set; } = default!;

        public Gender Gender { get; private set; }

        public DateTime Birthday { get; private set; }

        /// <summary>
        /// 现居城市
        /// </summary>
        public string City { get; private set; } = default!;

        public string Mail { get; private set; } = default!;

        public string Phone { get; private set; } = default!;

        public string SchoolName { get; private set; }

        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// 毕业时间
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; private set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Degree { get; private set; }

        public List<Skill> Skills   { get; private set; }

        public ResumeInfo(int userId, string name,Gender gender, string mail,
            string city, string phone, School school, string major, DateTime startDate,
            DateTime endDate, List<Skill> skills)
        {
            UserId = userId;
            Name = name;
            Gender = gender;
            City = city;
            Mail = mail;
            Phone = phone;
            SchoolName = school.SchoolName;
            Major = major;
            Degree = school.Level;
            StartDate = startDate;
            EndDate = endDate;
            Skills = skills;
        }


    }
}
