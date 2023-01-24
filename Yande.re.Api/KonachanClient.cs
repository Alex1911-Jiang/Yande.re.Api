using System.Threading.Tasks;

namespace Yande.re.Api
{
    /// <summary>
    /// Konachan 随机色图Api
    /// </summary>
    public class KonachanClient : BaseClient
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        internal override string Host => "konachan.net";

        /// <summary>
        /// 构造一个Yande请求实例, 构造函数中已获取图片列表页面数据
        /// </summary>
        /// <param name="https">是否https请求</param>
        /// <param name="getBigImgUrl">是否同时获取大图地址(请注意网络并发量)</param>
        /// <param name="tag">搜索的标签（为null或空字符串时不进行搜索）</param>
        /// <param name="proxy">代理地址（为null或空字符串时不使用代理）</param>
        /// <returns></returns>
        public static async Task<KonachanClient> CreateNew(bool https = true, bool getBigImgUrl = false, string? tag = null, string? proxy = null)
        {
            KonachanClient konachanClient = new KonachanClient(https, getBigImgUrl, tag, proxy);
            await konachanClient.GetNewPictureList();
            return konachanClient;
        }

        private KonachanClient(bool https, bool getBigImg, string? tag, string? proxy) : base(https, getBigImg, tag, proxy)
        {
        }
    }
}
