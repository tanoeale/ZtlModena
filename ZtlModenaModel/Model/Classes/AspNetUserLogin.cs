using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public int UserId { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
