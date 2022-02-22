using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementLRM_NET5
{
    public partial class Subject
    {
        public Subject()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int IdSubject { get; set; }
        public string DsSubject { get; set; }
        public int IdTeacher { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual Teacher IdTeacherNavigation { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
