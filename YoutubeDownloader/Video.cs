using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    public class Video
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public Image Thumbnail { get; set; }
    }
}
