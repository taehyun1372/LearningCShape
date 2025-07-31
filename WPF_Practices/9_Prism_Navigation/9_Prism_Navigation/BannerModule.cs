using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using _9_Prism_Navigation.Views;

namespace _9_Prism_Navigation
{
    public class BannerModule : IModule
    {
        private IRegionManager _regionManager;
        public BannerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("BannerRegion", typeof(BannerView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
