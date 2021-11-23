using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityManagementAPI.Models;

namespace UniversityManagementAPI.Context;
public class AuthContext : IdentityDbContext
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }
}