using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Models
{
    public class ArgumentOutOfRangeExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException ex)
            {
                context.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/ExceptionOutOfRange.cshtml",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<string>(
                        context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,
                        context.ModelState)
                    {
                        Model = ex.Message
                    }
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is FormatException fex)
            {
                context.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/ExceptionFormat.cshtml",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<System.Exception>(
                        context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,
                        context.ModelState)
                    {
                        Model = fex
                    }
                };
                context.ExceptionHandled = true;
            }
        }
    }
} 