using GameCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace GoogleGameSQLDb
{
    public class GoogleGameDbContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }

        public GoogleGameDbContext(DbContextOptions<GoogleGameDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
