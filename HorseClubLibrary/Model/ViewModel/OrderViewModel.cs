using HorseClubLibrary.Model.Entities;

namespace HorseClubLibrary.Model.ViewModel;

public class OrderViewModel
{
    public List<Orders> Orders { get; set; }
    public Orders Order { get; set; }
}