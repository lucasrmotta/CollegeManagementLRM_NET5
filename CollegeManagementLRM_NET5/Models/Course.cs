using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementLRM_NET5
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public int IdCourse { get; set; }
        public string DsCourse { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
