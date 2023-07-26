using APIdemo.Models;
using Microsoft.EntityFrameworkCore;
namespace APIdemo.Data

{
    public class ApiContext : DbContext
    {
        public DbSet<Products> products { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
