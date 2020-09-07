using System;

namespace SquareDMS_CacheAccess
{
    internal class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var file = System.IO.File.ReadAllBytes(@"C:\Users\Administrator\Desktop\CompSci.pdf");

            var redis = new SquareCacheRedis("localhost", 6_379);

            await redis.ConnectAsync();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            await redis.PutDocumentPayloadAsync(1, file);

            sw.Stop();

            await redis.DisconnectAsync();

            Console.WriteLine($"Put in : {sw.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }
    }
}
