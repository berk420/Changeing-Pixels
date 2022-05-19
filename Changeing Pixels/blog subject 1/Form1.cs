using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blog_subject_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Bitmap img = new Bitmap(@"C:\Users\berkg\Desktop\Lena.tiff");
            pictureBox1.Image = img;

            int width = img.Width;
            int height = img.Height;
            int stride = width * 4;
            int[,] integers = new int[width, height];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(j, i);

                    byte[] bgra = new byte[] { (byte)pixel.B, (byte)pixel.G, (byte)pixel.R, (byte)pixel.A };
                    integers[i, j] = BitConverter.ToInt32(bgra, 0);


                    //if (pixel == //**Conditions**)
                    //{
                    //    // **Store pixel here in a array or list or whatever**

                    //}
                }
            }
            Bitmap bitmap;
            unsafe
            {
                fixed (int* intPtr = &integers[0, 0])
                {
                    bitmap = new Bitmap(width, height, stride, PixelFormat.Format32bppRgb, new IntPtr(intPtr));
                }
            }



            pictureBox2.Image = bitmap;

        }
    }
}
