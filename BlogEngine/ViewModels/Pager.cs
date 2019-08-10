using System;

namespace BlogEngine.ViewModels
{
    /// <summary>
    /// A Class to Impliment Pagination , The Code is taken from 
    /// https://jasonwatmore.com/post/2015/10/30/aspnet-mvc-pagination-example-with-logic-like-google
    /// </summary>
    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = 1;
            var endPage = pageSize -1;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }

}
