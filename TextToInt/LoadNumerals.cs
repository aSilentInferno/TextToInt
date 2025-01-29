using System.Text.Json;

namespace TextToInt
{
    static class LoadNumerals
    {
        public static Dictionary<string, int>? Numerals { get; private set; }
        public static void LoadNumeralsFromJson(string? jsonFilePath = null)
        {
            jsonFilePath ??= "numerals.json";   
            Numerals = LoadFromJson(jsonFilePath);
        }

        private static Dictionary<string, int> LoadFromJson(string jsonFilePath)
        {
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                //set numerals to the deserialized json or an empty dictionary
                Numerals = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString) ?? [];
                return Numerals;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                return [];
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
                return [];
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
                return [];
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON error: {ex.Message}");
                return [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return [];
            }
        }
    }
}