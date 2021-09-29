using System.IO;

namespace ImageResizeFunction.Services
{
    //Interface is used to perform abstraction 
    public interface IImageResizer
    {
        void Resize(Stream input, Stream output);
    }
}