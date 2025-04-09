using DesktopApplication.Repository;

namespace DesktopApp.Interfaces;

public interface ISupabaseService
{
    public SupabaseRepository SupabaseRepository { get; set; }
}