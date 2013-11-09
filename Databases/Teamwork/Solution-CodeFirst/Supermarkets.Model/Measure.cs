namespace Supermarkets.Model
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion

    public class Measure : IValidatableObject
    {
        #region Primary Keys
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        #endregion

        #region Required Data Properties
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        private ICollection<Product> products;

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            private set { this.products = value; }
        }
        #endregion
        
        #region Constructor
        public Measure()
        {
            this.Products = new HashSet<Product>();
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
