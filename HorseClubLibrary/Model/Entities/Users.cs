using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseClubLibrary.Model.Entities;

public class Users
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    public string LoginUser { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    [MinLength(6, ErrorMessage = "Длина пароля должна составлять минимум 6 символов!")]
    public string PasswordUser { get; set; }
}