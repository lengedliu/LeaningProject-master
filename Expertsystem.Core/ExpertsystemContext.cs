using Expertsystem.Adapter.Information;
using Expertsystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Expertsystem.Core
{
    public class ExpertsystemContext
    {
        private static IInformationAdapter informationAdapter;
        /// <summary>
        /// 初始化资讯适配器
        /// </summary>
        /// <param name="config"></param>
        /// <param name="webAddr"></param>
        public static void InitInformationAdapter(InfoAdapterConfig config)
        {
            informationAdapter =  new AdapterInfo() as IInformationAdapter;
            informationAdapter.Initialize(config.InformationAdapter.CustomData);
        }
    }
}
