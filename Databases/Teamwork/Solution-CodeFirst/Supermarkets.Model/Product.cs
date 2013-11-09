namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion

    public class Product : IValidatableObject
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

        [Required]
        public decimal BasePrice { get; set; }
        #endregion

        #region Foreign Keys
        public int VendorId { get; set; }

        public int MeasureId { get; set; }

        public int TaxId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Vendor Vendor { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual ProductTax Tax { get; set; }

        private ICollection<SaleDetail> saleDetails;
        public virtual ICollection<SaleDetail> SaleDetails
        {
            get { return this.saleDetails; }
            private set { this.saleDetails = value; }
        }
        #endregion
        
        #region Constructor
        public Product()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Can't set Name property. It must have characters.", new [] { "Name" });
            }

            if (this.BasePrice < 0)
            {
                yield return new ValidationResult("Can't set Base Price property. It must be positive number", new[] { "BasePrice" });
            }
        }
        #endregion
    }
}
