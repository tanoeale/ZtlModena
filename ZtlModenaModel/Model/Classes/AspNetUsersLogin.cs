using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class AspNetUsersLogin
{
    public Guid Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? AccessLogin { get; set; }

    public short? Logged { get; set; }

    public virtual AspNetUser? User { get; set; }
}
