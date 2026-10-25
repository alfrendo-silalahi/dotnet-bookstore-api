using BookStoreApi.Data;
using BookStoreApi.Models;
using Dapper;

namespace BookStoreApi.Services;

public class BookService(
    IDbConnectionFactory connectionFactory,
    ILogger<BookService> logger
)
{
    public async Task<IEnumerable<Book>> GetBooks()
    {
        logger.LogInformation("Get books from database.");
        using var conn = connectionFactory.Create();
        const string sql = """
            SELECT Id, Title, Author, Price, CreatedAt
            FROM Books
            """;
        return await conn.QueryAsync<Book>(sql);
    }

    public async Task<Book?> GetBook(int id)
    {
        logger.LogInformation("Get book with id {Id} from database.", id);
        using var conn = connectionFactory.Create();
        const string sql = """
            SELECT Id, Title, Author, Price, CreatedAt
            FROM Books
            WHERE Id = @Id
            """;
        return await conn.QuerySingleAsync<Book>(sql, new { Id = id });
    }
}