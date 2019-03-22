using System;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using ThumbnailSharp;

/*Reference: https://github.com/mirzaevolution/ThumbnailSharp
 * 
 * 
 */


namespace ThumbNails.Controllers
{
    public class HomeController : Controller
    {
        private string savedLocation;
        public ActionResult Index()
        {

            return View();

        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {

            //Stream resultStream = new ThumbnailCreator().CreateThumbnailStream(thumbnailSize: 300, imageFileLocation: @"C:\Users\skang\source\repos\thumbNailProject\thumbNailProject\Content\Image\landscape.jpg", imageFormat: Format.Jpeg);
            //byte[] resultBytes = new ThumbnailCreator().CreateThumbnailBytes(thumbnailSize: 300, imageFileLocation: @"C:\Users\skang\Pictures\land.jpg", imageFormat: Format.Bmp);
            //Stream resultStream = await new ThumbnailCreator().CreateThumbnailStreamAsync(thumbnailSize: 250, urlAddress: new Uri("https://source.unsplash.com/category/nature/", UriKind.Absolute),imageFormat: Format.Png);


            for (int i = 0; i <= 3; i++)
            {
                byte[] resultBytes = await new ThumbnailCreator().CreateThumbnailBytesAsync(thumbnailSize: 150, urlAddress: new Uri("https://source.unsplash.com/category/nature/", UriKind.Absolute), imageFormat: Format.Jpeg);

                //To see a result, please replace the address to your local path.
                savedLocation = @"C:\Users\skang\source\repos\ThumbNails\ThumbNails\Content\Images\image" + i + ".jpg";


                //Reference: https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream.read?view=netframework-4.7.2  & https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream.write?view=netframework-4.7.2
                try
                {
                    using (FileStream fs = new FileStream(savedLocation, FileMode.Create, FileAccess.ReadWrite))
                    {
                        fs.Write(resultBytes, 0, resultBytes.Length);
                        fs.Close();
                    }
                }
                catch (FileNotFoundException ioEx)
                {
                    Console.WriteLine(ioEx.Message);
                }
                // To get a new image from website, sleeps 3 seconds in for loop (The website (Unsplash.com) generates a new image every 2-3 seconds
                Thread.Sleep(3000);
            }

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}