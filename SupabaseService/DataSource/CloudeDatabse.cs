namespace DesktopApplication.DataSource;

public class CloudeDatabase
{
    public Supabase.Client SupabeseClient { get; private set; }
    public CloudeDatabase(string url, string key)
    {
        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };
        SupabeseClient = new Supabase.Client(url, key, options);
    }
}