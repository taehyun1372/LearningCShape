using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9_Prism_Navigation.Views;

namespace _9_Prism_Navigation
{
    public class MainModule : IModule
    {
        private IRegionManager _regionManager;
        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(MainAView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
