using Microsoft.EntityFrameworkCore;
using MovieDataBase_Api.Db.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MovieDataBase_Api.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovieEntity> MovieDb { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

}
