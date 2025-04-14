using System.ComponentModel;
        using System.Runtime.CompilerServices;
        using DesktopApplication.Repository;
        
        namespace DesktopApp.Services
        {
            public class AuthService(SupabaseRepository repository) : INotifyPropertyChanged
            {
                private bool _isLoggedIn = repository.IsLoggedIn;
        
                public event PropertyChangedEventHandler? PropertyChanged;

                public bool IsLoggedIn
                {
                    get => _isLoggedIn;
                    set
                    {
                        if (_isLoggedIn != value)
                        {
                            _isLoggedIn = value;
                            OnPropertyChanged("IsLoggedIn");
                        }
                    }
                }
        
                // Login method that updates IsLoggedIn
                public async void Login(string email, string password)
                {
                    await repository.Login(email, password);
                    IsLoggedIn = repository.IsLoggedIn;
                }

                public Task<bool> Register(string username, string password)
                {
                    throw new NotImplementedException();
                }

                public async void Logout()
                {
                    await repository.Logout();
                    IsLoggedIn = repository.IsLoggedIn;
                }

                protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }