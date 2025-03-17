using System.Globalization;

namespace MyRecipeBook.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault()?.Split(',')[0];

            var cultureInfo = new CultureInfo("pt-BR");
            if (!string.IsNullOrWhiteSpace(requestCulture) && supportedLanguages.Any(c => c.Name == requestCulture))
            {
                cultureInfo = new CultureInfo(requestCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
