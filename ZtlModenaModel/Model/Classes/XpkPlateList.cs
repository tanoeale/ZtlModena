using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class XpkPlateList
{
    public int Code { get; set; }

    public int IdCompany { get; set; }

    public string Plate { get; set; } = null!;

    public int? FacilityId { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime DateModify { get; set; }

    public DateTime Tbcreated { get; set; }

    public DateTime? Tbmodified { get; set; }

    public int TbcreatedId { get; set; }

    public int? TbmodifiedId { get; set; }

    public DateTime? ValidateFrom { get; set; }

    public DateTime? ValidateTo { get; set; }

    public int? CustomerId { get; set; }

    public string? TypeCode { get; set; }

    public string? Dlt { get; set; }

    public string? IsDeleted { get; set; }

    public string? ExportToList { get; set; }

    public int? RefId { get; set; }

    public string? IsRenewed { get; set; }

    public DateTime? CancelDate { get; set; }

    public int? CodeConversion { get; set; }

    public string? ArticleCode { get; set; }

    public int CarParkId { get; set; }

    public virtual XpkCustomer? Customer { get; set; }

    public virtual MsdCompany IdCompanyNavigation { get; set; } = null!;
}
