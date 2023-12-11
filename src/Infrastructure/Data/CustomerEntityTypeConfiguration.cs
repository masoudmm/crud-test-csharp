using CustomerCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerCrud.Infrastructure.Data;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id)
            .IsClustered();

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Firstname)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.Lastname)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(c => c.DateOfBirth)
            .IsRequired();

        builder.ToTable(c =>
        {
            c.HasCheckConstraint("CK_Customer_DateOfBirth_validation_notAheadOfCurentTime",
                "DateOfBirth <= GETDATE()");

            c.HasCheckConstraint("CK_Customer_DateOfBirth_validation_notGreaterThenOnHundred",
                "DateOfBirth > DATEADD(year, -100, GETDATE())");
        });

        builder.Property(c => c.BankAccountNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasIndex(c => c.Id)
            .IsUnique();

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.HasIndex(c => new
        {
            c.Firstname,
            c.Lastname,
            c.DateOfBirth
        }).IsUnique();
    }
}
