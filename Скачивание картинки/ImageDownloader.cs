using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static Downloader.ImageDownloader;
using System.Reflection;

namespace Downloader
{
    internal class ImageDownloader
    {
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken cancellationToken = cancellationTokenSource.Token;
        public delegate void ImageStarted();
        public delegate void ImageCompleted();
        public static event ImageStarted? imageStarted;
        public static event ImageCompleted? imageCompleted;

        public static WebClient webClient1 = new WebClient();
        public static WebClient webClient2 = new WebClient();
        public static WebClient webClient3 = new WebClient();
        public static WebClient webClient4 = new WebClient();
        public static WebClient webClient5 = new WebClient();
        public static WebClient webClient6 = new WebClient();
        public static WebClient webClient7 = new WebClient();
        public static WebClient webClient8 = new WebClient();
        public static WebClient webClient9 = new WebClient();
        public static WebClient webClient10 = new WebClient();

        static List<Task> task = new List<Task>()
        {
            new Task(() => webClient1.DownloadFile("https://stsci-opo.org/STScI-01H14T5JF44ZF0XEYJD0ARRWRC.jpg", "bigimage1.jpg"), cancellationToken),
            new Task(() => webClient2.DownloadFile("https://stsci-opo.org/STScI-01H530DJ85QSE65WR2CV0YQ95F.png", "bigimage2.jpg"), cancellationToken),
            new Task(() => webClient3.DownloadFile("https://stsci-opo.org/STScI-01H532HWXZWR4B93BVDVSEN2GE.png", "bigimage3.jpg"), cancellationToken),
            new Task(() => webClient4.DownloadFile("https://stsci-opo.org/STScI-01H531TEN5ASTABMGM4839DT0N.png", "bigimage4.jpg"), cancellationToken),
            new Task(() => webClient5.DownloadFile("https://stsci-opo.org/STScI-01H0N2YTTRGVP20ZTS5Y1DV32Y.png", "bigimage5.jpg"), cancellationToken),
            new Task(() => webClient6.DownloadFile("https://stsci-opo.org/STScI-01GYSY560Q87ZAB8CPM05TDZYR.png", "bigimage6.jpg"), cancellationToken),
            new Task(() => webClient7.DownloadFile("https://stsci-opo.org/STScI-01GYWXJPKGDDYGMRB4J4R2SWS0.png", "bigimage7.jpg"), cancellationToken),
            new Task(() => webClient8.DownloadFile("https://stsci-opo.org/STScI-01GWW3SSA8YAP3EHSCWXYQPZ28.png", "bigimage8.jpg"), cancellationToken),
            new Task(() => webClient9.DownloadFile("https://stsci-opo.org/STScI-01GX655WEBWSS3KNTANW5FJXRK.png", "bigimage9.jpg"), cancellationToken),
            new Task(() => webClient10.DownloadFile("https://stsci-opo.org/STScI-01GWQ9TPX2KNRHFM34P83X6NHS.jpg", "bigimage10.jpg"), cancellationToken)
        };
        public async Task DownloadPicture()
        {
            imageStarted();
            foreach (var thread in task)
            {
                thread.Start();
            }
        }
        public void DownloadStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                if (task[i].IsCompleted == true)
                {
                    Console.WriteLine($"Скачивание картинки номер {i+1} завершено");
                }
                else
                {
                    Console.WriteLine($"Скачивание картинки номер {i+1} не завершено");
                }
            }
        }
    }
}