using DesktopApplication.Models;
using Newtonsoft.Json;

namespace DesktopApplication.Repository;

public class JsonRepository(string filePath)
{
    private string FilePath { get; set; } = filePath;
    public async Task<SupabaseConfigsModel?> ReadJsonAsync()
    {
        try
        {
            using StreamReader reader = new StreamReader(FilePath);
            string json = await reader.ReadToEndAsync();
            var model = JsonConvert.DeserializeObject<SupabaseConfigsModel>(json);
            return model;
        }
        catch (Exception e)
        {
            throw new Exception("Error reading JSON file", e);
        }
    }
}