using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePharmacy.Shared.Domain;

namespace OnlinePharmacy.Server.Configurations.Entities
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "CeraVe Cleanser",
                    Category = "Cleanser",
                    Price = 25.50,
                    Description = "Description",
                    Quantity = 9,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 2,
                    Name = "Cetaphil Moisturizer",
                    Category = "Moisturizer",
                    Price = 20.00,
                    Description = "Description",
                    Quantity = 8,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 3,
                    Name = "Paula's Choice Exfoliant",
                    Category = "Exfoliant",
                    Price = 30.00,
                    Description = "Description",
                    Quantity = 9,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 4,
                    Name = "Cetaphil Sunscreen",
                    Category = "Sunscreen",
                    Price = 15.00,
                    Description = "Description",
                    Quantity = 9,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 5,
                    Name = "La Roche Posay Exfoliant",
                    Category = "Exfoliant",
                    Price = 35.50,
                    Description = "Description",
                    Quantity = 9,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 6,
                    Name = "CeraVe Moisturizer",
                    Category = "Moisturizer",
                    Price = 25.00,
                    Description = "Description",
                    Quantity = 8,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Product
                {
                    Id = 7,
                    Name = "CeraVe Sunscreen",
                    Category = "Sunscreen",
                    Price = 20.00,
                    Description = "Description",
                    Quantity = 9,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );
        }
    }
}
