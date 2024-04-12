using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expertsystem.Adapter.Information
{
    public class AdapterInfo : IInformationAdapter
    {
        public static AmazonCognitoIdentityProviderClient _cognitoClient;
        public static string _userPoolId;
        public static string _appClientId;
        public static string _serveraddr;
        public void Initialize(List<InformationAdapterConfig> adapterConfig)
        {
            _userPoolId = adapterConfig.FirstOrDefault(_ => _.Key == "userPoolId")?.Value;
            _appClientId = adapterConfig.FirstOrDefault(_ => _.Key == "appClientId")?.Value;
            var region = RegionEndpoint.USEast2;
            _cognitoClient = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), region);
            _serveraddr = adapterConfig.FirstOrDefault(_ => _.Key == "serveraddr")?.Value;
        }
    }
}
