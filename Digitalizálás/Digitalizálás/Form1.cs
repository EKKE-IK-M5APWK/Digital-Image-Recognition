namespace Digitalizálás
{
    public partial class Form1 : Form
    {
        Bitmap sourceimage;
        Bitmap targetimage;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Load("lena.tif"); //a kép betöltése
            sourceimage = new Bitmap("lena.tif");  //létrehozzuk a forrásképet tároló változót, ami egy Bitmap típusú objektum
            targetimage = new Bitmap(sourceimage.Width, sourceimage.Height); //Ugyanakkor méretű Bitmap változó az eredménynek
        }

        private void button1_Click(object sender, EventArgs e)
        {
            greyscale();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetInvert();
        }
        public void SetInvert()
        {
            Color pxl;
            for (int i = 0; i < sourceimage.Width; i++)
            {
                for (int j = 0; j < sourceimage.Height; j++)
                {
                    pxl = sourceimage.GetPixel(i, j);
                    targetimage.SetPixel(i, j, Color.FromArgb(255 - pxl.R, 255 - pxl.G, 255 - pxl.B));
                }
            }
            targetimage.Save("lenarinv.png");
            pictureBox2.Image = targetimage;
        }

        public void greyscale()
        {
            int grayScale;
            for (int x = 0; x < sourceimage.Width; x++)
            {
                for (int y = 0; y < sourceimage.Height; y++)
                {
                    Color pxl = sourceimage.GetPixel(x, y);

                    grayScale = (int)((pxl.R * 0.3) + (pxl.G * 0.59) + (pxl.B * 0.11));
                    Color nc = Color.FromArgb(pxl.A, grayScale, grayScale, grayScale);
                    targetimage.SetPixel(x, y, nc);
                }
            }
            targetimage.Save("lenaresult.png");  //mentés
            pictureBox2.Image = targetimage;  // hogy látszódjon a formon
        }

      
    }
}