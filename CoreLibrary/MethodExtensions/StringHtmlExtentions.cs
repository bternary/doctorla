using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLibrary.MethodExtensions
{
    public static class StringHtmlExtentions
    {
        public static string ChangeImagePath(this string html, string basepath)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//img");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var src = node.Attributes[@"src"].Value;
                    if (src.StartsWith("/"))
                        node.SetAttributeValue("src", $"{basepath}{src}");
                }
            }
            string result = htmlDoc.DocumentNode.WriteTo();
            return result;
        }
        public static string RemoveCustomStyles(this string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            foreach (var eachNode in htmlDoc.DocumentNode.Descendants().Where(x => x.NodeType == HtmlNodeType.Element && x.Attributes.Any(p => p.Name == "class" || p.Name == "style")))
            {
                eachNode.Attributes.Remove("class");
                eachNode.Attributes.Remove("style");
            }
            string result = htmlDoc.DocumentNode.WriteTo();
            return result;
        }

        public static string ConvertHtmlTag(this string html, string tag, string newtag)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var query = htmlDoc.DocumentNode.Descendants(tag);
            foreach (var item in query.ToList())
            {
                item.Name = newtag;
            }
            string result = htmlDoc.DocumentNode.WriteTo();
            return result;

        }
        public static string PrepareHtmlToMobile(this string html, string basepath, Dictionary<string, string> convertedTags)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (htmlDoc == null)
            {
                return string.Empty;
            }

            var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img");
            if (imgNodes != null)
            {
                foreach (var node in imgNodes)
                {
                    var src = node.Attributes[@"src"].Value;
                    if (src.StartsWith("/"))
                        node.SetAttributeValue("src", $"{basepath}{src}");
                }
            }

            var eachNodes = htmlDoc.DocumentNode.Descendants().Where(x => x.NodeType == HtmlNodeType.Element && x.Attributes.Any(p => p.Name == "class" || p.Name == "style"));
            if (eachNodes != null)
            {
                foreach (var eachNode in eachNodes)
                {
                    eachNode.Attributes.Remove("class");
                    eachNode.Attributes.Remove("style");
                }
            }

            if (convertedTags != null)
            {
                foreach (KeyValuePair<string, string> item in convertedTags)
                {
                    var query = htmlDoc.DocumentNode.Descendants(item.Key);
                    foreach (var item1 in query.ToList())
                    {
                        item1.Name = item.Value;
                    }
                }
            }            
            
            string result = htmlDoc.DocumentNode.WriteTo();

            return result;
        }

    }
}
