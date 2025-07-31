using _9_Prism_Navigation.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace _9_Prism_Navigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<BannerModule>();
            moduleCatalog.AddModule<NavigationModule>();
        }
    }
}
