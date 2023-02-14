using BooksAPI.Models;
using BooksAPI.Repository.Context;
using System.Text.Json;

namespace BooksAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookRepository> _logger;
        private readonly IConfiguration _configuration;

        public BookRepository(IHttpClientFactory httpClientFactory, 
                                ILogger<BookRepository> logger, 
                                IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }
           
        public Root? Books { get; set; }
        public async Task<List<Item>> GetAllKalpanTestPrepBooks()
        {
            try
            {
                string url = _configuration["ConnectionStrings:GoogleApi"];

                _logger.LogInformation($"Connection string, url: {url}");

                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get, url);

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                _logger.LogInformation("Client is created and requested data from source");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Data returned from source successfully");

                    using var contentStream =
                        await httpResponseMessage.Content.ReadAsStreamAsync();

                    Books = await JsonSerializer.DeserializeAsync<Root>(contentStream);
                    return Books.items;
                }
                else
                {
                    _logger.LogInformation("Unable to fetch data");
                    throw new ApplicationException("Error while getting response from google API");
                }
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, "Reading data from source has thrown exception");
                throw;
            }
        }
    }
}
