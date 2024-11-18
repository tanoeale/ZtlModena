1. Creare variabile: 
	private string _connectionString;

2. Aggiungere costruttore:
	public XparkingContext(string connectionString)
    {
        _connectionString = connectionString;
    }

3. Sostiuire OnConfiguring:
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }


Scaffold-DbContext "Server=SRVDC;Database=XparkingRemove;Persist Security Info=true;User ID=clienti;Password=clienti;TrustServerCertificate=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model/Classes -Context "XparkingContext" -ContextDir "Model" -Tables AspNetRoles, AspNetUserClaims,AspNetUserLogins,AspNetUserRoles,AspNetUsers,AspNetUsers_Logins, MSD_Companies, XPK_CustomerCategs,XPK_Customers,XPK_SubscriptionTypes, XPK_SpecialContractsCustomers,XPK_PlateList   -f