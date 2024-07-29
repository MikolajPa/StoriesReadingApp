using Microsoft.EntityFrameworkCore;

namespace StoriesReadingAPI.Models.Contexts
{
    public partial class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions
        <SampleDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LanguageLevels> LanguageLevels { get; set; }
        public virtual DbSet<Texts> Texts { get; set; }
        public virtual DbSet<Sentences> Sentences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(k => k.Id);
            });

            modelBuilder.Entity<LanguageLevels>(entity =>
            {
                entity.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Texts>(entity =>
            {
                entity.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Sentences>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
