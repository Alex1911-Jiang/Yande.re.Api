using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Yande.re.Api
{
    /// <summary>
    /// 一个Yande图片对象
    /// </summary>
    public class YandeItem
    {
        private bool _https = true;
        private const string _not_yet_requested = "Please invoke GetBigImgUrl first!";

        /// <summary>
        /// 大图(原图)地址
        /// </summary>
        public string BigImgUrl { get; private set; } = _not_yet_requested;

        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string ThuImgUrl { get; }

        /// <summary>
        /// 大图展示页面地址
        /// </summary>
        public string ShowPageUrl { get; }

        /// <summary>
        /// 对象的所有属性
        /// </summary>
        public Dictionary<string, string> Alts { get; }

        /// <summary>
        /// 对象的标签
        /// </summary>
        public string[] Tags { get; }

        /// <summary>
        /// 对象的分级
        /// </summary>
        public Rating Rating { get; }

        /// <summary>
        /// Yande图片对象
        /// </summary>
        /// <param name="thuImgUrl">缩略图地址</param>
        /// <param name="showPageUrl">大图展示页面地址</param>
        /// <param name="alts">属性</param>
        /// <param name="https">是否使用https请求大图</param>
        public YandeItem(string thuImgUrl, string showPageUrl, Dictionary<string,string> alts, bool https)
        {
            ThuImgUrl = thuImgUrl;
            ShowPageUrl = showPageUrl;
            Alts = alts;
            _https = https;

            if (alts.ContainsKey("Tags"))
                Tags = alts["Tags"].Split(' ');

            if (alts.ContainsKey("Rating"))
                Rating = Enum.Parse<Rating>(alts["Rating"]);
        }

        /// <summary>
        /// 获取当前对象的大图地址
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetBigImgUrl()
        {
            if (BigImgUrl == _not_yet_requested)
            {
                string bigImgPageUrl = $"{(_https ? "https" : "http")}://yande.re{ShowPageUrl}";
                using (HttpClient itemClient = new HttpClient())
                {
                    try
                    {
                        var itemResponse = await itemClient.GetAsync(bigImgPageUrl);
                        string itemHtml = await itemResponse.Content.ReadAsStringAsync();

                        HtmlDocument docItem = new HtmlDocument();
                        docItem.LoadHtml(itemHtml);
                        string xpathItem = "/html/body/div[@id='content']/div[@id='post-view']/div[@class='content']/div/img";
                        HtmlNode bigImgNode = docItem.DocumentNode.SelectSingleNode(xpathItem);
                        BigImgUrl = bigImgNode.Attributes["src"].Value;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return BigImgUrl;
        }
    }
}
