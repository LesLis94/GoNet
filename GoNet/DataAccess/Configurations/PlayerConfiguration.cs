using GoNet.BL.Services.Abstract;
using GoNet.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoNet.DataAccess.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired();
            builder
                .HasMany(p => p.Things);
                //.WithOne(t => t.Player)
               // .HasForeignKey(t => t.IdPlayer);
        }
    }

  
}
