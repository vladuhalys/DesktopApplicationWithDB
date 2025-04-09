using DesktopApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesktopApp.Services;

public class AuthService : IAuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly ISupabaseService _supabaseServiceImplementation;

    public AuthService(ILogger<AuthService> logger, ISupabaseService supabaseService)
    {
        _supabaseServiceImplementation = supabaseService;
        _logger = logger;
        _logger.LogInformation("AuthService initialized");
    }

    public bool Login(string username, string password)
    {
        _logger.LogInformation("Logging in user: {Username}", username);
         return _supabaseServiceImplementation.SupabaseRepository.Login(username, password);
    }

    public bool Register(string username, string password)
    {
        _logger.LogInformation("Register user: {Username}", username);
        return _supabaseServiceImplementation.SupabaseRepository.Register(username, password);
    }

    public bool Logout()
    {
        _logger.LogInformation($"Logging out {DateTime.Now.ToLocalTime()}");
        return _supabaseServiceImplementation.SupabaseRepository.Logout();
    }
}