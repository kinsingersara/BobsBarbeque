using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FinalProject_skinsinger.Data.Models.Contact>? Contact { get; set; }
        public DbSet<FinalProject_skinsinger.Data.Models.Newsletter>? Newsletter { get; set; }
        public DbSet<FinalProject_skinsinger.Data.Models.Entree>? Entree { get; set; }
        public DbSet<FinalProject_skinsinger.Data.Models.side>? side { get; set; }
        public DbSet<FinalProject_skinsinger.Data.Models.Dessert>? Dessert { get; set; }
        public DbSet<FinalProject_skinsinger.Data.Models.Sauce>? Sauce { get; set; }
    }
}