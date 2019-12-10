using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3TournoisJVFinal.Models
{
    public class TournoiContext:DbContext
    {
        public TournoiContext(DbContextOptions<TournoiContext>options) : base(options)
        {

    
        }
        public DbSet<Tournoi> Tournois { get; set; }

    }
}
