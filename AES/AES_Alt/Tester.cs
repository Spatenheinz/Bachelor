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
        public ICipher Cipher;
        [OutputBus]
        public axi_r axi_Cipher = Scope.CreateBus<axi_r>();
        [OutputBus]
        public IPlainText PlainText = Scope.CreateBus<IPlainText>();
        [InputBus]
        public axi_r axi_Text;

        private readonly string[] MESSAGES;

        private static int testsize = 10;
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
                    randomStrings[i] = RandomString(16);
                    // randomStrings[i] = RandomString((i+1) * 16);
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

        bool was_valid = false;
        bool was_ready = false;
        bool key_set = false;
        int i = 0, j = 0, ii = 0, jj = 0;
        public async override Task Run() {

        string [] results = new string [MESSAGES.Length];
            await ClockAsync();
            // string str2 = "";
            while (j < MESSAGES.Length) {
                // message = MESSAGES[i];
                if (was_valid && axi_Text.ready) {
                    was_valid = false;
                }
                if (was_ready && Cipher.ValidBlock) {
                    for (int jj = 0; jj < BLOCK_SIZE; jj++) {
                        results[j] += Cipher.block[jj].ToString("X2");
                    }
                    // the length is double as it is converted from ascii to bytes
                    if(results[j].Length == MESSAGES[j].Length * 2) {
                        Console.WriteLine("done!!!!!!!");
                        j++;
                    }
                was_ready = false;
                }
                if (i < MESSAGES.Length) {
                    if (!key_set) {
                        PlainText.ValidKey = key_set = true;
                        for(int i = 0; i < key.Length; i++) {
                            PlainText.Key[i] = key[i];
                        }
                    } else if (ii < MESSAGES[i].Length) {
                        Console.WriteLine($"i {i}");
                        for(int iii = 0; iii < BLOCK_SIZE; iii++) {
                            PlainText.block[iii] = (byte)MESSAGES[i][ii+iii];
                        }
                    PlainText.ValidKey = false;
                    PlainText.ValidBlock = was_valid = true;
                    ii += BLOCK_SIZE;
                    } else {
                        i++;
                        ii=0;
                    PlainText.ValidBlock = key_set = was_valid = false;
                    }
                }
                else {
                    PlainText.ValidBlock = was_valid = false;
                }
                if (j < results.Length) {
                        Console.WriteLine($"j {j}");
                    axi_Cipher.ready = was_ready = true;
                }
                else {
                    axi_Cipher.ready = was_ready = false;
                }
            Console.WriteLine($"ok, {was_ready}, {was_valid}");
                await ClockAsync();
            }
            for (int k = 0; k < MESSAGES.Length; k++) {
                string target = targetCypher(StringToByteArray(MESSAGES[k]), key, IV);
                Debug.Assert(results[k] == target, $"String2 {MESSAGES[k]} with Hash nr. {k} - {results[k]} doesnt match the MS library {target}");
            }
        }
    }
}
