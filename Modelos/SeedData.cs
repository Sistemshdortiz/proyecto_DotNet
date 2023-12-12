using Microsoft.EntityFrameworkCore;
using TiendaPelicula.Data;

namespace TiendaPelicula.Modelos
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TiendaPeliculaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TiendaPeliculaContext>>()))
            {
                if (context == null || context.Pelicula == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Pelicula.Any())
                {
                    return;   // DB has been seeded
                }

                context.Pelicula.AddRange(
                    new Pelicula
                    {
                        Title = "When Harry Met Sally",
                        FechaPublicacion = DateTime.Parse("1989-2-12"),
                        Genero = "Romantic Comedy",
                        Precio = 7.99M,
                        Calificacion = "R"
                    },

                    new Pelicula
                    {
                        Title = "Ghostbusters ",
                        FechaPublicacion = DateTime.Parse("1984-3-13"),
                        Genero = "Comedy",
                        Precio = 8.99M,
                        Calificacion = "P"
                    },

                    new Pelicula
                    {
                        Title = "Ghostbusters 2",
                        FechaPublicacion = DateTime.Parse("1986-2-23"),
                        Genero = "Comedy",
                        Precio = 9.99M,
                        Calificacion = "PG"
                    },

                    new Pelicula
                    {
                        Title = "Rio Bravo",
                        FechaPublicacion = DateTime.Parse("1959-4-15"),
                        Genero = "Western",
                        Precio = 3.99M,
                        Calificacion = "X"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
