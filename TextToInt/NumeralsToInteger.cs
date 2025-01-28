namespace TextToInt
{   
    // class to convert numerals to integers
    static class NumeralsToInteger
    {
        private static Dictionary<string, int> numerals;

        public static void Initialize(LoadNumerals loadNumerals)
        {
            numerals = loadNumerals.Numerals;
        }
        internal static int Convert(string input)
        {
            //clean up the input
            input = Cleaninput(input);
            //split the input into an array
            string[] inputArray = Splitupstring(input);
            //replace the strings with their integer values
            int[] intArray = Replacewithint(inputArray, numerals);
            //calculate the integer value
            int result = Calculateint(intArray);
            return result;
        }
        internal static string Cleaninput(string input)
        {
            //replace hyphens with spaces
            input = input.Replace("-", " ");
            return input;
        }
        internal static string[] Splitupstring(string input)
        {
            return input.Split(' ');
        }

        internal static int[] Replacewithint(string[] input, Dictionary<string, int> numerals)
        {
            int[] intArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (numerals.ContainsKey(input[i]))
                {
                    intArray[i] = numerals[input[i]];
                }
                else
                {
                    Console.WriteLine($"Error: {input[i]} is not a valid numeral");
                    return new int[0];
                }
            }
            return intArray;
        }

        internal static int Calculateint(int[] intArray)
        {
            int result = 0;
            /*
            the rules for the numbers are:
            1. If a smaller number is before a larger number, multiply the two numbers
            2. If a smaller number is after a larger number, add the two numbers
            3. If two numbers are the same, you did something wrong and should return an error; there is no "five-five" 
            */
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] < intArray[i + 1])
                {
                    intArray[i] = intArray[i] * intArray[i + 1];
                }
                else if (intArray[i] == intArray[i + 1])
                {
                    throw new ArgumentException("Error: two of the same number in a row");
                }
                else
                {
                    result += intArray[i];
                }
            }
            return result;
        }
    }
}