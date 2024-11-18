using System;
using System.Collections.Generic;

namespace ZtlModenaModel.Model.Classes;

public partial class AspNetUser
{
    public int Id { get; set; }

    public bool IsEnabled { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string UserName { get; set; } = null!;

    public int ChangePassword { get; set; }

    public string? FiscalCode { get; set; }

    public bool IsOnline { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Language { get; set; } = null!;

    public bool? IsImportedConversion { get; set; }

    public string? IdonlineUsersConversion { get; set; }

    public int? IdcompanyConversion { get; set; }

    public int? PhonzieUserId { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();

    public virtual ICollection<AspNetUsersLogin> AspNetUsersLogins { get; set; } = new List<AspNetUsersLogin>();

    public virtual ICollection<XpkCustomer> XpkCustomers { get; set; } = new List<XpkCustomer>();
}
