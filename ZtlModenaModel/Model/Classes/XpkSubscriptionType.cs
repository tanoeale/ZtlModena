using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class XpkSubscriptionType
{
    public int SubscriptionType { get; set; }

    public int IdCompany { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Sequence { get; set; }

    public string ColorHexa { get; set; } = null!;

    public string CodePrefix { get; set; } = null!;

    public string CodeSuffix { get; set; } = null!;

    public int NumLength { get; set; }

    public int LastUsedNumber { get; set; }

    public int MaxNumVehicle { get; set; }

    public string IsRechargeable { get; set; } = null!;

    public string IsDehor { get; set; } = null!;

    public string Disabled { get; set; } = null!;

    public DateTime Tbcreated { get; set; }

    public DateTime Tbmodified { get; set; }

    public int TbcreatedId { get; set; }

    public int TbmodifiedId { get; set; }

    public string? IsIdentity { get; set; }

    public string? IsCardCode { get; set; }

    public string? IsRfd { get; set; }

    public string OnWeb { get; set; } = null!;

    public string? PriceByCarLength { get; set; }

    public string? IsManual { get; set; }

    public string? HasPark { get; set; }

    public int? MaxSubscriptions { get; set; }

    public string? ZtlFields { get; set; }

    public string IsEditable { get; set; } = null!;

    public string AllowBackdateSubRenew { get; set; } = null!;

    public string IsFree { get; set; } = null!;

    public string IsSearchable { get; set; } = null!;

    public string? Warnings { get; set; }

    public string? Scope { get; set; }

    public string? HasBadge { get; set; }

    public string IsRenewable { get; set; } = null!;

    public int SubStartDay { get; set; }

    public int DaysBeforeExpiringDate { get; set; }

    public string? IsExpiringWarning { get; set; }

    public string? IsExportToZtlList { get; set; }

    public string? IsTemporary { get; set; }

    public bool IsOnstreet { get; set; }

    public bool IsOffstreetContract { get; set; }

    public int? SubscriptionTypeConversion { get; set; }

    public string? InternalNotes { get; set; }

    public bool PassageWithLicensePlatePermitted { get; set; }

    public int? Tolerance { get; set; }

    public bool IndexAdjustment { get; set; }

    public int? ParkingCode { get; set; }

    public bool IsSpecialContract { get; set; }

    public bool IsRefundable { get; set; }

    public bool IsZtl { get; set; }

    public bool ValidIfExpired { get; set; }

    public int MaxNumVehicleOnline { get; set; }

    public bool? IsAutomaticRenewal { get; set; }

    public bool IsBillable { get; set; }

    public bool IsFsp { get; set; }

    public string? InternalDescription { get; set; }

    public bool IsCarnet { get; set; }

    public bool OnlineValidityFullDay { get; set; }

    public bool BackOfficeValidityFullDay { get; set; }

    public int? AllowRenewalAfterExpirationDays { get; set; }

    public int? StartDateRenewalAfterPaymentDays { get; set; }

    public virtual MsdCompany IdCompanyNavigation { get; set; } = null!;

    public virtual ICollection<XpkSpecialContractsCustomer> XpkSpecialContractsCustomers { get; set; } = new List<XpkSpecialContractsCustomer>();
}
