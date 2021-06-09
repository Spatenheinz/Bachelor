using System;
using System.Text;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using static AES2.AESConfig;

namespace AES2
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

        private static int testsize = 2;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();

        private byte[] key = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                              0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f};
        private byte[] IV = {0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88,
                             0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff};
        private byte[] IV1 = {0x69, 0xc4, 0xe0, 0xd8, 0x6a, 0x7b, 0x04, 0x30, 0xd8,
                             0xcd, 0xb7, 0x80, 0x70, 0xb4, 0xc5, 0x5a};
        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString(16);
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

        public static string ByteArrayToString(IFixedArray<byte> buffer) {
            byte[] tmp = new byte[buffer.Length];
            for(int i = 0; i < buffer.Length; i++) {
                tmp[i] = buffer[i];
            }
			return BitConverter.ToString(tmp).Replace("-", "");
		}

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string targetCypher(byte[] PlainText, byte[] key, byte[] iv) {
            AesManaged aes2 = new AesManaged{
                                      KeySize = 128,
                                      Key = key,
                                      BlockSize = 128,
                                      Mode = CipherMode.ECB,
                                      Padding = PaddingMode.None,
                                      };
            ICryptoTransform encryptor = aes2.CreateEncryptor(key, iv);
        return ByteArrayToString(encryptor.TransformFinalBlock(PlainText, 0, PlainText.Length));
        }

        private string targetDecipher(byte[] PlainText, byte[] key, byte[] iv) {
            AesManaged aes2 = new AesManaged{
                                      KeySize = 128,
                                      Key = key,
                                      BlockSize = 128,
                                      Mode = CipherMode.ECB,
                                      Padding = PaddingMode.None,
                                      };
            ICryptoTransform decryptor = aes2.CreateDecryptor(key, iv);
        return ByteArrayToString(decryptor.TransformFinalBlock(PlainText, 0, PlainText.Length));
        }

        bool was_valid = false;
        bool was_ready = false;
        bool key_set = false;
        int i = 0, j = 0, ii = 0;
        public async override Task Run() {

        string [] results = new string [MESSAGES.Length];
        string [] results2 = new string [MESSAGES.Length];
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
            Console.WriteLine($"ok, {was_ready}, {was_valid}");
                if (i < MESSAGES.Length) {
                    if (!key_set) {
                        PlainText.ValidKey = key_set = true;
                        for(int i = 0; i < key.Length; i++) {
                            PlainText.Key[i] = key[i];
                        }
                    } else if (ii < MESSAGES[i].Length) {
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
                    axi_Cipher.ready = was_ready = true;
                }
                else {
                    axi_Cipher.ready = was_ready = false;
                }
                await ClockAsync();
            }
            j = 0; i = 0; ii = 0;
            PlainText.encrypt = false;
            was_ready = false;
            was_valid = false;
            while (j < MESSAGES.Length) {
                // message = MESSAGES[i];
                if (was_valid && axi_Text.ready) {
                    was_valid = false;
                }
                if (was_ready && Cipher.ValidBlock) {
                    for (int jj = 0; jj < BLOCK_SIZE; jj++) {
                        results2[j] += Cipher.block[jj].ToString("X2");
                    }
                    // the length is double as it is converted from ascii to bytes
                    if(results2[j].Length == MESSAGES[j].Length * 2) {
                        Console.WriteLine("done!!!!!!!");
                        j++;
                    }
                was_ready = false;
                }
                if (i < MESSAGES.Length) {
                    if (ii < MESSAGES[i].Length) {
                        for(int iii = 0; iii < BLOCK_SIZE; iii++) {
                            PlainText.block[iii] = IV1[iii];//(byte)MESSAGES[i][ii+iii];
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
                if (j < results2.Length) {
                    axi_Cipher.ready = was_ready = true;
                }
                else {
                    axi_Cipher.ready = was_ready = false;
                }
                await ClockAsync();
            }
            for (int k = 0; k < MESSAGES.Length; k++) {
                string target = targetCypher(StringToByteArray(MESSAGES[k]), key, IV);
                string target2 = targetDecipher(IV1, key, IV);
                Debug.Assert(results[k] == target, $"String {MESSAGES[k]} with Hash nr. {k} - {results[k]} doesnt match the MS library {target}");
                Debug.Assert(results2[k] == target2, $"String Decrypt {MESSAGES[k]} with Hash nr. {k} - {results2[k]} doesnt match the {target2}");
            }
        }
    }
}
