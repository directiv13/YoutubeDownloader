using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubeDownloader
{
    class YoutubeVideo
    {
        string URL { get; }
        public YoutubeVideo(string videoId)
        {
            URL = "https://wwww.youtube.com/watch?v=" + videoId;
        }
        //TODO: write this function due 11.09.2020
        public async void Download(DownloadingFormat format, string folderPath)
        {
            try
            {
                var youtube = YouTube.Default;
                var video = await youtube.GetVideoAsync(URL);
                switch (format)
                {
                    case DownloadingFormat.MP3:
                        File.WriteAllBytes(folderPath + @"\" + video.Title + ".mp3", await video.GetBytesAsync());
                        MessageBox.Show("READY");
                        break;
                    case DownloadingFormat.MP4:
                        File.WriteAllBytes(folderPath + @"\" + video.Title + ".mp4", await video.GetBytesAsync());
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public enum DownloadingFormat : byte
        {
            MP3 = 1,
            MP4 = 2
        }
    }
}
