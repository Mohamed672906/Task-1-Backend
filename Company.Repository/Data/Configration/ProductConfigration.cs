using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Repository.Data.Configration
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ProductId);

           
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);


            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);


            builder.Property(p => p.Price).IsRequired()
                            .HasColumnType("decimal(18,2)")
                            .HasDefaultValue(0);

            builder.Property(p => p.Stock)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(p => p.order)
                .WithMany(o => o.products)
                .HasForeignKey(p => p.OrderId);

        }
    }
}
