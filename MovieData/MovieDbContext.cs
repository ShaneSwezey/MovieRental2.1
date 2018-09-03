using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieData.DataModels;

namespace MovieData
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CarouselMovie> CarouselMovies { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeEmail> OfficeEmails { get; set; }
        public DbSet<OfficePhoneNumber> OfficePhoneNumbers { get; set; }
        public DbSet<RentalCheckout> RentalCheckouts { get; set; }
        public DbSet<RentalCheckoutHistory> RentalCheckoutHistories { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<BlueRay> BlueRays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
                .HasKey(t => new { t.MovieId, t.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.MovieActors)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(pt => pt.Actor)
                .WithMany(t => t.MovieActors)
                .HasForeignKey(pt => pt.ActorId);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(t => new { t.MovieId, t.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.MovieGenres)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(pt => pt.Genre)
                .WithMany(p => p.MovieGenres)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<Office>()
                .HasMany(c => c.OfficeEmails)
                .WithOne(e => e.Office);

            modelBuilder.Entity<Office>()
                .HasMany(c => c.OfficePhoneNumbers)
                .WithOne(e => e.Office);

            modelBuilder.Entity<MovieAssest>()
                .ToTable("MovieAssests");
        }
    }
}
