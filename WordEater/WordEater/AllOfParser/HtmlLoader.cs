using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WordEater.AllOfParser
{
    class HtmlLoader
    {
        readonly HttpClient Client;
        readonly string URL;
        public HtmlLoader(IParserSettings setting, int category)
        {
            Client = new HttpClient();
            if (category == 21)
            {
                URL = $"{setting.BaseURL.Replace("{Category}", category.ToString()).Replace("%D0%B1%D1%83%D0%BA%D0%B2", "буквы")}/{setting.Prefix}/";
            }
            else
            {
                URL = $"{setting.BaseURL.Replace("{Category}", category.ToString())}/{setting.Prefix}/";
            }
        }
        public async Task<string> GetSourceByPage(string pref)
        {
            var currentUrl = URL.Replace("{FirstWord}", pref.ToString());
            var response = await Client.GetAsync(currentUrl);
            string source = null;
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
