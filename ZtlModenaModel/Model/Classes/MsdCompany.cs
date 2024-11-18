using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class MsdCompany
{
    public int CompanyId { get; set; }

    public string Company { get; set; } = null!;

    public int IdTown { get; set; }

    public string? Description { get; set; }

    public string PreferredLanguage { get; set; } = null!;

    public string AlternativeLanguage { get; set; } = null!;

    public string ApplicationLanguage { get; set; } = null!;

    public bool Disabled { get; set; }

    public string? OnWeb { get; set; }

    public string? CompanyCod { get; set; }

    public string WebSiteUrl { get; set; } = null!;

    public string? CompanyName { get; set; }

    public string? TaxIdNumber { get; set; }

    public string? FiscalCode { get; set; }

    public string? Address { get; set; }

    public string? Zipcode { get; set; }

    public string? City { get; set; }

    public string? County { get; set; }

    public string? Country { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telex { get; set; }

    public string? Fax { get; set; }

    public string? Internet { get; set; }

    public string? Email { get; set; }

    public string? IsocountryCode { get; set; }

    public string? Siacode { get; set; }

    public string? CertifiedEmail { get; set; }

    public bool? OnNavision { get; set; }

    public bool? OnParkweb { get; set; }

    public bool? HasCostCenters { get; set; }

    public int InstallationType { get; set; }

    public string CustomerCodePrefixXpk { get; set; } = null!;

    public int CustomerCodeLengthXpk { get; set; }

    public string CustomerCodePrefixNav { get; set; } = null!;

    public int CustomerCodeLengthNav { get; set; }

    public bool HasOnstreet { get; set; }

    public bool HasOffStreet { get; set; }

    public string? AdiutoId { get; set; }

    public string? NavisionCode { get; set; }

    public string? PersonReference { get; set; }

    public string? TelephoneReference { get; set; }

    public string? DescriptionOnline { get; set; }

    public int? CompanyType { get; set; }

    public int? ManagingCompanyId { get; set; }

    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();

    public virtual ICollection<XpkPlateList> XpkPlateLists { get; set; } = new List<XpkPlateList>();

    public virtual ICollection<XpkSubscriptionType> XpkSubscriptionTypes { get; set; } = new List<XpkSubscriptionType>();
}
