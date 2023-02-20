using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseClubLibrary.Model.Entities;

public class Tours
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    public string TourName { get; set; }

    [Required(ErrorMessage = "Данное поле должно быть заполненным!")]
    public decimal TourPrice { get; set; }

    public string? TourDescription { get; set; }

    public string? TourImage { get; set; }

    public int DurationTourId { get; set; }
    public virtual DurationTours DurationTour { get; set; }

    public Tours()
    {
    }

    public Tours(string tourName, 
                 decimal tourPrice, 
                 string tourImage, 
                 string tourDescription, 
                 int durationTourId)
    {
        TourName = tourName;
        TourPrice = tourPrice;
        TourImage = tourImage;
        TourDescription = tourDescription;
        DurationTourId = durationTourId;
    }
}