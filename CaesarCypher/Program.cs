using System;

namespace CaesarCypher
{
    class Program
    {
        private static readonly string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        static int Main(string[] args) {
            try {
                if (args.Length != 2) {
                    Console.Error.WriteLine("Wrong number of arguments");
                    return -1;
                }

                var result = Encrypt(args[0], args[1]);

                Console.Write(result);
            } catch (Exception ex) {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();

            return 0;
        }

        static string Encrypt(string message, string key) {
            var result = string.Empty;

            for (var i = 0; i < message.Length; i++) {
                var character = message[i];

                var keyCharacter = key[i % key.Length];

                var characterCode = GetCharacterCode(character);

                var keyCode = GetCharacterCode(keyCharacter);

                var encryptedInt = characterCode + keyCode;

                var encryptedChar = CHARACTERS[encryptedInt];

                result += encryptedChar;
            }

            return result;
        }

        static int GetCharacterCode(char character) {
            var result = CHARACTERS.IndexOf(character);

            if (result == -1)
                throw new InvalidOperationException($"Character '{character}' is invalid");

            return result + 1;
        }
    }
}
