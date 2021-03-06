using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialAndSpecialEquipmentAssignmentFormatConfiguration : IEntityTypeConfiguration<
            WarMaterialAndSpecialEquipmentAssignmentFormat>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormat> builder)
        {
            builder.Property(f => f.FlightCode).HasMaxLength(50);
        }
    }
}
