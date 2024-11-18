using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class AspNetUserRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public int? IdCompany { get; set; }

    public virtual MsdCompany? IdCompanyNavigation { get; set; }

    public virtual AspNetRole Role { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
