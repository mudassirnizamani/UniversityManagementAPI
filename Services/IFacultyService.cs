using UniversityManagementAPI.Context;
using UniversityManagementAPI.Interfaces;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Services;
public class IFacultyService : IFaculty
{
    private readonly APIContext _apiContext;

    public IFacultyService(APIContext apiContext)
    {
        _apiContext = apiContext;
    }
    public void CreateFaculty(FacultyViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        var faculty = new FacultyModel
        {
            DeanId = model.DeanId,
            Name = model.Name
        };

        _apiContext.Faculties.Add(faculty);
    }

    public void DeleteFaculty(FacultyModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _apiContext.Faculties.Remove(model);
    }

    public IEnumerable<FacultyModel> GetFaculties()
    {
        return _apiContext.Faculties.ToList();
    }

    public FacultyModel GetFacultyById(string id)
    {
        return _apiContext.Faculties.FirstOrDefault(x => x.Id == id);
    }

    public bool SaveChanges()
    {
        return (_apiContext.SaveChanges() >= 0);
    }
}