using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Product_EnsureValidCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;

            if (product != null && !string.IsNullOrWhiteSpace(product.Category))
            {
                // Add category validation logic here
                if (!IsValidCategory(product.Category))
                {
                    return new ValidationResult("Invalid product category.");
                }
            }

            return ValidationResult.Success;
        }

        private bool IsValidCategory(string category)
        {
            // Add your category validation logic here
            // For example, check if the category is one of the allowed categories
            // You can customize this logic based on your requirements
            // For demonstration, let's assume we allow only "Clothing" and "Electronics" categories.
            return string.Equals(category, "Clothing", StringComparison.OrdinalIgnoreCase)
                || string.Equals(category, "Electronics", StringComparison.OrdinalIgnoreCase);
        }
    }
}