using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    interface IScrapper
    {
        List<string> GetImagesURL(string htmlQuery);
        string MakeSearch(string searchText);
    }
}
