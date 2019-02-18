using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace nettruyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           // progressBar1.Value = 0;
           // progressBar1.Step = 1;

           // for (int j = 0; j < 100; j++)
           // {
            //    System.Threading.Thread.Sleep(100);
           //     progressBar1.PerformStep();
            //}
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            String textLink = txtLink.Text;
            String textImages;

            Regex regex = new Regex(@"^http://www.nettruyen.com/truyen-tranh/", RegexOptions.ECMAScript);

            if (!regex.IsMatch(textLink))
            {
                MessageBox.Show("Link này không được hỗ trợ");
                return;
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(textLink, HttpCompletionOption.ResponseContentRead);
            String html = await response.Content.ReadAsStringAsync();
            var parser = new HtmlWeb();
            txtImages.Visible = true;
        }

    }
}
