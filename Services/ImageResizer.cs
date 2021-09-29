using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace ImageResizeFunction.Services
{
    //Class ImageResizer will implement interface IImageResizer
    public class ImageResizer : IImageResizer
    {
        public void Resize(Stream input, Stream output)
        {
            //Image class of SixLabors will decode the input image in pixels to perform operation
            using (Image image = Image.Load(input))
            {
                //Mutate the source image by applying the image operation to it
                //Here width and height is reduced 1/2,
                //then save the image by providing stream where we want to save this image,
                //and use encoder to encode back in image format
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                image.Save(output, new JpegEncoder());
            }
        }
    }
}