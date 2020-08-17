using Chase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping
{
    public class ReportMap:IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(I => I.ReportId);
            builder.Property(I => I.ReportId).UseIdentityColumn();
            builder.Property(I => I.ReportDefinition).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ReportDetail).HasColumnType("ntext");


            builder.HasOne(I => I.Duty).WithMany(I => I.Reports).HasForeignKey(I => I.DutyId);
        }
    }
}