using System.Windows.Forms;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace DesktopApp.ViewModels;

public class SignInViewModel
{
    public ICommand SignInCommand { get; }
    private readonly ILogger<SignInViewModel> _logger;
    
    public SignInViewModel(ILogger<SignInViewModel> logger)
    {
        _logger = logger;
        SignInCommand = new AsyncRelayCommand(OnSignIn);
    }
    
    private Task OnSignIn()
    {
        //TODO: Implement the sign-in logic here
        MessageBox.Show("Sign-in logic not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        _logger.LogInformation($"SignInCommand executed [{DateTime.Now.ToLocalTime()}]");
        return Task.CompletedTask;
    }
}