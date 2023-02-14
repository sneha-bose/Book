using BooksAPI.Models;

namespace BooksAPI.Repository.Context
{
    public interface IBookRepository
    {
        Task<List<Item>> GetAllKalpanTestPrepBooks();
    }
}
