using System.ComponentModel.DataAnnotations;
namespace eHealth.Presentation.Models
{
    public class Medecin
    {
        [Key]
        public int IdMedecin { get; set; }

        [Display(Name = "Nom du médecin:")]
        [Required(ErrorMessage = "Le nom du médecin est obligatoire")]
        public string Nom { get; set; }

		[Display(Name = "Préom du médecin:")]
		[Required(ErrorMessage = "Le Prénom du médecin est obligatoire")]
		public string Prenom { get; set; }

		[Display(Name = "La spécialité du médecin:")]
		[Required(ErrorMessage = "La spécialité du méddecin est un champ obligatoire")]
		public string Specialite { get; set; }
    }
}
