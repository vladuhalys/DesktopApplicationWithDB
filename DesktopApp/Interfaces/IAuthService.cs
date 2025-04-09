namespace DesktopApp.Interfaces;

public interface IAuthService
{
    public bool Login(string username, string password);
    public bool Register(string username, string password);
    public bool Logout();
}