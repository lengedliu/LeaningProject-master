using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Expertsystem.Adapter.Information
{
    public class InformationAdapterConfig
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
    public class InfoAdapterConfig
    {
        public InfoAdapterConfig()
        {
            InformationAdapter = new Adapter();
        }
        public Adapter InformationAdapter { get; set; }
        public static InfoAdapterConfig Load(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("资讯适配器配置文件不存在!");
            }
            try
            {
                InfoAdapterConfig result = new InfoAdapterConfig();
                XElement xe = XElement.Load(configFile);
                //适配层配置加载
                if (xe.Element("Adapter") != null)
                {
                    result.InformationAdapter = new Adapter();
                    Adapter adapter = null;
                    foreach (XElement item in xe.Elements("Adapter"))
                    {

                        adapter = new Adapter();
                        //客户自定义数据
                        adapter.CustomData = new List<InformationAdapterConfig>();
                        if (item.Element("AdapterConfig") != null)
                        {
                            foreach (XElement customDataXe in item.Element("AdapterConfig").Elements("Config"))
                            {
                                adapter.CustomData.Add(new InformationAdapterConfig()
                                {
                                    Key = customDataXe.Attribute("key").Value,
                                    Value = customDataXe.Attribute("value").Value
                                });
                            }
                        }

                        result.InformationAdapter = adapter;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("解析资讯适配器配置文件出错：" + ex);
            }
        }
    }
    /// <summary>
    /// 适配层配置类
    /// </summary>
    public class Adapter
    {
        /// <summary>
        /// 初始化 Adapter类的实例
        /// </summary>
        public Adapter()
        { }

        /// <summary>
        /// 客户自定义数据
        /// </summary>
        public List<InformationAdapterConfig> CustomData { get; set; }
    }
}
