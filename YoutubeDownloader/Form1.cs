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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            searchResult1.Visible = false;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchResult1.SearchText = textBoxSearch.Text;
            searchResult1.ShowResult();
            searchResult1.Visible = true;
            searchResult1.BringToFront();
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchResult1_Load(object sender, EventArgs e)
        {

        }
    }
}
