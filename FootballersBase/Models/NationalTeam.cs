using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballersBase.Models
{
    [Table("NationalTeams")]

    public class NationalTeam
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; }
        public int CoachId { get; set; }

        [ForeignKey(nameof(CoachId))]
        public Coach Coach { get; set; }
    }
}
