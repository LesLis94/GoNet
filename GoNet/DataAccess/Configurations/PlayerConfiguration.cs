using GoNet.BL.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoNet.DataAccess.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired();
        }
    }
}
