using DesktopApplication.Repository;

namespace DesktopApp.Services;

public class SupabaseService
{
    public SupabaseRepository SupabaseRepository { get; set; }
    
    public SupabaseService()
    {
        SupabaseRepository = new SupabaseRepository();
    }
}