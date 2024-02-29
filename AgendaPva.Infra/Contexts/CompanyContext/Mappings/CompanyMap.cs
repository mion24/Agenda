using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.CompanyContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Infra.Contexts.CompanyContext.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(120)
                .IsRequired(true);

            builder.OwnsOne(c => c.Cnpj)
                .Property(c => c.DocNumber)
                .HasColumnName("CNPJ")
                .IsRequired(true);

            builder.Property(c => c.PhoneNumbers)
                .HasConversion(
                p => string.Join(',', p), 
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                );

            builder.Property(c => c.Image)
                .HasColumnName("Image")
                .IsRequired(false);

            builder.Property(c => c.IsSub)
                .HasColumnName("IsSub")
                .HasDefaultValue(false);

            builder.Property(c => c.CompanyOwner)
                .HasColumnName("CompanyOwnerID")
                .IsRequired();
        }
    }
}
