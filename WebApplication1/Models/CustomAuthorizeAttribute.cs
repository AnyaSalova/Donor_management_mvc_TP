using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Models
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Проверяем только для GET-запросов
            if (context.HttpContext.Request.Method == "GET")
            {
                var query = context.HttpContext.Request.Query;
                if (query.Count < 2)
                {
                    throw new ArgumentOutOfRangeException("Недостаточно параметров в строке запроса");
                }
                try
                {
                    byte param1 = Convert.ToByte(query["param1"].ToString());
                    ulong param2 = Convert.ToUInt64(query["param2"].ToString());
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"Ошибка конвертации: {ex.Message}");
                }
            }
        }
    }
} 