using Microsoft.EntityFrameworkCore;
using MoviesApi.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MoviesApi
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        // con esto definiremos el nombre de la tabla que se va a crar en el db 
        public DbSet <Genre>  Genres { get; set; }

        //EXAM 
        public DbSet<exam> Subjects { get; set; }

        //User
        public DbSet<user> User { get; set; }

        //Login
        public DbSet<login> login { get; set; }

        //Score
        public DbSet<Score> Score { get; set; }

    }
}
