﻿using Microsoft.EntityFrameworkCore;
using UrlShortener.Abstractions.Model;
using UrlShortener.Data.Sqlite;

namespace PetrsUrlShortener.Database
{
    public class UrlDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
        }

        public DbSet<ShortenedUrl> Urls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const int MAX_URL = 2048;
            const int LENGTH_USER_ID = 38; // GUID Length

            base.OnModelCreating(modelBuilder);

            //Define the Table(s) and References to be created automatically
            modelBuilder.Entity<ShortenedUrl>(b =>
            {
                b.HasKey(e => e.ShortUrl);
                b.Property(e => e.ShortUrl).HasValueGenerator<ShortUrlValueGenerator>();
                b.Property(e => e.Url).IsRequired().HasMaxLength(MAX_URL);
                b.Property(e => e.UserId).IsRequired().HasMaxLength(LENGTH_USER_ID).IsFixedLength(true);
                b.Property(e => e.Created).IsRequired();

                b.ToTable("Url");
            });
        }
    }
}
