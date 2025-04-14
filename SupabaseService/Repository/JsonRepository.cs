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
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }
            string json = File.ReadAllText(filePath);
            var model = JsonConvert.DeserializeObject<SupabaseConfigsModel>(json);
            return model;
        }
        catch (Exception e)
        {
            throw new Exception("Error reading JSON file", e);
        }
    }
}