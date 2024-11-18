using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class XpkCustomer
{
    public string CustomerCode { get; set; } = null!;

    public int CustomerIdOld { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public string Disabled { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string TaxIdNumber { get; set; } = null!;

    public string FiscalCode { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Telephone2 { get; set; } = null!;

    public string StreetType { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string StreetNo { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public int? IdTown { get; set; }

    public string Town { get; set; } = null!;

    public string County { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string IsocountryCode { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string BornTown { get; set; } = null!;

    public string BornTownCode { get; set; } = null!;

    public string BornCounty { get; set; } = null!;

    public string BornCountry { get; set; } = null!;

    public string BornIsocountryCode { get; set; } = null!;

    public string BornAbroad { get; set; } = null!;

    public string InvoiceCustomerCode { get; set; } = null!;

    public int InvoiceCustomerIdOld { get; set; }

    public DateTime Tbcreated { get; set; }

    public DateTime? Tbmodified { get; set; }

    public int TbcreatedId { get; set; }

    public int? TbmodifiedId { get; set; }

    public string StreetHouseNo { get; set; } = null!;

    public string StreetHouseSubNo { get; set; } = null!;

    public string StreetHouseIntNo { get; set; } = null!;

    public int? IdStreet { get; set; }

    public string StreetCode { get; set; } = null!;

    public int CustomerCateg { get; set; }

    public int DomicileType { get; set; }

    public int? IdStreetDom { get; set; }

    public int? IdTownDom { get; set; }

    public string? DomTown { get; set; }

    public string? DomCounty { get; set; }

    public string? DomCountry { get; set; }

    public string DomStreetCode { get; set; } = null!;

    public string DomStreetType { get; set; } = null!;

    public string DomStreetName { get; set; } = null!;

    public string DomStreetHouseNo { get; set; } = null!;

    public string DomStreetHouseSubNo { get; set; } = null!;

    public string DomStreetHouseIntNo { get; set; } = null!;

    public string DomStreetNo { get; set; } = null!;

    public string DomWorkingSite { get; set; } = null!;

    public string DomNotes { get; set; } = null!;

    public string PartnerFirstName { get; set; } = null!;

    public string PartnerLastName { get; set; } = null!;

    public int PartnerAuthorization { get; set; }

    public string IsGarageOwner { get; set; } = null!;

    public string DelivAddress { get; set; } = null!;

    public string DelivZipcode { get; set; } = null!;

    public string DelivTown { get; set; } = null!;

    public string DelivCounty { get; set; } = null!;

    public string DrivingLicNumber { get; set; } = null!;

    public string DrivingLicRelFrom { get; set; } = null!;

    public DateTime DrivingLicExpirDate { get; set; }

    public string? LeaseNumber { get; set; }

    public DateTime? LeaseExpirDate { get; set; }

    public int DocumentType { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public string DocumentRelFrom { get; set; } = null!;

    public DateTime? DocumentExpirDate { get; set; }

    public Guid RegistrationCode { get; set; }

    public string Notes { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? PassSyncDateTime { get; set; }

    public string UsrCustomerCode { get; set; } = null!;

    public string IsManual { get; set; } = null!;

    public string DelivCountry { get; set; } = null!;

    public int CustomerId { get; set; }

    public int? InvoiceCustomerId { get; set; }

    public int? UserId { get; set; }

    public int? DelegateDocumentType { get; set; }

    public string? DelegateDocumentNumber { get; set; }

    public string? DelegateDocumentRelFrom { get; set; }

    public DateTime? DelegateDocumentExpirDate { get; set; }

    public int? Ztlkey { get; set; }

    public int? AgencyId { get; set; }

    public string UniqueCode { get; set; } = null!;

    public string Pec { get; set; } = null!;

    public string? Iban { get; set; }

    public bool IsPa { get; set; }

    public string? UserActivationIpaddress { get; set; }

    public DateOnly? UserActivationDate { get; set; }

    public int? CustomerIdConversion { get; set; }

    public int? InvoiceCustomerIdConversion { get; set; }

    public int? IdcompanyConversion { get; set; }

    public string? IdonlineUsersConversion { get; set; }

    public bool IsSplitPayment { get; set; }

    public int? PhonzieUserId { get; set; }

    public bool? ForceFiscalCode { get; set; }

    public virtual XpkCustomerCateg CustomerCategNavigation { get; set; } = null!;

    public virtual ICollection<XpkCustomer> InverseInvoiceCustomer { get; set; } = new List<XpkCustomer>();

    public virtual XpkCustomer? InvoiceCustomer { get; set; }

    public virtual AspNetUser? User { get; set; }

    public virtual ICollection<XpkPlateList> XpkPlateLists { get; set; } = new List<XpkPlateList>();

    public virtual ICollection<XpkSpecialContractsCustomer> XpkSpecialContractsCustomers { get; set; } = new List<XpkSpecialContractsCustomer>();
}
