using GoNet.BL.Services.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoNet.DataAccess.Configurations
{
    public class ThingPlayerConfiguration : IEntityTypeConfiguration<ThingPlayerEntity>
    {
        public void Configure(EntityTypeBuilder<ThingPlayerEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired();
            //builder
              //  .HasOne(t => t.Player)
               // .WithMany(p => p.Things)
               // .HasForeignKey(t => t.IdPlayer);
        }
    }
}