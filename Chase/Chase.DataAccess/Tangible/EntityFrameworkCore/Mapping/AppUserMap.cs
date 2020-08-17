using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.SurName).HasMaxLength(100);

            builder.HasMany(I => I.Duties).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}