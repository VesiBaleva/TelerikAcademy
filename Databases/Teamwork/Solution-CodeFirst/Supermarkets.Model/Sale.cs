namespace Supermarkets.Model
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class Sale : IValidatableObject
    {
        #region Primary Keys
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        public DateTime Date { get; set; }
        #endregion

        #region Foreign Keys
        public int MarketId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Market Market { get; set; }

        private ICollection<SaleDetail> details;
        public virtual ICollection<SaleDetail> Details
        {
            get { return this.details; }
            private set { this.details = value; }
        }
        #endregion
        
        #region Constructor
        public Sale()
        {
            this.Details = new HashSet<SaleDetail>();
        }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Date > DateTime.Now)
            {
                yield return new ValidationResult("Can't set Date property. It can't be a date in the future.", new[] { "Date" });
            }
        }
        #endregion
    }
}