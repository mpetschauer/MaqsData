using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaqsData.Models.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        void IEntityTypeConfiguration<Document>.Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Gkey).HasDefaultValueSql("(newid())");
        }
    }
}
