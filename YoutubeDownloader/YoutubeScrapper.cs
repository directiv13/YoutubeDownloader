using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace YoutubeDownloader
{
    class YoutubeScrapper : IScrapper
    {
        readonly string thumbnailPattern = @"(\s*\W)videoRenderer(\W):\s*{(\W)videoId(\W):(\W)(\S*)(\W),(\s*\W)thumbnail(\W):\s*{(\W)thumbnails(\W\s*):\s*\[{(\W)url(\W):(\s*\W)(?<URL>\S*)(\W),(\s*\W)width(\W):168,(\s*\W)height(\W):94}";
        readonly string videoPattern = @"{\u0022webCommandMetadata\u0022:{\u0022url\u0022:\u0022\/watch\?v=(?<VIDEO>\S*)\u0022,\u0022webPageType\u0022:\u0022WEB_PAGE_TYPE_WATCH\u0022,\u0022rootVe\u0022:3822}},";
        readonly string titlePattern = @"\u0022title\u0022:\W*{\u0022runs\u0022:\W*\[{\u0022text\u0022:\W*\u0022(?<TITLE>[\S \w \-&,\.?%№#|()—]{0,})(\u0022}\],)";
        public string MakeSearch(string searchText)
        {
            //Change symbols to their UTF-8(hex.) code
            if (searchText.Contains(" "))
                searchText = searchText.Replace(' ', '+');
            if (searchText.Contains("'"))
                searchText = searchText.Replace("'", "%27");
            if (searchText.Contains("+"))
                searchText = searchText.Replace("+", "%2B");
            if (searchText.Contains("#"))
                searchText = searchText.Replace("#", "%23");

            String htmlQuery;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.youtube.com/results?search_query=" + searchText);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    htmlQuery = reader.ReadToEnd();
            }

            return htmlQuery;
        }
        public List<string> GetImagesURL(string htmlQuery)
        {
            var regex = new Regex(thumbnailPattern);

            List<string> imgUrls = new List<string>(6);
            int i = 0;
            for (var m = regex.Match(htmlQuery); m.Success && i < 6; m = m.NextMatch(), i++)
            {
                imgUrls.Add(m.Groups["URL"].ToString());
            }

            return imgUrls;
        }
        public List<string> GetTitles(string htmlQuery)
        {
            var regex = new Regex(titlePattern);

            List<string> titles = new List<string>(6);
            int i = 0;
            for (var m = regex.Match(htmlQuery); m.Success && i < 6; m = m.NextMatch(), i++)
            {
                titles.Add(m.Groups["TITLE"].ToString());
            }

            return titles;
        }
        //Actually, these aren't URLs, but unique part of https://wwww.youtube.com/watch?v=OUR_RESULT
        public List<string> GetVideosURL(string htmlQuery)
        {
            var regex = new Regex(videoPattern);

            List<string> videosUrl = new List<string>();
            int i = 0;
            for (var m = regex.Match(htmlQuery); m.Success && i < 6; m = m.NextMatch(), i++)
                videosUrl.Add(m.Groups["VIDEO"].ToString());

            return videosUrl;
        }
    }
}
