using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Custom_RadioGroup_For_Enumeration
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}