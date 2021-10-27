using System.Collections.Generic;
using System.Threading.Tasks;
using Readz.GoogleBooks.Models;

namespace Readz.GoogleBooks
{
    public interface IGoogleBooksService
    {
        Task<List<GoogleBooksItem>> GetAllBooks(string queryString);
    }
}
