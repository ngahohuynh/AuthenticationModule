using AuthenticationModule.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationModule.Configs
{
    public static class FilterHelper
    {
        public static void Register(this MvcOptions options)
        {
            options.Filters.Add(typeof(ExceptionHandler));
            options.Filters.Add(typeof(ValidateModelAttribute));
        }
    }
}
