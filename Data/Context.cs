using Microsoft.EntityFrameworkCore;
using MinhaApi.Models;

namespace MinhaApi.Data
{
    public class Context : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}