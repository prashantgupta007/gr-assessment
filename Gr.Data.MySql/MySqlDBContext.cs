using Microsoft.EntityFrameworkCore;
using Gr.Data.Entities;

namespace Gr.Data.MySql
{
    public class MySqlDBContext : DbContext
    {
        public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL("server=localhost;database=products;user=user;password=password");

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
