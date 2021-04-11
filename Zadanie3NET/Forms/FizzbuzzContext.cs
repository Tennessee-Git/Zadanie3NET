using Microsoft.EntityFrameworkCore;

namespace Zadanie3NET.Forms
{
    public class FizzbuzzContext : DbContext
    {
        public FizzbuzzContext(DbContextOptions options) : base(options) 
        { }
        public DbSet<Fizzbuzz> Fizzbuzzes { get; set; }
    }
}
