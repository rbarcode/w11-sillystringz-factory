using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Licensure> Licensures { get; set; }
    public DbSet<ActiveRepairs> ActiveRepairs { get; set; }
  }
}