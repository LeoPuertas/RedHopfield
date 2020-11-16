using System;
using System.Collections.Generic;
using System.Drawing;

namespace RedHopfield
{
    public static class ReconocimientoImages
    {
        public static Patron ObtenerPatron(string path)
        {
            Bitmap img = new Bitmap(path);
            return ImagenAPatron(img);
        }

        public static Patron ImagenAPatron(Bitmap image)
        {
            List<int> patron = new List<int>();
            Bitmap grayScale = new Bitmap(image.Width, image.Height);
            for (Int32 y = 0; y < grayScale.Height; y++)
                for (Int32 x = 0; x < grayScale.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    patron.Add(gs == 0 ? 1 : -1);
                }
            return new Patron(patron);
        }
    }
}
