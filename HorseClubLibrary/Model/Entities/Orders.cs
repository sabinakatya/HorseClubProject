using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseClubLibrary.Model.Entities;

public class Orders
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    [Phone(ErrorMessage = "Введен некорректный номер!")]
    public string CustoerPhone { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    [EmailAddress(ErrorMessage = "Введена некорректная почта!")]
    public string CustomerEmail { get; set; }

    public string? Message { get; set; }

    public int StatusId { get; set; }
    public virtual Statuses Status { get; set; }

    public int TourId { get; set; }
    public virtual Tours Tour { get; set; }

    public Orders(string customerName, 
                  string custoerPhone, 
                  string customerEmail, 
                  string message, 
                  int statusId,
                  int tourId)
    {
        CustomerName = customerName;
        CustoerPhone = custoerPhone;
        CustomerEmail = customerEmail;
        Message = message;
        StatusId = statusId;
        TourId = tourId;
    }
}