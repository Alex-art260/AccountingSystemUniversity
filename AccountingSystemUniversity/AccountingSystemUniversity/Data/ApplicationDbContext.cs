using AccountingSystemUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystemUniversity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

       public  DbSet<Building> Buildings { get; set; }
    }
}
