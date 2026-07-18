// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CarViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Models.ViewModels;

[EntityTypeConfiguration(typeof(CarViewModelConfiguration))]
[Keyless]
public class CarViewModel
{
    public int Id { get; set; }
    public bool IsDrivable { get; set; }
    public DateTime? DateBuilt { get; set; }
    public string Price { get; set; }
    public int MakeId { get; set; }

    [MaxLength(50)]
    public string Color { get; set; }

    [MaxLength(50)]
    public string PetName { get; set; }
}