using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using static AES.AESConfig;

namespace AES
{
    public class Tester : SimulationProcess
    {
        [InputBus]
        public ICypher Cypher;

        [OutputBus]
        public IPlainText PlainText = Scope.CreateBus<IPlainText>();

        private readonly string[] MESSAGES;

        private static int testsize = 1;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();

        private byte[] key = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                              0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f};
        private byte[] IV = {0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88,
                             0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff};

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString((i+1) * 16);
                }
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
            byte[] res = new byte[hex.Length];
            for(int i = 0; i < hex.Length; i++) {
                res[i] = (byte)hex[i];
            }
            return res;
        }

        public static string ByteArrayToString(byte[] buffer) {
			return BitConverter.ToString(buffer).Replace("-", "");
		}

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string targetCypher(byte[] PlainText, byte[] key, byte[] iv) {
            AesManaged aes = new AesManaged{
                                      KeySize = 128,
                                      Key = key,
                                      BlockSize = 128,
                                      Mode = CipherMode.ECB,
                                      Padding = PaddingMode.None,
                                      };
            ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
        return ByteArrayToString(encryptor.TransformFinalBlock(PlainText, 0, PlainText.Length));
        }

        public async override Task Run() {

            await ClockAsync();

            PlainText.ValidBlock = false;
            PlainText.ValidKey = true;
            for(int i = 0; i < key.Length; i++) {
                PlainText.Key[i] = key[i];
            }
            await ClockAsync();
            PlainText.ValidKey = false;
            foreach (string message in MESSAGES) {
            string res = "";
            for(int i = 0; i < message.Length; i+=BLOCK_SIZE) {
                for(int j = 0; j < BLOCK_SIZE; j++) {
                PlainText.block[j] = (byte)message[i+j];
                }
                PlainText.ValidBlock = true;
                await ClockAsync();
                PlainText.ValidBlock = false;
                await ClockAsync();
                for(int j = 0; j < BLOCK_SIZE; j++) {
                res += Cypher.block[j].ToString("X2");
                }
            }
            string target = targetCypher(StringToByteArray(message), key, IV);
            Debug.Assert(res == target, $"String {message} - {res} doesnt match the MS library {target}");

            // CypherDecrypt.ValidKey = true;
            // for(int i = 0; i < key.Length; i++) {
            //     CypherDecrypt.Key[i] = key[i];
            // }
            // await ClockAsync();
            // CypherDecrypt.ValidKey = false;
            // CypherDecrypt.ValidBlock = true;
            // for(int i = 0; i < tmpData.Length; i++) {
            //     CypherDecrypt.block[i] = Cypher.block[i];
            // }
            // await ClockAsync();
            // string resD = ByteArrayToString(PlainDecrypt.block);
            }
        }
    }
}
