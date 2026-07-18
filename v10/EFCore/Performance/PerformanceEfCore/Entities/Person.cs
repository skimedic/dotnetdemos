// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Person.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore.Entities;

/// <summary>
/// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
/// </summary>
[Table("Person", Schema = "Person")]
[Index("Rowguid", Name = "AK_Person_rowguid", IsUnique = true)]
[Index("LastName", "FirstName", "MiddleName", Name = "IX_Person_LastName_FirstName_MiddleName")]
[Index("AdditionalContactInfo", Name = "PXML_Person_AddContact")]
[Index("Demographics", Name = "PXML_Person_Demographics")]
[Index("Demographics", Name = "XMLPATH_Person_Demographics")]
[Index("Demographics", Name = "XMLPROPERTY_Person_Demographics")]
[Index("Demographics", Name = "XMLVALUE_Person_Demographics")]
public partial class Person
{
    /// <summary>
    /// Primary key for Person records.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
    /// </summary>
    [Required]
    [StringLength(2)]
    public string PersonType { get; set; }

    /// <summary>
    /// 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
    /// </summary>
    public bool NameStyle { get; set; }

    /// <summary>
    /// A courtesy title. For example, Mr. or Ms.
    /// </summary>
    [StringLength(8)]
    public string Title { get; set; }

    /// <summary>
    /// First name of the person.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    /// <summary>
    /// Middle name or middle initial of the person.
    /// </summary>
    [StringLength(50)]
    public string MiddleName { get; set; }

    /// <summary>
    /// Last name of the person.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    /// <summary>
    /// Surname suffix. For example, Sr. or Jr.
    /// </summary>
    [StringLength(10)]
    public string Suffix { get; set; }

    /// <summary>
    /// 0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. 
    /// </summary>
    public int EmailPromotion { get; set; }

    /// <summary>
    /// Additional contact information about the person stored in xml format. 
    /// </summary>
    [Column(TypeName = "xml")]
    public string AdditionalContactInfo { get; set; }

    /// <summary>
    /// Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.
    /// </summary>
    [Column(TypeName = "xml")]
    public string Demographics { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("Person")]
    public virtual BusinessEntity BusinessEntity { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new List<BusinessEntityContact>();

    [InverseProperty("Person")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

    [InverseProperty("BusinessEntity")]
    public virtual Employee Employee { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual Password Password { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new List<PersonCreditCard>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<PersonPhone> PersonPhones { get; set; } = new List<PersonPhone>();
}
