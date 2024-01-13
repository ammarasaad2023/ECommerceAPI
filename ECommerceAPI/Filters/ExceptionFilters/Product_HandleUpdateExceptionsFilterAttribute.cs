using ECommerceAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Filters.ExceptionFilters
{
    public class Product_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strProductId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strProductId, out int productId))
            {
                if (!ProductRepository.ProductExists(productId))
                {
                    context.ModelState.AddModelError("Product", "Product does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
