using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Yande.re.Api
{
    /// <summary>
    /// Yande.re 随机色图Api
    /// </summary>
    public class YandeApi
    {
        private string _tag = null;
        private bool _https = true;
        private bool _getBigImg = false;
        private int _pageIndex = 0;
        private List<YandeItem> _randomList = new List<YandeItem>();

        /// <summary>
        /// 当前页面上的所有图片对象列表
        /// </summary>
        public List<YandeItem> PictureList { get; } = new List<YandeItem>();

        /// <summary>
        /// 构造一个Yande请求实例, 构造函数中已获取图片列表页面数据
        /// </summary>
        /// <param name="https">是否https请求</param>
        /// <param name="getBigImgUrl">是否同时获取大图地址(请注意网络并发量)</param>
        /// <param name="tag">搜索的标签</param>
        /// <returns></returns>
        public static async Task<YandeApi> CreateNew(bool https = true, bool getBigImgUrl = false, string tag = null)
        {
            YandeApi yandeApi = new YandeApi(https, getBigImgUrl, tag);
            await yandeApi.GetNewPictureList();
            return yandeApi;
        }

        private YandeApi(bool https, bool getBigImg, string tag)
        {
            _https = https;
            _getBigImg = getBigImg;
            _tag = tag;
        }

        private async Task GetNewPictureList()
        {
            _pageIndex++;
            PictureList.Clear();
            _randomList.Clear();
            string tagUrl = "";
            if (!string.IsNullOrWhiteSpace(_tag))
                tagUrl = $"&tags={_tag}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($@"{(_https ? "https" : "http")}://yande.re/post?page={_pageIndex}{tagUrl}");
                string html = await response.Content.ReadAsStringAsync();

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string xpath = "/html/body/div[@id='content']/div[@id='post-list']/div[@class='content']/div[4]/ul[@id='post-list-posts']/li";
                HtmlNodeCollection _imageNodes = doc.DocumentNode.SelectNodes(xpath);

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
                    Dictionary<string, string> dicAlt = new Dictionary<string, string>();

                    if (thuImgNode.Attributes.Contains("Alt"))
                    {
                        string imgAlt = thuImgNode.Attributes["Alt"].Value;
                        string[] alts = imgAlt.Split(' ');
                        string key = string.Empty;
                        for (int j = 0; j < alts.Length; j++)
                        {
                            if (alts[j].EndsWith(":"))
                                key = alts[j];
                            else
                            {
                                if (dicAlt.ContainsKey(key))
                                    dicAlt[key] += $" {alts[j]}";
                                else
                                    dicAlt.Add(key, alts[j]);
                            }
                        }
                    }

                    YandeItem yandeItem = new YandeItem(thuImgUrl, showPageUrl, dicAlt, _https);
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
        }

        /// <summary>
        /// 获取一张随机图片
        /// </summary>
        /// <param name="ratingFilter">按评级过滤</param>
        /// <returns></returns>
        public async Task<YandeItem> GetRandom(Rating ratingFilter = Rating.Any)
        {
            Random rdm = new Random();
            YandeItem yandeItem;
        IL_Reget:;
            if (_randomList.Count == 0 ||  //如果已经获取完本页所有图片, 移动到下一页
               (ratingFilter != Rating.Any && _randomList.Where(p => p.Rating == ratingFilter).Count() == 0))  //如果本页剩下的图片已经不包含过滤的评分, 移动到下一页
            {
                await GetNewPictureList();
                if (PictureList.Count == 0)  //如果已经超过最后一页
                    return null;
            }

            int rdmIndex = rdm.Next(0, _randomList.Count);
            YandeItem randomItem = _randomList[rdmIndex];
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

    /// <summary>
    /// 评级
    /// </summary>
    [Flags]
    public enum Rating
    {
        /// <summary>
        /// 安全的(全年龄)
        /// </summary>
        Safe = 1,
        /// <summary>
        /// 可疑的(可能是色图, 也可能不是)
        /// </summary>
        Questionable = 2,
        /// <summary>
        /// R-18
        /// </summary>
        Explicit = 4,
        /// <summary>
        /// 任意
        /// </summary>
        Any = Safe | Questionable | Explicit,
    }
}
