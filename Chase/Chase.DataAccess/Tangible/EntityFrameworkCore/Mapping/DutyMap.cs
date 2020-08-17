using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping
{
    public class DutyMap : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Urgency).WithMany(I => I.Duties).HasForeignKey(I => I.UrgencyId);
        }
    }
}