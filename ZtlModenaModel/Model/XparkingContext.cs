using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZtlModenaModel.Model.Classes;

namespace ZtlModenaModel.Model;

public partial class XparkingContext : DbContext
{
    private string _connectionString;
    public XparkingContext()
    {
    }
    public XparkingContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public XparkingContext(DbContextOptions<XparkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<AspNetUsersLogin> AspNetUsersLogins { get; set; }

    public virtual DbSet<MsdCompany> MsdCompanies { get; set; }

    public virtual DbSet<XpkCustomer> XpkCustomers { get; set; }

    public virtual DbSet<XpkCustomerCateg> XpkCustomerCategs { get; set; }

    public virtual DbSet<XpkPlateList> XpkPlateLists { get; set; }

    public virtual DbSet<XpkSpecialContractsCustomer> XpkSpecialContractsCustomers { get; set; }

    public virtual DbSet<XpkSubscriptionType> XpkSubscriptionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.Email, "UniqueEmail").IsUnique();

            entity.HasIndex(e => e.UserName, "UniqueUserName").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(128);
            entity.Property(e => e.FiscalCode).HasMaxLength(20);
            entity.Property(e => e.IdcompanyConversion).HasColumnName("IDCompanyConversion");
            entity.Property(e => e.IdonlineUsersConversion)
                .HasMaxLength(128)
                .HasColumnName("IDOnlineUsersConversion");
            entity.Property(e => e.IsImportedConversion).HasDefaultValue(false);
            entity.Property(e => e.Language)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("IT");
            entity.Property(e => e.LastName).HasMaxLength(128);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasIndex(e => new { e.UserId, e.RoleId, e.IdCompany }, "IX_AspNetUserRoles").IsUnique();

