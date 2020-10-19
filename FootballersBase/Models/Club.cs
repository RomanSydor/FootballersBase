using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballersBase.Models
{
    [Table("Clubs")]
    public class Club
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public int? CoachId { get; set; }

        [ForeignKey(nameof(CoachId))]
        public Coach Coach { get; set; }
    }
}
