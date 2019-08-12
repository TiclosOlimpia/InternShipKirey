using CodeFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Data
{
    public class MuzicaContext : DbContext
    {
        public MuzicaContext():base("name=Conection")
        {

        }
        public DbSet<Album> Albume { get; set; }
        public DbSet<Artist> Artisti { get; set; }
        public DbSet<GenMuzical> GenuriMuzicale { get; set; }
    }
}
