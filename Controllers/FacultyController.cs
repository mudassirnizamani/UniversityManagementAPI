using Microsoft.AspNetCore.Mvc;
using UniversityManagementAPI.Interfaces;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _facultyService;

        public FacultyController(IFaculty facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        [Route("GetFaculties")]
        public ActionResult<IEnumerable<FacultyModel>> GetFaculties()
        {
            return Ok(_facultyService.GetFaculties());
        }

        [HttpGet]
        [Route("GetFaculty/{faculty_id}")]
        public ActionResult<FacultyModel> GetFaculty(string faculty_id)
        {
            return Ok(_facultyService.GetFacultyById(faculty_id));
        }

        [HttpPost]
        [Route("CreateFaculty")]
        public ActionResult CreateFaculty(FacultyViewModel model)
        {
            try
            {
                _facultyService.CreateFaculty(model);
                _facultyService.SaveChanges();
                return Ok(new { succeeded = true });
            }
            catch (Exception)
            {
                return BadRequest(new { code = "ServerError", error = "Something went wrong in the server" });
            }

        }

        [HttpGet]
        [Route("DeleteFaculty/{faculty_id}")]
        public ActionResult CreateFaculty(string faculty_id)
        {
            var Faculty = _facultyService.GetFacultyById(faculty_id);
            if (Faculty == null)
            {
                return BadRequest(new { code = "FacultyDontExist", error = "Faculty does not exists" });
            }
            else
            {
                _facultyService.DeleteFaculty(Faculty);
                _facultyService.SaveChanges();
                return Ok(new { succeeded = true });
            }
        }

        [HttpGet]
        [Route("GetFacultiesCount")]
        public ActionResult GetFacultiesCount()
        {
            IEnumerable<FacultyModel> faculties = _facultyService.GetFaculties();

            return Ok(faculties.Count());
        }
    }
}