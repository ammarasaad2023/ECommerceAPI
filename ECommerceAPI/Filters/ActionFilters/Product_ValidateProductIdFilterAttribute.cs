using ECommerceAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Filters.ActionFilters
{
    public class Product_ValidateProductIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var productId = context.ActionArguments["id"] as int?;
            if (productId.HasValue)
            {
                if (productId.Value <= 0)
                {
                    context.ModelState.AddModelError("ProductId", "ProductId is invalid.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if (!ProductRepository.ProductExists(productId.Value))
                {
                    context.ModelState.AddModelError("ProductId", "ProductId does not exist.");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}