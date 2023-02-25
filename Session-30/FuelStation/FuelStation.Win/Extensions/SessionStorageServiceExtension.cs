using Blazored.SessionStorage;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FuelStation.Win.Extensions {
    public static class SessionStorageServiceExtension {
        public static async Task SaveItemEncryptedAsync<T>(string key, T item) {
            var itemJson = JsonSerializer.Serialize(item);
            var itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
            var base64Json = Convert.ToBase64String(itemJsonBytes);

            // Write the encrypted item to a JSON file in the user's local application data directory
            var filePath = Path.Combine(Application.LocalUserAppDataPath, $"{key}.json");
            await File.WriteAllTextAsync(filePath, base64Json);
        }

        public static async Task<T?> ReadEncriptedItemAsync<T>(string key) {
            // Read the encrypted item from the JSON file
            var filePath = Path.Combine(Application.LocalUserAppDataPath, $"{key}.json");
            if (!File.Exists(filePath)) {
                return default;
            }
            var base64Json = await File.ReadAllTextAsync(filePath);
            var itemJsonBytes = Convert.FromBase64String(base64Json);
            var itemJson = Encoding.UTF8.GetString(itemJsonBytes);
            var item = JsonSerializer.Deserialize<T>(itemJson);
            return item;
        }

        public static async Task RemoveItemAsync(string key) {
            var filePath = Path.Combine(Application.LocalUserAppDataPath, $"{key}.json");
            if (File.Exists(filePath)) {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
