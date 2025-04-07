namespace DesktopApplication.DataSource;

public class CloudeDatabase
{
    public Supabase.Client SupabeseClient { get; private set; }
    
    public SupabaseClient()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        SupabeseClient = new Supabase.Client(url, key, options);
    }
}