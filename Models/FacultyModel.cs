using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementAPI.Models
{
    public class FacultyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DeanId { get; set; }
    }
}