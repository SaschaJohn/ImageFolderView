using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShanuImageFolderView
{

    public partial class Form1 : Form
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        int locX = 20;
        int locY = 10;
        int sizeWidth = 80;
        int sizeHeight = 80;
        List<PictureBox> previews = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }


        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo Folder;
            FileInfo[] Images;
            this.folderBrowserDlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDlg.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);
                Images = Folder.GetFiles();

                pnControls.Controls.Clear();

                int locnewX = locX;
                int locnewY = locY;
                foreach (FileInfo img in Images)
                {

                    if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".gif" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp" || img.Extension.ToLower() == ".tif")
                    {

                        if (locnewX >= pnControls.Width - sizeWidth - 10)
                        {
                            locnewX = locX;
                            locY = locY + sizeHeight + 30;
                            locnewY = locY;
                        }
                        else
                        {

                            locnewY = locY;
                        }

                        loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10;


                    }
                }
            }

        }

        private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY)
        {
            string previousSelectedImage = (string)Properties.Settings.Default["SelectedImage"];
            PictureBox ctrl = new PictureBox();
            ctrl.Image = Image.FromFile(ImageFullName);
            ctrl.BackColor = Color.Black;

            ctrl.Location = new Point(newLocX, newLocY);
            ctrl.Size = new System.Drawing.Size(sizeWidth, sizeHeight);
            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
            ctrl.ImageLocation = ImageFullName;
            if (ImageFullName == previousSelectedImage)
            {
                ctrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
                ctrl.Padding = new System.Windows.Forms.Padding(3);
            }

            ctrl.Click += new EventHandler(control_Click);
            pnControls.Controls.Add(ctrl);
            previews.Add(ctrl);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            locX = 20;
            locY = 10;
            sizeWidth = 80;
            sizeHeight = 80;

            var Folder = new DirectoryInfo("C:\\Users\\Sascha\\Pictures");
            var Images = Folder.GetFiles();

            pnControls.Controls.Clear();

            int locnewX = locX;
            int locnewY = locY;
            foreach (FileInfo img in Images)
            {

                if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".gif" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp" || img.Extension.ToLower() == ".tif")
                {

                    if (locnewX >= pnControls.Width - sizeWidth - 10)
                    {
                        locnewX = locX;
                        locY = locY + sizeHeight + 30;
                        locnewY = locY;
                    }
                    else
                    {

                        locnewY = locY;
                    }

                    loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY);
                    locnewY = locY + sizeHeight + 10;
                    locnewX = locnewX + sizeWidth + 10;


                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            locX = 20;
            locY = 10;
            sizeWidth = 80;
            sizeHeight = 80;
            if (pnControls.Controls.Count > 0)
            {
                loadControls();
            }

        }

        private void loadControls()
        {
            int locnewX = locX;
            int locnewY = locY;

            foreach (Control p in pnControls.Controls)
            {
                if (locnewX >= pnControls.Width - sizeWidth - 10)
                {
                    locnewX = locX;
                    locY = locY + sizeHeight + 30;
                    locnewY = locY;
                }
                else
                {

                    locnewY = locY;
                }
                p.Location = new Point(locnewX, locnewY);
                p.Size = new System.Drawing.Size(sizeWidth, sizeHeight);

                locnewY = locY + sizeHeight + 10;
                locnewX = locnewX + sizeWidth + 10;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 50;
            sizeHeight = 50;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 80;
            sizeHeight = 80;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 120;
            sizeHeight = 120;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }


        private void control_Click(object sender, EventArgs e)
        {
            foreach (var q in previews)
            {

                q.BackColor = System.Drawing.SystemColors.ActiveCaption;
                q.Padding = new System.Windows.Forms.Padding(0);
                q.Refresh();
            }



            PictureBox p = (PictureBox)sender;

            p.BackColor = System.Drawing.SystemColors.ActiveCaption;
            p.Padding = new System.Windows.Forms.Padding(3);
            p.Refresh();
            Properties.Settings.Default["SelectedImage"] = p.ImageLocation;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            return;
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {



            Control control = (Control)sender;
            PictureBox pic = (PictureBox)control;
            pictureBox1.Image = pic.Image;

            if (pictureBox1.Tag == null)
            {
                pictureBox1.Tag = Color.Blue;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.Padding = new Padding(5);
                pictureBox1.Refresh();
                return;
            }

            if ((Color)pictureBox1.Tag == Color.Red) { pictureBox1.Tag = Color.Blue; }
            else { pictureBox1.Tag = Color.Red; }
            pictureBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pnControls.Width, pnControls.Height);
            pnControls.DrawToBitmap(bmp, new Rectangle(0, 0, pnControls.Width, pnControls.Height));
            SaveFileDialog dlg = new SaveFileDialog();
            // dlg.Filter = "JPG Files (*.JPG)|*.JPG";
            dlg.FileName = "*";
            dlg.DefaultExt = "bmp";
            dlg.ValidateNames = true;
            dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dlg.FileName);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 160;
            sizeHeight = 160;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }
    }
}
