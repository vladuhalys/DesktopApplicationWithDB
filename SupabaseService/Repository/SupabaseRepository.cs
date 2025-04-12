using DesktopApplication.DataSource;

namespace DesktopApplication.Repository;

public partial class SupabaseRepository
{
    private CloudeDatabase? CloudeDatabase { get; set; } = null;
    private JsonRepository? JsonRepository { get; set; } = null;
    
    public SupabaseRepository()
    {
        const string filePath = @"../.env/supabase_keys.json";
        try
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
            }
            InitSupabaseClient(filePath);
        }
        catch (Exception e)
        {
            throw new Exception("Error initializing SupabaseRepository", e);
        }
    }
    private async void InitSupabaseClient(string filePath)
    {
        try
        {
            JsonRepository = new JsonRepository(filePath);
            var supabaseConfigs = await JsonRepository.ReadJsonAsync();
            if (supabaseConfigs == null || supabaseConfigs.Url == null || supabaseConfigs.Key == null)
            {
                throw new Exception("Supabase configs are null");
            }
            CloudeDatabase = new CloudeDatabase(supabaseConfigs.Url, supabaseConfigs.Key);
        }
        catch (Exception e)
        {
            throw new Exception("Error initializing Supabase client", e);
        }
        
    }
}