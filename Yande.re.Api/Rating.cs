using System;

namespace Yande.re.Api
{
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
