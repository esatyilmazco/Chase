using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping
{
    public class DeclarationMap : IEntityTypeConfiguration<Declaration>
    {
        public void Configure(EntityTypeBuilder<Declaration> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Explanation).HasColumnType("ntext").IsRequired();
            builder.HasOne(I => I.AppUser).WithMany(I => I.Declarations).HasForeignKey(I => I.AppUserId);
            
        }
    }
}