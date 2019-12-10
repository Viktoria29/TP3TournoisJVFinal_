using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3TournoisJVFinal.Models
{
    public class Tournoi
    {
        [Key]
        public int IdTournoi { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage ="Le Champ est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le Champ est requis, Veuillez rentrer un chiffre positif")]
        public int Prix { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Le Champ est requis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le Champ est requis")]
        public string Date { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Le Champ est requis")]
        public string Jeu { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Le Champ est requis")]
        public string Theme { get; set; }

    }
}
