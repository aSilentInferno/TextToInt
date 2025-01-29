using System.Text.Json;

namespace TextToInt;

static class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter 'integer' or 'english numeral' to convert ");
        string? input = Console.ReadLine();
        if (input is null)
        {
            Console.WriteLine("No input detected");
            return;
        }
        //load the numerals from the json file
        Dictionary<string, int> numerals = LoadNumeralsFromJson();
        //check if the input is an integer
        if(int.TryParse(input, out int number))
        {
            //input is an integer so convert it to a string
            string result = IntegerToString(number, numerals);
            Console.WriteLine($"The result is: {result}");
        }
        else
        {
            //input is a string so convert it to an integer
            int result = StringToInteger(input, numerals);
            Console.WriteLine($"The result is: {result}");
        }
    }

    private static int StringToInteger(string inputString, Dictionary<string, int> numerals)
    {
        //initalize an instance of NumeralsToInteger to load the numerals
        NumeralsToInteger numeToInt= new(numerals);
        //convert the string to an integer
        int result = numeToInt.Convert(inputString);

        return result;
    }

    private static string IntegerToString(int inputInt, Dictionary<string, int> numerals)
    {
        Console.WriteLine("sorry, this feature is not yet implemented :/");
        throw new NotImplementedException();
    }

    private static Dictionary<string, int> LoadNumeralsFromJson(string jsonFilePath = "numerals.json")
        {
            Dictionary<string, int> Numerals;
            
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