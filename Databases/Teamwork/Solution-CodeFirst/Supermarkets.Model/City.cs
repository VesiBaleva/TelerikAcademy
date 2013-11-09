namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class City : IValidatableObject
    {
        #region Primary Keys
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        private ICollection<Market> markets;
        public virtual ICollection<Market> Markets
        {
            get { return this.markets; }
            private set { this.markets = value; }
        }
        #endregion
        
        #region Constructor
        public City()
        {
            this.Markets = new HashSet<Market>();
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
