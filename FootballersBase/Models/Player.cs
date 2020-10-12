using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballersBase.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int? ClubId { get; set; }
        public int? NationalTeamId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club Club { get; set; }

        [ForeignKey(nameof(NationalTeamId))]
        public NationalTeam NationalTeam { get; set; }
    }
}
