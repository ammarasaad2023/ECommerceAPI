﻿using ECommerceAPI.Models.Repositories;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Filters.ActionFilters
{
    public class Product_ValidateCreateProductFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var product = context.ActionArguments["product"] as Product;
            if (product == null)
            {
                context.ModelState.AddModelError("Product", "Product object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingProduct = ProductRepository.GetProductByName(product.Name);
                if (existingProduct != null)
                {
                    context.ModelState.AddModelError("Product", "Product with the same name already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
