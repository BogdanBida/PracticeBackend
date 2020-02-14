using ProductApp.DAL.Constants;

namespace ProductApp.DAL.Paging
{
    public class ProductPagingParams
    {
        const int maxPageSize = 100;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public SortState SortOrder { get; set; } = SortState.NameAsc;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
