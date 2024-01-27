using System.ComponentModel.DataAnnotations;

namespace eHealth.Presentation.Models
{
	public class Clinique
	{
		public int IdClinique { get; set; }

		[Required(ErrorMessage = "Le nom de la clinique est obligatoire")]
		[Display(Name = "Nom :")]
		public string Nom { get; set; }

		[Required(ErrorMessage = "L'adresse de la clinique est obligatoire")]
		[Display(Name = "Adresse :")]
		public string Adresse { get; set; }

		[Required(ErrorMessage = "Le numéro de téléphone de la clinique est obligatoire")]
		[Display(Name = "Téléphone :")]
		public string Telephone { get; set; }

		public ICollection<Medecin> medecins { get; set; } = new List<Medecin>();
	}
}
