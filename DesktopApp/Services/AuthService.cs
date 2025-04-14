using System.ComponentModel;
        using System.Runtime.CompilerServices;
        using DesktopApplication.Repository;
        
        namespace DesktopApp.Services
        {
            public class AuthService(SupabaseRepository repository) : INotifyPropertyChanged
            {
                private bool _isLoggedIn = repository.IsLoggedIn;
                private bool _isRegisteredSuccessfully = false;
        
                public event PropertyChangedEventHandler? PropertyChanged;
                
                public bool IsRegisteredSuccessfully
                {
                    get => _isRegisteredSuccessfully;
                    set
                    {
                        if (_isRegisteredSuccessfully != value)
                        {
                            _isRegisteredSuccessfully = value;
                            OnPropertyChanged("IsRegisteredSuccessfully");
                        }
                    }
                }

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

                public async void Register(string email, string password)
                {
                    await repository.Register(email, password);
                    IsRegisteredSuccessfully = true;
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