using System;
using System.Collections.Generic;
using System.Text;

namespace Expertsystem.Adapter.Information
{
    /// <summary>
    /// 资讯数据获取接口
    /// </summary>
    public interface IInformationAdapter
    {
        /// <summary>
        /// 初始化资讯适配器
        /// </summary>
        /// <returns></returns>
        void Initialize(List<InformationAdapterConfig> adapterConfig);
        
    }
}
