using api.Models;
using Microsoft.EnityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Funcionarios> funcionarios {get; set;}
        public DbSet<Equipes> equipes {get; set;}
    }
}
#pragma warning restore format