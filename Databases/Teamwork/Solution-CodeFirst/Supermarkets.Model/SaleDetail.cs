namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion

    public class SaleDetail : IValidatableObject
    {
        #region Primary Keys
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal Sum {
            get { return Quantity * UnitPrice; }
            private set
            {
                //Just need this here to trick EF
            }
        }
        #endregion

        #region Foreign Keys
        public int ProductId { get; set; }

        public int SaleId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Product Product { get; set; }

        public virtual Sale Sale { get; set; }
        #endregion

        #region Constructor
        public SaleDetail() { }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Quantity < 0)
            {
                yield return new ValidationResult("Can't set Quantity property. It must be a positive number or 0.", new[] { "Quantity" });
            }

            if (this.UnitPrice < 0)
            {
                yield return new ValidationResult("Can't set UnitPrice property. It must be a positive number or 0.", new[] { "UnitPrice" });
            }
        }
        #endregion
    }
}
