using System;
using System.IO;
using ImageResizeFunction.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ImageResizeFunction
{
    //Define Storage account using BlobConnectionString define in 'local.settings.json' file
    [StorageAccount("BlobConnectionString")]
    public class ImageResizeFunction
    {
        private readonly IImageResizer imageResizer;

        //Initialise instance of IImageResizer interface
        public ImageResizeFunction(IImageResizer imageResizer)
            => this.imageResizer = imageResizer;

        [FunctionName("ImageResizeFunction")]
        public void Run(
            //Blob trigger will take blobpath as parameter and get trigger if any input is given to that path,
            //Blob will take blobpath to where it will store output,
            //Write access of container is given to store image
            [BlobTrigger("original-image/{name}")] Stream inputBlob,
            [Blob("thumbnail-image/{name}", FileAccess.Write)] Stream outputBlob,
            string name,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");

            try
            {
                //passed the streams to Resize method of IImageResizer interface
                this.imageResizer.Resize(inputBlob, outputBlob);

                log.LogInformation("Reduced image saved to blob storage");
            }
            catch (Exception ex)
            {
                log.LogError("Resize fails", ex);
            }
        }
    }
}