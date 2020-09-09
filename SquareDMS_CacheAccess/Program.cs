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

            for (int i = 0; i < 20000; i++)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                await redis.PutDocumentPayloadAsync(i, file);

                sw.Stop();
                Console.WriteLine($"Put in : {sw.ElapsedMilliseconds} ms");

                //System.Threading.Thread.Sleep(500);
            }
         
            await redis.DisconnectAsync();   
            
            Console.ReadLine();
        }
    }
}
