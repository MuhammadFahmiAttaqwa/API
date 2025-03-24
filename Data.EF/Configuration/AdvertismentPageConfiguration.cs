using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Configuration
{
    public class AdvertismentPageConfiguration : IEntityTypeConfiguration<AdvertistmentPage>
    {
        public void Configure(EntityTypeBuilder<AdvertistmentPage> builder)
        {
            builder.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}
