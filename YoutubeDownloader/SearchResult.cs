using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader
{
    public partial class SearchResult : UserControl
    {
        YoutubeSearchScrapper searchScrapper;
        YoutubeVideo[] youtubeVideos = new YoutubeVideo[6];
        public string SearchText { get; set; }
        public PictureBox[] pictureBoxCollection
        {
            get
            {
                return new PictureBox[] { pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            }
            set
            {
                pictureBoxCollection = value;
            }
        }
        public TextBox[] titleBoxCollection
        {
            get
            {
                return new TextBox[] { title0, title1, title2, title3, title4, title5 };
            }
            set
            {
                titleBoxCollection = value;
            }
        }
        private Button[] audioButtonCollection
        {
            get
            {
                return new Button[] { audioButton0, audioButton1, audioButton2, audioButton3, audioButton4, audioButton5 };
            }
            set
            {
                audioButtonCollection = value;
            }
        }
        private Button[] videoButtonCollection
        {
            get
            {
                return new Button[] { videoButton0, videoButton1, videoButton2, videoButton3, videoButton4, videoButton5 };
            }
            set
            {
                videoButtonCollection = value;
            }
        }
        public SearchResult()
        {
            InitializeComponent();
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {
            foreach (var pictureBox in pictureBoxCollection)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            searchScrapper = new YoutubeSearchScrapper();
        }
        public void ShowResult()
        {
            string htmlQuery = searchScrapper.MakeSearch(SearchText);

            //get thumbnail
            List<string> URLs = searchScrapper.GetImagesURL(htmlQuery);
            for (int i = 0; i < URLs.Count() && i < 6; i++)
            {
                this.pictureBoxCollection[i].ImageLocation = URLs[i];
            }

            //get title
            List<string> titles = searchScrapper.GetTitles(htmlQuery);
            for (int i = 0; i < titles.Count() && i < 6; i++)
            {
                this.titleBoxCollection[i].Text = titles[i];
            }
            //get IDs
            List<string> videosId = searchScrapper.GetVideosId(htmlQuery);
            for (int i = 0; i < videosId.Count() && i < 6; i++)
            {
                this.youtubeVideos[i] = new YoutubeVideo(videosId[i]);
            }

        }
        private void buttonMP3_click(object sender, EventArgs e)
        {
            for (int i = 0; i < audioButtonCollection.Length; i++)
            {
                if (sender.Equals(audioButtonCollection[i]))
                {
                    using (FolderBrowserDialog saveDialog = new FolderBrowserDialog())
                    {
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (youtubeVideos[i] != null)
                            {
                                youtubeVideos[i].Download(YoutubeVideo.DownloadingFormat.MP3, saveDialog.SelectedPath);
                            }
                        }
                    }
                    return;
                }
            }
        }

        private void buttonMP4_click(object sender, EventArgs e)
        {
            for (int i = 0; i < videoButtonCollection.Length; i++)
            {
                if (sender.Equals(videoButtonCollection[i]))
                {
                    using (FolderBrowserDialog saveDialog = new FolderBrowserDialog())
                    {
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (youtubeVideos[i] != null)
                            {
                                youtubeVideos[i].Download(YoutubeVideo.DownloadingFormat.MP4, saveDialog.SelectedPath);
                            }
                        }
                    }
                    return;
                }
            }
        }

    }
}
