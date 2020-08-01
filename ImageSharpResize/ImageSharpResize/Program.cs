using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Drawing;
using System.IO;

namespace ImageSharpResize
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "00-monkey-sml.png";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            using (Image image = Image.Load(path))
            {
                // Resize the image in place and return it for chaining.
                // 'x' signifies the current image processing context.
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));

                // The library automatically picks an encoder based on the file extension then
                // encodes and write the data to disk.
                // You can optionally set the encoder to choose.
                filename = "monkey.jpg";
                path = Path.Combine(Environment.CurrentDirectory, filename);
                image.Save(path, new JpegEncoder());
            } // Dispose - releasing memory into a memory pool ready for the next image you wish to process.
            
            //Image image = null;
            //using (Bitmap temp = new Bitmap(inputStream))
            //{
            //    image = new Bitmap(temp);
            //}
            //Console.WriteLine("Hello World!");
        }
    }
}
