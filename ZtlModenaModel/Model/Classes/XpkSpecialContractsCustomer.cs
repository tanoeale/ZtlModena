using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class XpkSpecialContractsCustomer
{
    public int IdSccustomer { get; set; }

    public int IdSubscriptionType { get; set; }

    public int IdCustomer { get; set; }

    public virtual XpkCustomer IdCustomerNavigation { get; set; } = null!;

    public virtual XpkSubscriptionType IdSubscriptionTypeNavigation { get; set; } = null!;
}
