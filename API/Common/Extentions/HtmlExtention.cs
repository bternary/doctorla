using CoreLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.MethodExtensions;

namespace API.Common.Extentions
{
    public static class HtmlExtention
    {
        private static readonly string BasePath;
        private static Dictionary<string, string> ConvertedTags { get; set; } = new Dictionary<string, string>();
        static HtmlExtention()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                IConfiguration config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                BasePath = config["BaseImgPath"];
                //ConvertedTags.Add("p", "div");
            }
        }
        public static string PrepareHtmlToMobile(this string html)
        {
            return html.PrepareHtmlToMobile(BasePath, ConvertedTags);
        }
        public static string AddBasePathToImage(this string imgUri)
        {
            return imgUri.StartsWith("/") ? $"{BasePath}{imgUri}" : imgUri;
        }
    }
}
