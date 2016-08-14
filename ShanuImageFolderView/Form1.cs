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
        int locX = 20;
        int locY = 10;
        int sizeWidth = 80;
        int sizeHeight = 80;
        List<PictureBox> previews = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            ctrl.Click += new EventHandler(image_Click);
            pnControls.Controls.Add(ctrl);
            previews.Add(ctrl);
        }

        private void image_Click(object sender, EventArgs e)
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
    }
}
