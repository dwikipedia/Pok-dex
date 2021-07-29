using Microsoft.EntityFrameworkCore;
using Pokédex.Model;
using System;

namespace Pokédex.AppContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }



        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
