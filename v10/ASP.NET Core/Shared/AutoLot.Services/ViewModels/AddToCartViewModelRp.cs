// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - AddToCartViewModelRp.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.ViewModels;

public class AddToCartViewModelRp : AddToCartViewModelBase
{
    [Required]
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(
        nameof(StockQuantity),
        prefix: "Entity")]
    public int Quantity { get; set; }
}