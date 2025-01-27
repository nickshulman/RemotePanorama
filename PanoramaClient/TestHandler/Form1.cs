using System;
using pwiz.PanoramaClient;


namespace TestHandler
{
    public partial class Form1 : Form
    {
        private RemoteFileDialog dlg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (PanoramaClient.Properties.Settings.Default.user != string.Empty)
            {
                userText.Text = PanoramaClient.Properties.Settings.Default.user;
                passText.Text = PanoramaClient.Properties.Settings.Default.pass;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            dlg = new RemoteFileDialog(userText.Text, passText.Text);
            dlg._user = userText.Text;
            dlg._pass = passText.Text;
            dlg._server = "https://panoramaweb.org";
            PanoramaClient.Properties.Settings.Default.user = userText.Text;
            PanoramaClient.Properties.Settings.Default.pass =passText.Text;
            dlg.ShowDialog();
            
            if (dlg != null && dlg._fileURL != null)
            {
                string file = dlg._fileURL;
                filePath.Text = file;
            }
            if (dlg != null && dlg._folder != null)
            {
                string folder = dlg._folder;
                folderPath.Text = folder;
            }
            
            PanoramaClient.Properties.Settings.Default.Save();
            
        }
    }
}