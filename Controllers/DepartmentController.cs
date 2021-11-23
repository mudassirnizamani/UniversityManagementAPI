using Microsoft.AspNetCore.Mvc;
using UniversityManagementAPI.Interfaces;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public ActionResult GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [HttpGet]
        [Route("GetDepartment/{department_id}")]
        public ActionResult GetDepartment(string department_id)
        {
            if (department_id is null)
            {
                return BadRequest(new { succeeded = false, code = "NullError", error = "Department id is null" });
            }
            return Ok(_departmentService.GetDepartmentById(department_id));
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public ActionResult CreateDepartment(DepartmentViewModel model)
        {
            if (model is null)
            {
                return BadRequest(new { succeeded = false, code = "NullError", error = "Department is null" });
            }
            _departmentService.CreateDepartment(model);
            _departmentService.SaveChanges();
            return Ok(new { succeeded = true });
        }

        [HttpGet]
        [Route("DeleteDepartment/{department_id}")]
        public ActionResult DeleteDepartment(string department_id)
        {
            if (department_id is null)
            {
                return BadRequest(new { succeeded = false, code = "NullError", error = "Department id is null" });
            }
            var department = _departmentService.GetDepartmentById(department_id);
            _departmentService.DeleteDepartment(department);
            _departmentService.SaveChanges();
            return Ok(new { succeeded = true });
        }

        [HttpGet]
        [Route("GetDepartmentsCount")]
        public ActionResult GetDepartmentsCount()
        {
            IEnumerable<DepartmentModel> departments = _departmentService.GetDepartments();
            return Ok(departments.Count());
        }
    }
}