using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_MiguelBetances.Models;

namespace Parcial1_AP1_MiguelBetances.Components.DAL
{
    public class Context : DbContext
    {
        public DbSet<Metas> Metas { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
