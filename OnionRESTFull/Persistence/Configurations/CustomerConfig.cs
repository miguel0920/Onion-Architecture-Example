using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(builder => builder.Id);

            builder.Property(builder => builder.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(builder => builder.LastName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(builder => builder.BirthdayDate)
                .IsRequired(false);

            builder.Property(builder => builder.Phone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(builder => builder.Email)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(builder => builder.Address)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(builder => builder.Age);

            builder.Property(builder => builder.CreatedBy)
                .HasMaxLength(30);

            builder.Property(builder => builder.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}