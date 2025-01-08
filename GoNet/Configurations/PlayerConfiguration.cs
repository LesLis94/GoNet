using GoNet.BL.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoNet.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Players>
    {
        public void Configure(EntityTypeBuilder<Players> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
