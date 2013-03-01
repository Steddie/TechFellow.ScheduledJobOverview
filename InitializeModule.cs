﻿using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web.Hosting;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace TechFellow.ScheduledJobOverview
{
    [ModuleDependency(typeof(InitializationModule))]
    [InitializableModule]
    public class InitializeModule : IInitializableModule
    {
        public void Preload(string[] parameters)
        {
        }

        public void Initialize(InitializationEngine context)
        {
#if !ADDON
            GenericHostingEnvironment.Instance.RegisterVirtualPathProvider(new ResourceProvider());

            RouteTable.Routes.Add("ScheduledJobPlugin",
                                  new ModuleRoute("modules/" + Const.ModuleName + "/overview",
                                                  "~/modules/" + Const.ModuleName + "/" + Const.ModuleName + ".overview.aspx"));
#endif
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
