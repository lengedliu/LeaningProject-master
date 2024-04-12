using Expertsystem.Adapter.Information;

namespace Expertsystem.infomationAdapter.Impl
{
    public class EImplement : IInformationAdapter
    {
        private string _userPoolId;
        private string _appClientId;
        /// <summary>
        /// 初始化适配器
        /// </summary>
        /// <returns></returns>
        public void Initialize(List<InformationAdapterConfig> adapterConfig)
        {
            _userPoolId = adapterConfig.FirstOrDefault(_ => _.Key == "userPoolId")?.Value;
            _appClientId = adapterConfig.FirstOrDefault(_ => _.Key == "appClientId")?.Value;

        }

    }
}
