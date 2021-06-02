using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                        0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f};
            byte[] IV = {0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88,
                             0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff};
            AesManaged aes = new AesManaged{
                                      KeySize = 128,
                                      Key = key,
                                      BlockSize = 128,
                                      Mode = CipherMode.ECB,
                                      Padding = PaddingMode.None,
                                      };
            ICryptoTransform encryptor = aes.CreateEncryptor(key, IV);
            var stopWatch = new Stopwatch();
            var text = System.IO.File.ReadAllText(@"../../MD5/data.txt");
            var formatted = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] res = new byte[1000];
            stopWatch.Start();
            for(int i = 0; i < 1000; i++) {
                res = encryptor.TransformFinalBlock(formatted, 0, formatted.Length);
            }
            stopWatch.Stop();
            long elapsed = (stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))) / 1000;
            double GBsec = text.Length / elapsed;
            Console.WriteLine("RUNS in : {0} microsecs,  MB/sec: {1:f}\n", elapsed, GBsec);
            // Console.WriteLine($"{BitConverter.ToString(res).Replace("-",String.Empty)}");
        }
    }
}
