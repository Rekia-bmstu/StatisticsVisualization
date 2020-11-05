using IrisLab2.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLab2.IoC
{
    class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataManager>().To<DataManager>();
        }
    }
}
