using Microsoft.Extensions.DependencyInjection;
using uChatAI.ViewModels;

namespace uChatAI.Services
{
    public class ViewModelLocator
    {
        private static ServiceProvider? _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<AuthorizationViewModel>();
            services.AddSingleton<PageService>();

            _provider = services.BuildServiceProvider();

            foreach (var service in services)
            {
                _provider.GetRequiredService(service.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider!.GetRequiredService<MainViewModel>();

        public AuthorizationViewModel AuthorizationViewModel => _provider!.GetRequiredService<AuthorizationViewModel>();
    }
}
