using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendClain.Models
{
    public class Clain
    {
        [Key] //Key nos indica que esta es la llave principal
        public string Dieta { get; set; }
        [Required]// no va a dejar que dejemos el name vacío
        [StringLength(600, MinimumLength = 2, ErrorMessage = "INGRESE ENTRE 2 A 600 CARACTERES")]
        [Display(Name = "Nombre de la Dieta")]
        public string NombreDieta { get; set; }
        [Required]
        [StringLength(999999999, MinimumLength = 2, ErrorMessage = "INGRESE ENTRE 2 A 999999999 CARACTERES")]
        [Display(Name = "Información de la dieta")]
        public string Info { get; set; }
        [Required]
        [StringLength(999999999, MinimumLength = 2, ErrorMessage = "INGRESE ENTRE 2 A 999999999 CARACTERES")]
        [Display(Name = "Menú de la dieta")]
        public string Menu { get; set; }
        [Display(Name = "Nota (Opcional)")]
        public string Nota { get; set; }
    }
}
