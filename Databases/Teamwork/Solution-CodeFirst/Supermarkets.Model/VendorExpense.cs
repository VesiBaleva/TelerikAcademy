namespace Supermarkets.Model
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class VendorExpense : IValidatableObject
    {
        #region Primary Keys
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Expense { get; set; }
        #endregion

        #region Foreign Keys        
        public int VendorId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Vendor Vendor { get; set; }
        #endregion

        #region Constructor
        public VendorExpense() { }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Date > DateTime.Now)
            {
                yield return new ValidationResult("Can't set Date property. It can't be a date in the future.", new[] { "Date" });
            }

            if (Expense < 0)
            {
                yield return new ValidationResult("Can't set Expense property. It must be a positive number or 0.", new[] { "Expense" });
            }
        }
        #endregion
    }
}
