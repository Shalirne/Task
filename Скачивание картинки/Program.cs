using System.Net;

namespace Downloader
{
    internal class Program
    {
        public static bool скачка;
        static async Task Main(string[] args)
        {
            ConsoleKeyInfo key;
            ImageDownloader download = new ImageDownloader();
            ImageDownloader.imageStarted += Event;
            await download.DownloadPicture();
            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            while(true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    ImageDownloader.cancellationTokenSource.Cancel();
                    Console.WriteLine("Выполнение скачивания прервано");
                    break;
                }
                else
                {
                    download.DownloadStatus();
                }
            }
        }
        public static void Event()
        {
            Console.WriteLine("Скачивание файла началось");
        }
    }
}
