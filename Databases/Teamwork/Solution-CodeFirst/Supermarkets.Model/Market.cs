namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class Market : IValidatableObject
    {
        #region Primary Keys
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        [StringLength(256)]
        public string Address { get; set; }
        #endregion

        #region Foreign Keys
        public int CityId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual City City { get; set; }

        private ICollection<Sale> sales;
        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            private set { this.sales = value; }
        }
        #endregion
        
        #region Constructor
        public Market()
        {
            this.Sales = new HashSet<Sale>();
        }
        #endregion

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Address))
            {
                yield return new ValidationResult("Can't set Address property. It must have characters.", new[] { "Address" });
            }
        }
        #endregion
    }
}