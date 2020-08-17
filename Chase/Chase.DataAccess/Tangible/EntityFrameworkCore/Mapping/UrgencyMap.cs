using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping
{
    public class UrgencyMap:IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).IsRequired();
            builder.Property(I => I.Definition).HasMaxLength(100);
        }
    }
}