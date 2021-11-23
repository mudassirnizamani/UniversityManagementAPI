using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Interfaces
{
    public interface IDepartment
    {
        bool SaveChanges();
        IEnumerable<DepartmentModel> GetDepartments();

        DepartmentModel GetDepartmentById(string id);

        void CreateDepartment(DepartmentViewModel model);

        void DeleteDepartment(DepartmentModel model);
    }
}