using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.IO;

namespace AES
{
    public class Tester : SimulationProcess
    {
        [InputBus]
        public ICypher Cypher;

        [OutputBus]
        public IMessage Message = Scope.CreateBus<IMessage>();

        private readonly string[] MESSAGES;

        private static int testsize = 1;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();

        private byte[] key = StringToByteArray("000102030405060708090a0b0c0d0e0f");
        private byte[] IV = StringToByteArray("00112233445566778899aabbccddeeff");

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString((i+1) * 128);
                }
                randomStrings[0] = "00112233445566778899aabbccddeeff";
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }

        }

        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        public static byte[] StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length)
				.Where(x => x % 2 == 0)
				.Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
				.ToArray();
		}
        public static string ByteArrayToString(byte[] buffer) {
			return BitConverter.ToString(buffer).Replace("-", "");
		}
        public static string ByteArrayToString(IFixedArray<byte> buffer) {
            string res = "";
            for(int i = 0; i < buffer.Length; i++) {
                res += buffer[i].ToString("x2");
            }
            return res;
		}

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string targetCypher(byte[] message, byte[] key, byte[] iv) {
            using(AesManaged aes = new AesManaged()) {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                Console.WriteLine(ByteArrayToString(message));
        return ByteArrayToString(encryptor.TransformFinalBlock(message, 0, message.Length));
        }
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                Message.ValidData = false;
                Message.ValidKey = true;
                byte[] tmpData = StringToByteArray(message);
                for(int i = 0; i < tmpData.Length; i++) {
                    Message.Data[i] = tmpData[i];
                }
                for(int i = 0; i < key.Length; i++) {
                    Message.Key[i] = key[i];
                }
                await ClockAsync();

                Message.ValidKey = false;
                Message.ValidData = true;

                await ClockAsync();
                string res = ByteArrayToString(Cypher.Data);
                string target = targetCypher(tmpData, key, IV);
                Debug.Assert(res == target, $"String {message} with Hash nr. {0} - {res} doesnt match the MS library {target}");


            }
        }
    }
}
