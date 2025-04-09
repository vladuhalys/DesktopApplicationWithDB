using DesktopApp.Interfaces;
using DesktopApplication.Repository;

namespace DesktopApp.Services;

public class SupabaseService : ISupabaseService
{
    public SupabaseRepository SupabaseRepository { get; set; }
    
    public SupabaseService()
    {
        SupabaseRepository = new SupabaseRepository();
    }
}