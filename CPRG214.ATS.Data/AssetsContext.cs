using CPRG214.ATS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPRG214.ATS.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext() : base() { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;
                                        Database=ATS;
                                        Trusted_Connection=True;"
                                        );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
            new AssetType { Id = 1, Name = "Computer" },
            new AssetType { Id = 2, Name = "Monitor" },
            new AssetType { Id = 3, Name = "Phone" }
            );
            modelBuilder.Entity<Asset>().HasData(
            new Asset
            {
                Id = 1,
                TagNumber = "ASSET-0001",
                Manufacturer = "Dell",
                AssetTypeId = 1,
                Description = "Boardroom Computer",
                SerialNumber = "CN-00FFXD-74261-3AB-1KFS"
            },
            new Asset
            {
                Id = 2,
                TagNumber = "ASSET-0002",
                Manufacturer = "LG",
                AssetTypeId = 2,
                Description = "Entrance Monitor",
                SerialNumber = "604RMMD8U923",
                Model = "LG-U2419HC"
            },
            new Asset
            {
                Id = 3,
                TagNumber = "ASSET-0003",
                Manufacturer = "Cisco",
                AssetTypeId = 3,
                Description = "Reception Phone",
                SerialNumber = "SAD083-00D4W",
            },
            new Asset
            {
                Id = 4,
                TagNumber = "ASSET-0004",
                Manufacturer = "Acer",
                AssetTypeId = 1,
                Description = "Manager's Laptop",
                SerialNumber = "NX.GNPSI.012)",
                Model = "Aspire 3"
            },
            new Asset
            {
                Id = 5,
                TagNumber = "ASSET-0005",
                Manufacturer = "HP",
                AssetTypeId = 2,
                Description = "Boardroom Monitor",
                SerialNumber = "LC49RG90SSNXZA",
                Model = "WQHD-GTG"
            }
            );
        }
    }
}
