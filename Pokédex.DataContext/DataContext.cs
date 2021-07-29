using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

namespace Pokédex.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }
    }

    public DbSet
}
