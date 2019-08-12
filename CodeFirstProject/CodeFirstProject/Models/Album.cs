using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Models
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }

        [Required]
        public string NumeAlbum { get; set; }
        public int IdArtist { get; set; }
        public Artist Artist { get; set; }
        public int IdGenMuzical { get; set; }
        public GenMuzical GenMuzical { get; set; }
        public int AnLansare { get; set; }

        [Range(1, 100)]
        public int Numar { get; set; }
        public float Pret { get; set; }
    }
}
