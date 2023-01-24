using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yande.re.Api
{
    /// <summary>
    /// Lolibooru 随机色图Api
    /// </summary>
    public class Lolibooru : BaseClient
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        internal override string Host => "lolibooru.moe";

        /// <summary>
        /// 解析XPath
        /// </summary>
        internal override string XPath => "/html/body/div[@id='content']/div[@id='post-list']/div[@class='content']/div[5]/ul[@id='post-list-posts']/li";

        /// <summary>
        /// 构造一个Lolibooru请求实例, 构造函数中已获取图片列表页面数据
        /// </summary>
        /// <param name="https">是否https请求</param>
        /// <param name="getBigImgUrl">是否同时获取大图地址(请注意网络并发量)</param>
        /// <param name="tag">搜索的标签（为null或空字符串时不进行搜索）</param>
        /// <param name="proxy">代理地址（为null或空字符串时不使用代理）</param>
        /// <returns></returns>
        public static async Task<Lolibooru> CreateNew(bool https = true, bool getBigImgUrl = false, string? tag = null, string? proxy = null)
        {
            Lolibooru lolibooruClient = new Lolibooru(https, getBigImgUrl, tag, proxy);
            await lolibooruClient.GetNewPictureList();
            return lolibooruClient;
        }

        private Lolibooru(bool https, bool getBigImg, string? tag, string? proxy) : base(https, getBigImg, tag, proxy)
        {
        }

        internal override Dictionary<string, string> AltStringToDictionary(string imgAlt)
        {
            Dictionary<string, string> dicAlt = new Dictionary<string, string>();
            string[] altsAndTags = imgAlt.Split("\r\n").Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            string[] alts = altsAndTags[0].Split(" | ");
            string key = string.Empty;
            if (alts.Length > 2)
            {
                dicAlt.Add("Id", alts[0]);
                dicAlt.Add("Rating", alts[1]);
            }
            for (int j = 0; j < alts.Length; j++)
            {
                if (alts[j].Contains(":"))
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
            }
            dicAlt.Add("Tags", altsAndTags[1]);
            return dicAlt;
        }
    }
}
