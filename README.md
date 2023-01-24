# Yande.re.Api
Yande.re / konachan.net / lolibooru.moe random picture api 随机色图Api

C# library for getting random images on [yande.re](https://yande.re/post) / [konachan.net](https://konachan.net/post) / [lolibooru.moe](https://lolibooru.moe/post)
一个请求 Yande.re / konachan.net / lolibooru.moe 获取色图的 C# 库

## Usage 如何使用

```C#
        public static async void Main()
        {
            BaseClient client = await YandeClient.CreateNew(); //optional parameter filter by tag  可选 Tag 参数过滤
            //KonachanClient
            //LolibooruClient
            YandeItem item = await client.GetRandom(Rating.Safe);
            string imgUrl = item.BigImgUrl; //Source picture url 大图(原图)URL
            // Or
            foreach (var item in client.PictureList)
            {
                string imgUrl = await item.GetBigImgUrl(); //Source picture url 大图(原图)URL
            }
        }
```

## Installation 如何安装

Install as [NuGet package](https://www.nuget.org/packages/Yande.re.Api/)

使用[NuGet包](https://www.nuget.org/packages/Yande.re.Api/)安装

```powershell
Install-Package Yande.re.Api
```
