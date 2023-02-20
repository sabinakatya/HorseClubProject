using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseClubLibrary.Model.Entities;

public class DurationTours
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    public string DurationName { get; set; }
}