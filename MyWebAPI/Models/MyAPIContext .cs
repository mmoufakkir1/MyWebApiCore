using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Models
{
    public class MyAPIContext : DbContext
    {
        public MyAPIContext(DbContextOptions<MyAPIContext> options)
            :base (options)
        {

        }
        public DbSet<MyAPIitem> MyAPIitems { get; set; }
    }
}
