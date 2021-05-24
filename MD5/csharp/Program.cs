using System;
using System.Diagnostics;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var stopWatch = new Stopwatch();
            var text = System.IO.File.ReadAllText(@"data.txt");
            var formatted = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] res = new byte[16];
            stopWatch.Start();
            for(int i = 0; i < 1000; i++) {
                res = md5.ComputeHash(formatted);
            }
            stopWatch.Stop();
            long elapsed = (stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))) / 1000;
            double GBsec = text.Length / elapsed;
            Console.WriteLine("RUNS in : {0} microsecs,  MB/sec: {1:f}\n", elapsed, GBsec);
            Console.WriteLine($"{BitConverter.ToString(res).Replace("-",String.Empty)}");
        }
    }
}
