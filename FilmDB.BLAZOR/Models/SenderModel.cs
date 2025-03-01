using System.ComponentModel.DataAnnotations;

namespace FilmDB.BLAZOR.Models
{
    public class SenderModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Sendername ist erforderlich")]
        [StringLength(50, ErrorMessage = "Sendername darf maximal 50 Zeichen lang sein")]
        public string Sendername { get; set; } = string.Empty;
    }
} 