namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(f => f.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}