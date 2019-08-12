using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Models
{
    public class Artist
    {
        [Key]
        public int IdArtist { get; set; }

        [MaxLength(255)]
        [Required]
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(10)]
        public string NumeScena { get; set; }
        public ICollection<Album> Albume { get; set; }

    }
}
