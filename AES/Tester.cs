using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

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

        private const string key = "000102030405060708090a0b0c0d0e0f";


        private System.Security.Cryptography.Aes Target = System.Security.Cryptography.Aes.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString((i+1) * 129);

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

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // private string targetHash(string message) {
        //     byte[] target = Target.(System.Text.Encoding.UTF8.GetBytes(message));
        //     return BitConverter.ToString(target).Replace("-", string.Empty);
        // }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                Message.ValidData = false;
                Message.ValidKey = true;
                byte[] tmpData = StringToByteArray(message);
                for(int i = 0; i < tmpData.Length; i++) {
                    Message.Data[i] = tmpData[i];
                }
                byte[] tmpKey = StringToByteArray(key);
                for(int i = 0; i < tmpKey.Length; i++) {
                    Message.Key[i] = tmpKey[i];
                }
                await ClockAsync();

                Message.ValidKey = false;
                Message.ValidData = true;

                await ClockAsync();

            }
        }
    }
}
