using AltitudeTasks.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AltitudeTasks.Infrastructure.Configuration
{
    public class InputConfiguration: IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            //FirstName
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            //LastName
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);
            //Telephone
            builder.Property(x => x.Telephone).IsRequired();
            builder.Property(x => x.Telephone).HasMaxLength(50);



        }
    }
}
