using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Webform.Models
{
    public class FormDbContext :DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {

        }

        public DbSet<FormModel> Task { get; set; }
    }
}
