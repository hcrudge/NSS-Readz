using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Readz.GoogleBooks.Models;
using System.Web;

namespace Readz.GoogleBooks
{
    public class GoogleBooksService : IGoogleBooksService
    {
       
        private const string GOOGLE_BOOKS_QUERY_BASE_URL =
            "https://www.googleapis.com/books/v1/volumes?q=";


        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _firebaseApiKey;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        //constructor:
        public GoogleBooksService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            // analagous to the FetchAPI (like our managers in React)
            // library to make http requests from the application (in the system.net.http library)

            _httpClientFactory = httpClientFactory;

            //grab from appsettings.json
            _firebaseApiKey = configuration.GetValue<string>("FirebaseApiKey");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<GoogleBooksItem>> GetAllBooks(string queryString)
        {
            //store an instance of HTTPClient in the variable 
            var client = _httpClientFactory.CreateClient();

            //concatenating the baseUrl, encoded querystring param,
            //"&key=, and the firebaseApi
            //encoded here rather than in the request variable below to return the correct format.
            var url = GOOGLE_BOOKS_QUERY_BASE_URL + HttpUtility.UrlEncode(queryString) + "&key=" + _firebaseApiKey;

            //Http Get method
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            // waits for the response from GoogleBooks and stores it in the variable
            var response = await client.SendAsync(request);

            //waits for the response and turns the HTTP response into a string  
            var content = await response.Content.ReadAsStringAsync();

            //parses the response into an instance of type GooglebooksResponse
            var googleBooksResponse = 
                JsonSerializer.Deserialize<GoogleBooksResponse>(content, _jsonSerializerOptions);

            return googleBooksResponse.Items;
        }
        

    }
}
