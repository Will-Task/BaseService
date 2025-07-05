using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AuthServer.Encryption;

public class AppsettingHandler
{
    private const string AppsettingsFileName = "appsettings.json";
    const string NewFileName = "AuthServer_x3f589t21e";
    public static bool IsExistAppsettings() => File.Exists(AppsettingsFileName);
    
    public static async Task EncryptionAsync()
    {
        if (IsExistAppsettings())
        {
            using (Aes aesAlg = Aes.Create())
            {
                var content = await File.ReadAllTextAsync(AppsettingsFileName);
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();

                await File.WriteAllBytesAsync($"{NewFileName}.ahk", aesAlg.Key);
                await File.WriteAllBytesAsync($"{NewFileName}.ahi", aesAlg.IV);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(content);
                        }
                        var encrypted = msEncrypt.ToArray();
                        await File.WriteAllBytesAsync($"{NewFileName}.ah", encrypted);
                    }
                }
            }
        }
    }

    public static async Task<string> GetDecryptionStringAsync()
    {
        string plaintext = null;

        if (File.Exists($"{NewFileName}.ah"))
        {
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                var cipherText = await File.ReadAllBytesAsync($"{NewFileName}.ah");
                aesAlg.Key = await File.ReadAllBytesAsync($"{NewFileName}.ahk");
                aesAlg.IV = await File.ReadAllBytesAsync($"{NewFileName}.ahi");

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = await srDecrypt.ReadToEndAsync();
                        }
                    }
                }
            }
        }

        return plaintext;
    }

    public static async Task<Stream> GetDecryptionStreamAsync()
    {
        var plaintext = await GetDecryptionStringAsync();
        var memoryStream = new MemoryStream();
        var sw = new StreamWriter(memoryStream); 
        await sw.WriteAsync(plaintext);
        await sw.FlushAsync();
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
}