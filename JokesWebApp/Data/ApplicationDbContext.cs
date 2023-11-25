using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace JokesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JokesWebApp.Models.Joke> Joke { get; set; } = default!;
        public DbSet<JokesWebApp.Models.Song> Song { get; set; } = default!;
        public DbSet<Microsoft.AspNetCore.Identity.IdentityRole> Role { get; set; } = default!;
        public DbSet<JokesWebApp.Models.Profile> Profile { get; set; } = default!;
        public DbSet<JokesWebApp.Models.Cafe> Cafe { get; set; } = default!;
        public DbSet<JokesWebApp.Models.Сourses> Courses { get; set; } = default!;


    }
}