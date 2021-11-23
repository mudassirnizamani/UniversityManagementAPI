using UniversityManagementAPI.Context;
using UniversityManagementAPI.Interfaces;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Services
{
    public class IDepartmentService : IDepartment
    {
        private readonly APIContext _apiContext;

        public IDepartmentService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void CreateDepartment(DepartmentViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var department = new DepartmentModel
            {
                CourseAdviserId = model.CourseAdviserId,
                HeadOfDepartmentId = model.HeadOfDepartmentId,
                Name = model.Name,
                FacultyId = model.FacultyId,
                StudentId = model.StudentId,
            };

            _apiContext.Departments.Add(department);
        }

        public void DeleteDepartment(DepartmentModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _apiContext.Departments.Remove(model);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return _apiContext.Departments.ToList();
        }

        public DepartmentModel GetDepartmentById(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _apiContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_apiContext.SaveChanges() >= 0);
        }
    }
}