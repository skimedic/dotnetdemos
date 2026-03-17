// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Person.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Models.Entities.ComplexTypes;

[ComplexType]
public class Person
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; set; }
}