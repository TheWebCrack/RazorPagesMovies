using Microsoft.EntityFrameworkCore;
using RazorPagesMovies.Data;

namespace RazorPagesMovies.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMoviesContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPageMovieContext");
                }
                if(context.Movie.Any())
                {
                    //Base de datos muestra todo lo que cotiene la clase
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-02-12"),
                        Genre = "Romantic",
                        Price = 7.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-03-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G",
                    },
                    new Movie
                    {
                        Title = "Ghostbuster 2",
                        ReleaseDate = DateTime.Parse("1989-02-02"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G",
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-04-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA",
                    }

                ) ;
                context.SaveChanges();
                //Add-Migration InitialCreate
                //Add-Migration Rating
                //Update Database
            }
        }
    }
}
