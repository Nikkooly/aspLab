using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneRepository;
using Ninject.Web.Common;

namespace NinjectModules
{
    class PhoneNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<PhonesRepository>().InTransientScope();
            //Bind<IPhoneDictionary>().To<PhonesRepository>().InSingletonScope();
            //Bind<IPhoneDictionary>().To<PhonesRepository>().InRequestScope();
        }
    }
}
