using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaqsData.Models.Configurations
{
    public class TotalConfiguration : IEntityTypeConfiguration<Total>
    {
        void IEntityTypeConfiguration<Total>.Configure(EntityTypeBuilder<Total> builder)
        {
            builder.ToTable("Totals");
            builder.HasKey(x => x.Id);
        }
    }
}