            entity.HasIndex(e => new { e.UserId, e.RoleId, e.IdCompany }, "Unique_UtenteRuoloCompany").IsUnique();

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK_AspNetUserRoles_MSD_Companies");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUsersLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers_Logins");

            entity.ToTable("AspNetUsers_Logins");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AccessLogin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Logged).HasDefaultValue((short)0);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUsersLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUsers_AspNetUsers_Logins");
        });

        modelBuilder.Entity<MsdCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).IsClustered(false);

            entity.ToTable("MSD_Companies", tb =>
                {
                    tb.HasTrigger("tr_MSD_Companies_Delete");
                    tb.HasTrigger("tr_MSD_Companies_Insert");
                    tb.HasTrigger("tr_MSD_Companies_Update");
                });

            entity.HasIndex(e => e.Company, "IX_MSD_Companies").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.AdiutoId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AdiutoID");
            entity.Property(e => e.AlternativeLanguage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ApplicationLanguage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CertifiedEmail)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("CertifiedEMail");
            entity.Property(e => e.City)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyCod)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.County)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCodeLengthNav)
                .HasDefaultValue(8)
                .HasColumnName("CustomerCodeLengthNAV");
            entity.Property(e => e.CustomerCodeLengthXpk)
                .HasDefaultValue(8)
                .HasColumnName("CustomerCodeLengthXPK");
            entity.Property(e => e.CustomerCodePrefixNav)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CustomerCodePrefixNAV");
            entity.Property(e => e.CustomerCodePrefixXpk)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CustomerCodePrefixXPK");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionOnline)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("EMail");
            entity.Property(e => e.Fax)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.FiscalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HasCostCenters)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.HasOffStreet).HasDefaultValue(true);
            entity.Property(e => e.Internet)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.IsocountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ISOCountryCode");
            entity.Property(e => e.NavisionCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OnNavision)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.OnParkweb)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.OnWeb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.PersonReference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreferredLanguage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Siacode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SIACode");
            entity.Property(e => e.TaxIdNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telephone1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telephone2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneReference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telex)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.WebSiteUrl)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ZIPCode");
        });

        modelBuilder.Entity<XpkCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("XPK_Customers", tb =>
                {
                    tb.HasTrigger("TUP_XPK_Customer");
                    tb.HasTrigger("XPK_Customers_Insert");
                    tb.HasTrigger("XPK_Customers_Update");
                });

            entity.HasIndex(e => e.CustomerIdConversion, "IX_XPK_CustomerIdConversion");

            entity.HasIndex(e => e.Email, "IX_XPK_Customers");

            entity.HasIndex(e => e.UserId, "IX_XPK_Customers_1");

            entity.HasIndex(e => e.UserName, "IX_XPK_Customers_2");

            entity.HasIndex(e => e.Disabled, "IX_XPK_Customers_3");

            entity.HasIndex(e => e.FiscalCode, "IX_XPK_Customers_4");

            entity.HasIndex(e => e.CustomerType, "IX_XPK_Customers_5");

            entity.HasIndex(e => e.Tbcreated, "IX_XPK_Customers_6");

            entity.HasIndex(e => e.CustomerCode, "IX_XPK_Customers_FirstName_LastName");

            entity.HasIndex(e => e.IdcompanyConversion, "IX_XPK_IdCompanyConversion");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.BornAbroad)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BornCountry)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BornCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BornIsocountryCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("BornISOCountryCode");
            entity.Property(e => e.BornTown)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BornTownCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.County)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DelegateDocumentExpirDate).HasColumnType("datetime");
            entity.Property(e => e.DelegateDocumentNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DelegateDocumentRelFrom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DelivAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DelivCountry)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DelivCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DelivTown)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DelivZipcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DelivZIPCode");
            entity.Property(e => e.Disabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.DocumentExpirDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DocumentRelFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomCountry)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DomCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DomNotes)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetHouseIntNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetHouseNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetHouseSubNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomStreetType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DomTown)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DomWorkingSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DrivingLicExpirDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DrivingLicNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DrivingLicRelFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("EMail");
            entity.Property(e => e.FirstName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FiscalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ForceFiscalCode).HasDefaultValue(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Iban)
                .HasMaxLength(60)
                .HasColumnName("IBAN");
            entity.Property(e => e.IdcompanyConversion).HasColumnName("IDCompanyConversion");
            entity.Property(e => e.IdonlineUsersConversion)
                .HasMaxLength(128)
                .HasColumnName("IDOnlineUsersConversion");
            entity.Property(e => e.InvoiceCustomerCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("1")
                .IsFixedLength();
            entity.Property(e => e.IsGarageOwner)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsManual)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsPa).HasColumnName("IsPA");
            entity.Property(e => e.IsocountryCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ISOCountryCode");
            entity.Property(e => e.LastName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.LeaseExpirDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LeaseNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PartnerFirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PartnerLastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PassSyncDateTime).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Pec)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Region)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.StreetCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StreetHouseIntNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StreetHouseNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StreetHouseSubNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StreetNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StreetType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxIdNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Tbcreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBCreated");
            entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");
            entity.Property(e => e.Tbmodified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBModified");
            entity.Property(e => e.TbmodifiedId)
                .HasDefaultValue(0)
                .HasColumnName("TBModifiedID");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telephone2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Town)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UniqueCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.UserActivationIpaddress)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("UserActivationIPAddress");
            entity.Property(e => e.UserName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UsrCustomerCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ZIPCode");
            entity.Property(e => e.Ztlkey).HasColumnName("ZTLKey");

            entity.HasOne(d => d.CustomerCategNavigation).WithMany(p => p.XpkCustomers)
                .HasForeignKey(d => d.CustomerCateg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XPK_Customers_XPK_CustomerCategs");

            entity.HasOne(d => d.InvoiceCustomer).WithMany(p => p.InverseInvoiceCustomer)
                .HasForeignKey(d => d.InvoiceCustomerId)
                .HasConstraintName("FK_XPK_Customers_CustomerInvoice");

            entity.HasOne(d => d.User).WithMany(p => p.XpkCustomers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_XPK_Customers_AspNetUsers");
        });

        modelBuilder.Entity<XpkCustomerCateg>(entity =>
        {
            entity.HasKey(e => e.CustomerCateg);

            entity.ToTable("XPK_CustomerCategs");

            entity.Property(e => e.CustomerCateg).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Disabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsDefault)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.Tbcreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBCreated");
            entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");
            entity.Property(e => e.Tbmodified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBModified");
            entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
        });

        modelBuilder.Entity<XpkPlateList>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("XPK_PlateList", tb => tb.HasTrigger("TUP_XPK_PlateList"));

            entity.HasIndex(e => e.ExportToList, "IX_ExportToList");

            entity.HasIndex(e => e.FacilityId, "IX_FacilityID");

            entity.HasIndex(e => e.IdCompany, "IX_IDCompany");

            entity.HasIndex(e => e.Plate, "IX_Plate");

            entity.Property(e => e.ArticleCode).HasMaxLength(5);
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.DateModify).HasColumnType("datetime");
            entity.Property(e => e.Dlt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExportToList)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FacilityId).HasColumnName("FacilityID");
            entity.Property(e => e.IsDeleted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsRenewed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Plate).HasMaxLength(12);
            entity.Property(e => e.Tbcreated)
                .HasColumnType("datetime")
                .HasColumnName("TBCreated");
            entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");
            entity.Property(e => e.Tbmodified)
                .HasColumnType("datetime")
                .HasColumnName("TBModified");
            entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            entity.Property(e => e.TypeCode)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.ValidateFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidateTo).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.XpkPlateLists)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("XPK_PlateList_XPK_Customer");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.XpkPlateLists)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XPK_PlateList_MSD_Companies");
        });

        modelBuilder.Entity<XpkSpecialContractsCustomer>(entity =>
        {
            entity.HasKey(e => e.IdSccustomer);

            entity.ToTable("XPK_SpecialContractsCustomers");

            entity.Property(e => e.IdSccustomer).HasColumnName("IdSCCustomer");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.XpkSpecialContractsCustomers)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XPK_SpecialContractsCustomers_XPK_Customers");

            entity.HasOne(d => d.IdSubscriptionTypeNavigation).WithMany(p => p.XpkSpecialContractsCustomers)
                .HasForeignKey(d => d.IdSubscriptionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XPK_SpecialContractsCustomers_XPK_SubscriptionTypes");
        });

        modelBuilder.Entity<XpkSubscriptionType>(entity =>
        {
            entity.HasKey(e => e.SubscriptionType);

            entity.ToTable("XPK_SubscriptionTypes");

            entity.HasIndex(e => new { e.SubscriptionType, e.Disabled, e.IsOnstreet }, "IX_SubscriptionTypes");

            entity.Property(e => e.AllowBackdateSubRenew)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.AllowRenewalAfterExpirationDays).HasColumnName("AllowRenewalAfterExpiration_Days");
            entity.Property(e => e.CodePrefix)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CodeSuffix)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ColorHexa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.Disabled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.HasBadge)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HasPark)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.InternalDescription).HasMaxLength(1024);
            entity.Property(e => e.InternalNotes).HasMaxLength(1024);
            entity.Property(e => e.IsAutomaticRenewal).HasDefaultValue(false);
            entity.Property(e => e.IsBillable).HasDefaultValue(true);
            entity.Property(e => e.IsCardCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isCardCode");
            entity.Property(e => e.IsDehor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsEditable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("1")
                .IsFixedLength();
            entity.Property(e => e.IsExpiringWarning)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsExportToZtlList)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsFree)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsFsp).HasColumnName("IsFSP");
            entity.Property(e => e.IsIdentity)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isIdentity");
            entity.Property(e => e.IsManual)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsOnstreet).HasDefaultValue(true);
            entity.Property(e => e.IsRechargeable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsRenewable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("1")
                .IsFixedLength();
            entity.Property(e => e.IsRfd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isRfd");
            entity.Property(e => e.IsSearchable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.IsTemporary)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsZtl).HasColumnName("IsZTL");
            entity.Property(e => e.MaxSubscriptions).HasDefaultValue(1);
            entity.Property(e => e.OnWeb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.PriceByCarLength)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.ShortDescription).HasMaxLength(100);
            entity.Property(e => e.StartDateRenewalAfterPaymentDays).HasColumnName("StartDateRenewalAfterPayment_Days");
            entity.Property(e => e.Tbcreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBCreated");
            entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");
            entity.Property(e => e.Tbmodified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TBModified");
            entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            entity.Property(e => e.ZtlFields)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.XpkSubscriptionTypes)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XPK_SubscriptionTypes_MSD_Companies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
