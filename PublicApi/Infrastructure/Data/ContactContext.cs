using Microsoft.EntityFrameworkCore;
using PublicApi.Entities;
using System.Reflection;

namespace PublicApi.Infrastructure.Data
{
    public class ContactContext: DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
