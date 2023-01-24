using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Yande.re.Api
{
    /// <summary>
    /// Yande.re 随机色图Api
    /// </summary>
    public abstract class BaseClient
    {
        private readonly bool _https;
        private readonly bool _getBigImg;
        private readonly string? _tag;
        private readonly string? _proxy;
        private int _pageIndex = 0;
        private readonly List<PictureItem> _randomList = new List<PictureItem>();

        /// <summary>
        /// 请求地址
        /// </summary>
        internal abstract string Host { get; }

        /// <summary>
        /// 解析XPath
        /// </summary>
        internal virtual string XPath => "/html/body/div[@id='content']/div[@id='post-list']/div[@class='content']/div[4]/ul[@id='post-list-posts']/li";

        /// <summary>
        /// 当前页面上的所有图片对象列表
        /// </summary>
        public List<PictureItem> PictureList { get; } = new List<PictureItem>();

        internal BaseClient(bool https, bool getBigImg, string? tag, string? proxy)
        {
            _https = https;
            _getBigImg = getBigImg;
            _tag = tag;
            _proxy = proxy;
        }

        /// <summary>
        /// 获取下一页图片列表
        /// </summary>
        /// <returns></returns>
        internal async Task GetNewPictureList()
        {
            _pageIndex++;
            PictureList.Clear();
            _randomList.Clear();
            string tagUrl = "";
            if (!string.IsNullOrWhiteSpace(_tag))
                tagUrl = $"&tags={_tag}";

            HttpClientHandler handler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(_proxy))
            {
                handler.UseProxy = true;
                handler.Proxy = new WebProxy(_proxy);
            }
            using HttpClient client = new HttpClient(handler);
            string url = $@"{(_https ? "https" : "http")}://{Host}/post?page={_pageIndex}{tagUrl}";
            HttpResponseMessage response = await client.GetAsync(url);
            if ((int)response.StatusCode >= 400)
                throw new HttpRequestException($"{(int)response.StatusCode} {response.StatusCode}");
            string html = await response.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection _imageNodes = doc.DocumentNode.SelectNodes(XPath);

            if (_imageNodes == null)
                return;

            for (int i = 0; i < _imageNodes.Count; i++)
            {
                HtmlNode urlNode = _imageNodes[i].SelectSingleNode("div[@class='inner']/a[@class='thumb']");
                HtmlNode thuImgNode = urlNode.SelectSingleNode("img");

                if (thuImgNode == null || !thuImgNode.Attributes.Contains("src") || !urlNode.Attributes.Contains("href"))
                    continue;

                string thuImgUrl = thuImgNode.Attributes["src"].Value;
                string showPageUrl = urlNode.Attributes["href"].Value;
                Dictionary<string, string> dicAlt;

                if (thuImgNode.Attributes.Contains("Alt"))
                {
                    string imgAlt = thuImgNode.Attributes["Alt"].Value;
                    dicAlt = AltStringToDictionary(imgAlt);
                }
                else
                {
                    dicAlt = new Dictionary<string, string>();
                }

                PictureItem yandeItem = new PictureItem(thuImgUrl, showPageUrl, dicAlt, _https, Host, _proxy);
                PictureList.Add(yandeItem);
                _randomList.Add(yandeItem);
            }
            if (_getBigImg)
            {
                await Task.Run(() =>
                {
                    List<Task> getBigImgTasks = new List<Task>();
                    for (int i = 0; i < PictureList.Count; i++)
                        getBigImgTasks.Add(PictureList[i].GetBigImgUrl());
                    Task.WaitAll(getBigImgTasks.ToArray());
                });
            }
        }

        /// <summary>
        /// 提取图片标签文本到集合
        /// </summary>
        internal virtual Dictionary<string, string> AltStringToDictionary(string imgAlt)
        {
            Dictionary<string, string> dicAlt = new Dictionary<string, string>();
            string[] alts = imgAlt.Split(' ');
            string key = string.Empty;
            for (int j = 0; j < alts.Length; j++)
            {
                if (alts[j].EndsWith(":"))
                    key = alts[j][0..^1];
                else
                {
                    if (dicAlt.ContainsKey(key))
                        dicAlt[key] += $" {alts[j]}";
                    else
                        dicAlt.Add(key, alts[j]);
                }
            }
            return dicAlt;
        }

        /// <summary>
        /// 获取一张随机图片
        /// </summary>
        /// <param name="ratingFilter">按评级过滤</param>
        /// <returns></returns>
        public async Task<PictureItem?> GetRandom(Rating ratingFilter = Rating.Any)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            PictureItem yandeItem;
        IL_Reget:;
            if (_randomList.Count == 0 ||  //如果已经获取完本页所有图片, 移动到下一页
               (ratingFilter != Rating.Any && _randomList.Where(p => p.Rating == ratingFilter).Count() == 0))  //如果本页剩下的图片已经不包含过滤的评分, 移动到下一页
            {
                await GetNewPictureList();
                if (PictureList.Count == 0)  //如果已经超过最后一页
                    return null;
            }

            int rdmIndex = rdm.Next(0, _randomList.Count);
            PictureItem randomItem = _randomList[rdmIndex];
            if (ratingFilter == Rating.Any)
            {
                yandeItem = randomItem;
            }
            else
            {
                if ((ratingFilter & randomItem.Rating) != 0)
                    yandeItem = randomItem;
                else
                    goto IL_Reget;
            }
            _randomList.RemoveAt(rdmIndex);
            await yandeItem.GetBigImgUrl();
            return yandeItem;
        }
    }
}
