using CodeFirstProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MuzicaContext();

            var result = GetScensW(context);
            foreach(var r in result)
                Console.WriteLine(r);

            Console.WriteLine();

            var result2 = GetArtistsAbdAlbumes(context);
            foreach (var r in result2)
                Console.WriteLine(r.ToString());

            Console.WriteLine();

            var result3 = GetAlbumsPop(context);
            foreach (var r in result3)
                Console.WriteLine(r.ToString());

            var result34 = GetGenuriMuzicalw(context);

            Console.WriteLine(result34);

            Console.ReadLine();

        }

        public static IEnumerable<string> GetScensW (MuzicaContext muzicaContext)
        {
            var result = from c in muzicaContext.Artisti
                         where c.NumeScena.Length < 10
                         select c.NumeScena;

            return result;
        }

        public static IQueryable<object> GetArtistsAbdAlbumes(MuzicaContext muzicaContext)
        {
            var maxPrice = muzicaContext.Albume.Max(c => c.Pret);

            var result = from c in muzicaContext.Albume.Include("Artisti")
                         where c.Pret == maxPrice
                         select new { Artist = c.Artist.Nume, NumeAlbum = c.NumeAlbum, Pret= c.Pret };
            return result;
        }

        public static IQueryable<object> GetAlbumsPop(MuzicaContext muzicaContext)
        {
            var result = from c in muzicaContext.Albume.Include("GenMuzical")
                         where c.GenMuzical.Nume == "pop"
                         select new { Album = c.NumeAlbum, Pret = c.Pret, Gen = c.GenMuzical.Nume };

            return result;

        }

        //public static IQueryable<object> GetAlbumsPop2(MuzicaContext muzicaContext)
        //{
        //    var result = from c in muzicaContext.GenuriMuzicale.Include("Album")
        //                 where c.Nume == "pop"
        //                 select new { Album = c.Albume.Num , Pret = c.Pret, Gen = c.GenMuzical.Nume };

        //    return result;

        //}

        public static object GetGenuriMuzicalw(MuzicaContext muzicaContext)
        {
            var result = from c in muzicaContext.Albume.Include("GenMuzical")
                         group c by c.GenMuzical into g
                         select new { GenMuzical = g.Key, Numar = g.Sum(c=> c.Numar)};

            return result.OrderByDescending(c=> c.Numar).FirstOrDefault();

        }
    }
}
