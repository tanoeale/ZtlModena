﻿using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
