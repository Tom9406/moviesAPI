using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Helpers
{
    public static class HttpContextExtentions
    {
        public async static Task InsetParametersPaginationInHeader<T>(this HttpContext httpContext,
            IQueryable<T> queryable)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountRecords", count.ToString());   
        }

    }
}
