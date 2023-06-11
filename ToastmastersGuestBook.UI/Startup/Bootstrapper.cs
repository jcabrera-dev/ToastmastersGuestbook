using Autofac;
using Prism.Events;
using ToastmastersGuestBook.DataAccess;
using ToastmastersGuestBook.UI.Data.Lookups;
using ToastmastersGuestBook.UI.Data.Repositories;
using ToastmastersGuestBook.UI.Data.Respositories;
using ToastmastersGuestBook.UI.View.Services;
using ToastmastersGuestBook.UI.ViewModel;

namespace ToastmastersGuestBook.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

                builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

                builder.RegisterType<GuestDbContext>().AsSelf();
                builder.RegisterType<MainWindow>().AsSelf();
                builder.RegisterType<MainViewModel>().AsSelf();

                builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

                builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
                builder.RegisterType<GuestDetailViewModel>().As<IGuestDetailViewModel>();

                builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
                builder.RegisterType<GuestRespository>().As<IGuestRespository>();
                builder.RegisterType<GuestSigninRepository>().As<IGuestSigninRepository>();

            return builder.Build();
        }
    }
}
