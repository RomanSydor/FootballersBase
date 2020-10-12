using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballersBase.Models
{
    [Table("Coaches")]
    public class Coach
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string  Country { get; set; }
        public int? ClubId { get; set; }
        public int? NationalTeamId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }

        [ForeignKey(nameof(NationalTeamId))]
        public NationalTeam NationalTeam { get; set; }
    }
}
