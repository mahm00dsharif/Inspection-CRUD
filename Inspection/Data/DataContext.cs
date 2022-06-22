using Microsoft.EntityFrameworkCore;

namespace Inspection.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Models.Inspection>(entity =>
            //{
            //    entity.HasOne<Models.InspectionType>().WithMany(p => p.Inspections).HasForeignKey(p => p.InspectionTypeId);
            //});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Inspection.Models.Inspection> inspections { get; set; }
        public DbSet<Inspection.Models.InspectionType> inspectionTypes { get; set; }
        public DbSet<Inspection.Models.Status> statuses { get; set; }
    }
}
