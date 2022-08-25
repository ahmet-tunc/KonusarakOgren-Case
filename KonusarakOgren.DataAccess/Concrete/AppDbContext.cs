using KonusarakOgren.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KonusarakOgren.DataAccess.Concrete
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=DbKonusarakOgren;Trusted_Connection=True;");
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColorFeature> ProductColorFeatures { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductPhysicalFeature> ProductPhysicalFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //BRAND
            builder.Entity<Brand>(p =>
            {
                p.Property(p => p.Name).HasMaxLength(100).IsRequired();
            });


            //PRODUCT
            builder.Entity<Product>(p =>
            {
                p.Property(p => p.Name).HasMaxLength(100).IsRequired();
                p.Property(p => p.Description).HasMaxLength(1000);
                p.HasOne(p => p.Brand);
            });



            //PRODUCTCOLORFEATURE
            builder.Entity<ProductColorFeature>(p =>
            {
                p.Property(p => p.PrimaryColor).HasMaxLength(10);
                p.Property(p => p.SecondaryColor).HasMaxLength(10);
            });



            //PRODUCTCOMMENT
            builder.Entity<ProductComment>(p =>
            {
                p.Property(p => p.Title).HasMaxLength(50).IsRequired();
                p.Property(p => p.Comment).HasMaxLength(250).IsRequired();
                p.Property(p => p.CommentId).HasDefaultValue(0);
            });



            //PRODUCTDISCOUNT
            builder.Entity<ProductDiscount>(p =>
            {
                p.Property(p => p.DiscountPercentage).IsRequired();
                p.Property(p => p.ProductFeatureId).IsRequired();
            });


            //PRODUCTFEATURE
            builder.Entity<ProductFeature>(p =>
            {
                p.Property(p => p.Quantity).IsRequired();
                p.HasOne(p => p.Product);
                p.Property(p => p.Price).IsRequired();
            });


            builder.Entity<Brand>()
                .HasData(new List<Brand>
                {
                    new Brand
                        {
                            Id = 1,
                            Name = "Brand-test01",
                            CreatedDate = new DateTime(2022,03,05),
                            UpdatedDate = DateTime.Now
                        },
                        new Brand
                        {
                            Id = 2,
                            Name = "Brand-test02",
                            CreatedDate = new DateTime(2021,02,08),
                            UpdatedDate = DateTime.Now
                        },
                        new Brand
                        {
                            Id = 3,
                            Name = "Brand-test03",
                            CreatedDate = new DateTime(2019,07,01),
                            UpdatedDate = DateTime.Now
                        }
                });


            builder.Entity<AppUser>()
                .HasData(new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "4188bf3d-76ba-40af-ba09-7d5ad604276f",
                        BrandId = 1,
                        Email = "deneme@gmail.com",
                        NormalizedEmail = "DENEME@GMAIL.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEP+t7hXkvUEw6+qbLmOjwmVM/11O3UgYu7gBxnOb8ZRkc1U+H8wqUcyKQzeC0MtVtA==",
                        SecurityStamp = "CNQF6L3432G4PS4B3HJ4N3N366DZ7QCL",
                        ConcurrencyStamp = "f9eedfbe-6d2b-416d-84af-5536194a6da3",
                        PhoneNumber = "5383510407",
                        LockoutEnabled = true,
                        UserName = "test01"
                    },
                    new AppUser
                    {
                        Id = "ff0370f0-e73d-4715-ac05-386aca1b8e9c",
                        BrandId = 2,
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEP+t7hXkvUEw6+qbLmOjwmVM/11O3UgYu7gBxnOb8ZRkc1U+H8wqUcyKQzeC0MtVtA==",
                        SecurityStamp = "CNQF6L3432G4PS4B3HJ4N3N366DZ7QCL",
                        ConcurrencyStamp = "f9eedfbe-6d2b-416d-84af-5536194a6da3",
                        PhoneNumber = "5383510407",
                        LockoutEnabled = true,
                        UserName = "test02"
                    },
                    new AppUser
                    {
                        Id = "23498bf7-34f2-4458-96f2-03f8c5b7517c",
                        BrandId = 3,
                        Email = "test@gmail.com",
                        NormalizedEmail = "TEST@GMAIL.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEP+t7hXkvUEw6+qbLmOjwmVM/11O3UgYu7gBxnOb8ZRkc1U+H8wqUcyKQzeC0MtVtA==",
                        SecurityStamp = "CNQF6L3432G4PS4B3HJ4N3N366DZ7QCL",
                        ConcurrencyStamp = "f9eedfbe-6d2b-416d-84af-5536194a6da3",
                        PhoneNumber = "5383510407",
                        LockoutEnabled = true,
                        UserName = "test03"
                    }

                });


            builder.Entity<IdentityRole>()
            .HasData(new List<IdentityRole>
            {
                  new IdentityRole
                  {
                      Id = "b92d9e23-b033-40df-9dab-a601330448c9",
                      Name = "SysAdmin",
                      NormalizedName = "SYSADMIN",

                  },
                  new IdentityRole
                  {
                      Id = "9c5ea4a2-dd32-4e38-8c6c-9accbd797562",
                      Name = "Admin",
                      NormalizedName = "ADMIN",
                  },
                  new IdentityRole
                  {
                      Id = "6c592aca-7420-4c1f-9b8b-5f623e04da66",
                      Name = "Customer",
                      NormalizedName = "CUSTOMER",
                  }

            });


            builder.Entity<IdentityUserRole<string>>()
            .HasData(new List<IdentityUserRole<string>>
            {
                 new IdentityUserRole<string>
                 {
                     RoleId = "b92d9e23-b033-40df-9dab-a601330448c9",
                     UserId = "4188bf3d-76ba-40af-ba09-7d5ad604276f",

                 },
                 new IdentityUserRole<string>
                 {
                     RoleId = "9c5ea4a2-dd32-4e38-8c6c-9accbd797562",
                     UserId = "ff0370f0-e73d-4715-ac05-386aca1b8e9c",
                 },
                 new IdentityUserRole<string>
                 {
                     RoleId = "6c592aca-7420-4c1f-9b8b-5f623e04da66",
                     UserId = "23498bf7-34f2-4458-96f2-03f8c5b7517c",
                 }
            });


            builder.Entity<Product>()
            .HasData(new List<Product>
            {
                 new Product
                 {
                     Id = 1,
                     Name = "Product-test01",
                     Description = "test01-description",
                     BrandId = 1,
            
                 },
                 new Product
                 {
                     Id = 2,
                     Name = "Product-test02",
                     Description = "test02-description",
                     BrandId = 2,
                 },
                 new Product
                 {
                     Id = 3,
                     Name = "Product-test03",
                     BrandId = 3,
                     Description = "test03-description",
                 },
                 new Product
                 {
                     Id = 4,
                     Name = "Product-test04",
                     Description = "test04-description",
                     BrandId = 3,
                 }
            });
            


            base.OnModelCreating(builder);
        }
    }
}
