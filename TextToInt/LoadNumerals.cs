using System.Text.Json;

namespace TextToInt
{
    // LoadNumerals class to load the numerals from a json file
    // The json file should be a dictionary with the numeral as the key and the value as the integer
    // It is in an extra class to allow users to adapt the other classes without the LoadNumerals class if they want to load the numerals in a different way
    public class LoadNumerals
    {
        public LoadNumerals(string? jsonFilePath = null)
        {
            //deafult path
            jsonFilePath ??= "numerals.json";   
            
            numerals = LoadJson(jsonFilePath);
            
        }
        private Dictionary<string, int> numerals;

        private Dictionary<string, int> LoadJson(string jsonFilePath)
        {
            
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                //set numerals to the deserialized json or an empty dictionary
                numerals = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString) ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
            }
            return numerals;
        }
    }
}