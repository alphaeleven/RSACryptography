using System;

namespace RSACryptography
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Let's Encrypt and Decrypt password
            var password = "P@sswrd123";

            var rsaProvider = new RSACryptographyKeyGenerator();
            var keyPair = rsaProvider.GenerateKeys(RSAKeySize.Key2048);

            Console.WriteLine("\n\n\n PublicKey: " + keyPair.PublicKey);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");
            Console.WriteLine("\n\n\n PrivateKey: " + keyPair.PrivateKey);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");

            Console.WriteLine("\n\n\n Original Password Text: " + password);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");

            var encryptedText = CryptographyHelper.Encrypt(password, keyPair.PublicKey);
            Console.WriteLine("\n\n\n Encrypted Password Text: " + encryptedText);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");

            var decryptedText = CryptographyHelper.Decrypt(encryptedText, keyPair.PrivateKey);
            Console.WriteLine("\n\n\n Decrypted Password Text: " + decryptedText);

            //Let's Encrypt and Decrypt Database connection string in Wb.config file
            var connectionString = "Data Source=USER-VAIO\\SQLEXPRESS;Initial Catalog=OrderProcessing;Integrated Security=True";

            Console.WriteLine("\n\n\n Original Connection String Text: " + connectionString);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");

            encryptedText = CryptographyHelper.Encrypt(connectionString, keyPair.PublicKey);
            Console.WriteLine("\n\n\n Encrypted Connection String Text: " + encryptedText);
            Console.WriteLine("\n\n\n-------------------------------------------------------\n\n\n");

            decryptedText = CryptographyHelper.Decrypt(encryptedText, keyPair.PrivateKey);
            Console.WriteLine("\n\n\n Decrypted Connection String Text: " + decryptedText);

            Console.ReadKey();
        }
    }
}
