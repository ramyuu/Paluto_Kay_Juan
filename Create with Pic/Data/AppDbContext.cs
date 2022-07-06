using Microsoft.EntityFrameworkCore;
using Paluto_Kay_Juan.Models;

namespace Paluto_Kay_Juan.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public virtual DbSet<AdminModel> Menus { get; set; }
    }
}
