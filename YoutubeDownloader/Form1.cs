using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        YoutubeScrapper scrapper;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scrapper = new YoutubeScrapper();
            searchResult1.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string htmlQuery = scrapper.MakeSearch(textBoxSearch.Text);

            //get thumbnail
            List<string> URLs = scrapper.GetImagesURL(htmlQuery);
            for (int i = 0; i < URLs.Count() && i < 6; i++)
            {
                searchResult1.pictureBoxCollection[i].ImageLocation = URLs[i];
            }

            //get title
            List<string> titles = scrapper.GetTitles(htmlQuery);
            for (int i = 0; i < titles.Count() && i < 6; i++)
            {
                searchResult1.titleBoxCollection[i].Text = titles[i];
            }

            searchResult1.Visible = true;
            searchResult1.BringToFront();
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
