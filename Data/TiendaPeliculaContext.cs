using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaPelicula.Modelos;

namespace TiendaPelicula.Data
{
    public class TiendaPeliculaContext : DbContext
    {
        public TiendaPeliculaContext (DbContextOptions<TiendaPeliculaContext> options)
            : base(options)
        {
        }

        public DbSet<TiendaPelicula.Modelos.Pelicula>? Pelicula { get; set; } = default!;
    }
}
