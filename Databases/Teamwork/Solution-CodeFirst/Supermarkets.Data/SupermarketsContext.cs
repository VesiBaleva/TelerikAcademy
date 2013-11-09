namespace Supermarkets.Data
{
    #region Usings
    using Supermarkets.Model;
    using System.Data.Entity;
    #endregion

    public class SupermarketsContext : DbContext
    {
        #region DBSets (Data Classes)
        public DbSet<City> Cities { get; set; }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTax> ProductTaxes { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleDetail> SaleDetails { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorExpense> VendorExpenses { get; set; }
        #endregion

        #region Constructors
        public SupermarketsContext()
            : base("SupermarketsDB")
        { }
        #endregion       
    }

}
