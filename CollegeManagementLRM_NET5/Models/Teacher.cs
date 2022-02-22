using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementLRM_NET5
{
    public partial class Teacher
    {
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }

        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
