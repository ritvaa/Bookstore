using System.ComponentModel.DataAnnotations;

namespace Bookstore.Api.BindingModels
{
    public class UpdateBookPrice
    {
        [Required]
        // [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

    }
}