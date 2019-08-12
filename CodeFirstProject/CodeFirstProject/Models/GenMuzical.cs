using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Models
{
    public class GenMuzical
    {
        [Key]
        public int IdGenMuzical { get; set; }
        public string Nume { get; set; }
        public ICollection<Album> Albume { get; set; }
        public object Artisti { get; internal set; }
        public object Album { get; internal set; }
    }
}
