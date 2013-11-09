namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion

    public class ProductTax : IValidatableObject
    {
        #region Primary Keys
        [Key]
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        public decimal Tax { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Product Product { get; set; }
        #endregion
        
        #region Constructor
        public ProductTax() { }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ( !(0 <= this.Tax && this.Tax <= 1) )
            {
                yield return new ValidationResult("Can't set Tax property. It must be between 0 and 1.", new[] { "Tax" });
            }
        }
        #endregion
    }
}
