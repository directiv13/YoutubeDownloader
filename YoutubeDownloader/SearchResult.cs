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
        public SearchResult()
        {
            InitializeComponent();
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {
            foreach (var pictureBox in pictureBoxCollection)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
