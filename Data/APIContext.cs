using Microsoft.EntityFrameworkCore;
using UniversityManagementAPI.Models;

namespace UniversityManagementAPI.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<FacultyModel> Faculties { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }
    }
}