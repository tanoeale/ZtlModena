using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class XpkCustomerCateg
{
    public int CustomerCateg { get; set; }

    public string Description { get; set; } = null!;

    public int Sequence { get; set; }

    public string IsDefault { get; set; } = null!;

    public string Disabled { get; set; } = null!;

    public DateTime Tbcreated { get; set; }

    public DateTime Tbmodified { get; set; }

    public int TbcreatedId { get; set; }

    public int TbmodifiedId { get; set; }

    public virtual ICollection<XpkCustomer> XpkCustomers { get; set; } = new List<XpkCustomer>();
}
