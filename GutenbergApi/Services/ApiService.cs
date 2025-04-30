using GutenbergApi.Models;
using Newtonsoft.Json;

namespace GutenbergApi.Services;

public class ApiService
{
    public HttpClient Client { get; }
    
    public ApiService(HttpClient client)
    {
        Client = client;
        Client.BaseAddress = new Uri(UrlService.BaseUrl);
    }

    public async Task<ListOfBooks> GetAllBooks(int page)
    {
        try
        {
            var response =  await Client.GetAsync(UrlService.ListOfBooksByPage(page));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api error: Status code {response.StatusCode}");
            }
            if (response.Content == null)
            {
                throw new Exception("Api error: No content");
            }
            var json = await response.Content.ReadAsStringAsync();
            var listOfBooks = JsonConvert.DeserializeObject<ListOfBooks>(json);
            if (listOfBooks == null)
            {
                throw new Exception("Api error: No data");
            }
            return listOfBooks;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}