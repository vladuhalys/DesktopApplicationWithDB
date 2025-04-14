using Supabase.Gotrue;

namespace DesktopApplication.Repository;

public partial class SupabaseRepository
{
    public bool IsLoggedIn
    {
        get => CloudeDatabase?.SupabeseClient.Auth.CurrentSession != null;
    }
    public async Task Login(string username, string password)
    {
        await CloudeDatabase?.SupabeseClient.Auth.SignIn(username, password)!;
    }
    
    public async Task<bool> Register(string username, string password)
    {
        throw new NotImplementedException();
    }
    
    public async Task Logout()
    {
        await CloudeDatabase?.SupabeseClient.Auth.SignOut()!;
    }
}