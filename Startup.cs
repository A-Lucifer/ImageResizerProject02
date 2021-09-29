﻿using ImageResizeFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ImageResizeFunction.Startup))]
namespace ImageResizeFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Dependancy injection defined by interface and respective class
            builder.Services.AddSingleton<IImageResizer, ImageResizer>();
        }
    }
}