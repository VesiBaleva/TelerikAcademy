namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion

    public class Vendor : IValidatableObject
    {
        #region Primary Keys
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        private ICollection<Product> products;
        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            private set { this.products = value; }
        }


        private ICollection<VendorExpense> expenses;
        public virtual ICollection<VendorExpense> Expenses
        {
            get { return this.expenses; }
            private set { this.expenses = value; }
        }
        #endregion
        
        #region Constructor
        public Vendor()
        {
            this.Products = new HashSet<Product>();

            this.Expenses = new HashSet<VendorExpense>();
        }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Can't set Name property. It must have characters.", new[] { "Name" });
            }
        }
        #endregion
    }
}