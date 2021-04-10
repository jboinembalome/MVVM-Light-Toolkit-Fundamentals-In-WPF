using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicApi.Entities;

namespace PublicApi.Infrastructure.Data.Config
{
    public class FriendConfiguration
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(ci => ci.FirstName)
               .IsRequired();

            builder.Property(ci => ci.LastName)
               .IsRequired();

            builder.Property(ci => ci.Birthday)
            .IsRequired();

            builder.Property(ci => ci.Link)
           .IsRequired(false);

            builder.Property(ci => ci.Picture)
           .IsRequired(false);

            builder.Property(ci => ci.Location)
           .IsRequired(false);

            builder.Property(ci => ci.Message)
           .IsRequired(false);
        }
    }
}
