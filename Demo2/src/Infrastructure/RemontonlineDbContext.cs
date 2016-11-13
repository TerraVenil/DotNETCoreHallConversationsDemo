using Microsoft.EntityFrameworkCore;

namespace Demo2.Infrastructure
{
    public class RemontOnlineDbContext : DbContext
    {
        public RemontOnlineDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}