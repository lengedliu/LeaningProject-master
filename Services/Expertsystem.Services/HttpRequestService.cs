using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System.IO;
using System.Net;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Expertsystem.Adapter.Information;
using System.Collections.Generic;
using System.Linq;
using Expertsystem.Services.Interfaces;

namespace Expertsystem.Services
{
    public class HttpRequestService : IHttpRequestService,IInformationAdapter
    {
        private  string _serveraddr;
        public Task<string> HttpRequestGetMethod(string headerToken)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_serveraddr);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] =  headerToken; //添加头

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rs = response.GetResponseStream();
                StreamReader sr = new StreamReader(rs, Encoding.UTF8);
                var result = sr.ReadToEnd();
                sr.Close();
                rs.Close();
              
                return Task.FromResult(result); 
            }
            catch (Exception ex)
            {
                return Task.FromResult("-1");
            }
        }

        public Task<string> HttpRequestPostMethod(string headerToken, string strParam)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_serveraddr);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", headerToken); //添加头

                //参数
                byte[] data = Encoding.UTF8.GetBytes(strParam);
                request.ContentLength = data.Length;
                Stream sm = request.GetRequestStream();
                sm.Write(data, 0, data.Length);
                sm.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rs = response.GetResponseStream();
                //StreamReader sr = new StreamReader(rs, encode);
                StreamReader sr = new StreamReader(rs, Encoding.UTF8);
                var result = sr.ReadToEnd();
                sr.Close();
                rs.Close();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult("-1");
            }
        }

        public void Initialize(List<InformationAdapterConfig> adapterConfig)
        {
            _serveraddr = adapterConfig.FirstOrDefault(_ => _.Key == "serveraddr")?.Value;
        }
    }
}
