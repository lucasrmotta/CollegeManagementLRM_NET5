using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementLRM_NET5
{
    public partial class Student
    {
        public Student()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int IdStudentRegistrationNumber { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
