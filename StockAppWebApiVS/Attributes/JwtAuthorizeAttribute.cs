using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Filters;

namespace StockAppWebApiVS.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter)) { }

    }
}
