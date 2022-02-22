using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementLRM_NET5
{
    public partial class StudentGrade
    {
        public int IdStudentRegistrationNumber { get; set; }
        public int IdSubject { get; set; }
        public decimal Grade { get; set; }
        public int IdStudentSubject { get; set; }

        public virtual Student IdStudentRegistrationNumberNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
