namespace CityInfo.API.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPageNumber {get;set;}

        public PaginationMetadata(int totalItemCount,  int pageSize, int currentPageCount)
        {
            TotalItemCount = totalItemCount;
            CurrentPageNumber = currentPageCount;
            PageSize = pageSize;
            TotalPageCount = (int)Math.Ceiling((double)(TotalItemCount/PageSize));        
        }
    
    
    }


}
