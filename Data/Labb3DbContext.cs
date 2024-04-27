using Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3.Data
{
    public class Labb3DbContext : DbContext
    {
        public Labb3DbContext(DbContextOptions<Labb3DbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<InterestList> InterestLists { get; set; }
}
}
