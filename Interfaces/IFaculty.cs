using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Interfaces
{
    public interface IFaculty
    {
        IEnumerable<FacultyModel> GetFaculties();

        FacultyModel GetFacultyById(string id);

        void CreateFaculty(FacultyViewModel model);

        bool SaveChanges();

        void DeleteFaculty(FacultyModel model);
    }
}