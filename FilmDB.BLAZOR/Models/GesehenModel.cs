using System.ComponentModel.DataAnnotations;

namespace FilmDB.BLAZOR.Models
{
    public class GesehenModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Titel ist erforderlich")]
        [StringLength(255, ErrorMessage = "Titel darf maximal 255 Zeichen lang sein")]
        public string Titel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Datum ist erforderlich")]
        [Display(Name = "Gesehen am")]
        public DateTime GesehenAm { get; set; } = DateTime.Today;

        [Range(1, 5, ErrorMessage = "Bewertung muss zwischen 1 und 5 liegen")]
        public int Bewertung { get; set; }

        public string? Kommentar { get; set; }

        [Required(ErrorMessage = "Sender ist erforderlich")]
        [Display(Name = "Sender")]
        public int GesehenBeiID { get; set; }

        public SenderModel? GesehenBei { get; set; }
    }
} 