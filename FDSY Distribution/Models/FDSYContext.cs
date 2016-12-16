namespace FDSY_Distribution.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FDSYContext : DbContext
    {
        public FDSYContext()
            : base("name=FDSYContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Bar> Bars { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>()
                .HasMany(e => e.Beers)
                .WithMany(e => e.Bars)
                .Map(m => m.ToTable("BeerStore").MapLeftKey("Stores_StoreId").MapRightKey("Beers_BeerId"));

            modelBuilder.Entity<Bar>()
                .HasMany(e => e.SalesOrders)
                .WithMany(e => e.Bars)
                .Map(m => m.ToTable("SalesOrderBar").MapLeftKey("Bars_StoreId").MapRightKey("SalesOrders_SalesOrderID"));

            modelBuilder.Entity<Beer>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Beer>()
                .Property(e => e.ABV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Brewery>()
                .HasMany(e => e.Beers)
                .WithRequired(e => e.Brewery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brewery>()
                .HasMany(e => e.SalesOrders)
                .WithRequired(e => e.Brewery)
                .HasForeignKey(e => e.Brewery_BreweryId)
                .WillCascadeOnDelete(false);
        }
    }
}
