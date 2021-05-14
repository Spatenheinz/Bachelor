using System;
using System.Diagnostics;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sha = System.Security.Cryptography.SHA256.Create();
            var stopWatch = new Stopwatch();
            var text = System.IO.File.ReadAllText(@"../../MD5/csharp/data.txt");
            var formatted = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] res = new byte[32];
            stopWatch.Start();
            for(int i = 0; i < 100; i++) {
                res = sha.ComputeHash(formatted);
            }
            stopWatch.Stop();
            long elapsed = (stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))) / 100;
            double GBsec = text.Length / elapsed;
            Console.WriteLine("RUNS in : {0} microsecs,  MB/sec: {1:f}\n", elapsed, GBsec);
            Console.WriteLine($"{BitConverter.ToString(res).Replace("-",String.Empty)}");
        }
    }
}
