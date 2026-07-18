// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Person.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Models.Entities.ComplexTypes;

[ComplexType]
public class Person
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [XmlIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; private set; }
}