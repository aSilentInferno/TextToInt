using System.Text.Json;

namespace TextToInt
{
    public class LoadNumerals
    {
        public LoadNumerals(string? jsonFilePath = null)
        {
            jsonFilePath ??= "numerals.json";   
            numerals = LoadNumeralsFromJson(jsonFilePath);
        }

        private Dictionary<string, int> numerals;

        public Dictionary<string, int> Numerals => numerals;

        private Dictionary<string, int> LoadNumeralsFromJson(string jsonFilePath)
        {
            
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                //set numerals to the deserialized json or an empty dictionary
                numerals = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString) ?? new Dictionary<string, int>();
                return numerals;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                return new Dictionary<string, int>();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
                return new Dictionary<string, int>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
                return new Dictionary<string, int>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON error: {ex.Message}");
                return new Dictionary<string, int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new Dictionary<string, int>();
            }
            return numerals;
        }
    }
}