using System.Configuration;

namespace TeduShopingOnline.Common.Helpers
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }        
    }
}
