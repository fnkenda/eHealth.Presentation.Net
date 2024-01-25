using System.ComponentModel.DataAnnotations;

namespace eHealth.Presentation.Models
{
    public class Patient
    {
        public int idPatient { get; set; }

        [Display(Name = "Nom du patient:")]
        [Required(ErrorMessage = "Le nom du patient est obligatoire")]
        public string name { get; set; }

        [Display(Name = "Adress email:")]
        [Required(ErrorMessage = "Le mail du patient est obligatoire")]
        public string eMail { get; set; }

        [Display(Name = "Téléphone:")]
        [Required(ErrorMessage = "Le numéro de téléphone du patient est obligatoire")]
        public string tel { get; set; }
    }
}
