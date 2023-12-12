using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaPelicula.Data;
using TiendaPelicula.Modelos;

namespace TiendaPelicula.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private readonly TiendaPelicula.Data.TiendaPeliculaContext _context;

        public IndexModel(TiendaPelicula.Data.TiendaPeliculaContext context)
        {
            _context = context;
        }
        
        public IList<Pelicula> Pelicula { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? TextoBusqueda { get; set; }

        public SelectList? Generos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? GeneroPelicula { get; set; }
        
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Pelicula
                                            orderby m.Genero
                                            select m.Genero;

            var movies = from m in _context.Pelicula
                         select m;

            if (!string.IsNullOrEmpty(TextoBusqueda))
            {
                movies = movies.Where(s => s.Title.Contains(TextoBusqueda));
            }

            if (!string.IsNullOrEmpty(GeneroPelicula))
            {
                movies = movies.Where(x => x.Genero == GeneroPelicula);
            }
            Generos = new SelectList(await genreQuery.Distinct().ToListAsync());
            Pelicula = await movies.ToListAsync();
        }
    }
}
