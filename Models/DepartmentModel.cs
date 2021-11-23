using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementAPI.Models
{
    public class DepartmentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string HeadOfDepartmentId { get; set; }
        public string CourseAdviserId { get; set; }
        public string FacultyId { get; set; }
        public string StudentId { get; set; }
    }
}