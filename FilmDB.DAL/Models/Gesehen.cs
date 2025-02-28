using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.DAL.Models
{
    public class Gesehen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Titel { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime GesehenAm { get; set; }

        public int Bewertung { get; set; }

        [Column(TypeName = "text")]
        public string? Kommentar { get; set; }

        [Required]
        public int GesehenBeiID { get; set; }

        [ForeignKey("GesehenBeiID")]
        public virtual Sender? GesehenBei { get; set; }
    }
} 