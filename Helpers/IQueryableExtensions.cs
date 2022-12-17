using MoviesApi.Dto;

namespace MoviesApi.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, paginationDTO paginationDTO)
        {
            return queryable.Skip((paginationDTO.page - 1) * paginationDTO.RecordPerPage)
            .Take(paginationDTO.RecordPerPage);
        }
    }
}
