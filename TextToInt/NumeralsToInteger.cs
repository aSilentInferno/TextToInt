namespace TextToInt
{
    // class to convert numerals to integers
    public class NumeralsToInteger(Dictionary<string, int> _numerals)
    {
        private readonly Dictionary<string, int> numerals = _numerals;

        /// <summary>
        /// Converts a string representation of numerals to its integer value.
        /// </summary>
        /// <param name="input">The string input containing numerals to be converted.</param>
        /// <returns>The integer value of the input numerals.</returns>
        /// <remarks>
        /// The method performs the following steps:
        /// 1. Cleans up the input string.
        /// 2. Splits the input string into an array of substrings.
        /// 3. Replaces the substrings with their corresponding integer values.
        /// 4. Calculates the final integer value from the array of integers.
        /// </remarks>
        public int Convert(string input)
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
        private static string Cleaninput(string input)
        {
            //replace hyphens with spaces
            input = input.Replace("-", " ");
            //remove any non letter characters
            input = Regex.Replace(input, "[^a-zA-Z]", "");
            //to lower cass
            input = input.ToLower();
            return input;
        }
        private static string[] Splitupstring(string input)
        {
            return input.Split(' ');
        }

        private static int[] Replacewithint(string[] input, Dictionary<string, int> numerals)
        {
            int[] intArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (numerals.TryGetValue(input[i], out int value))
                {
                    intArray[i] = value;
                }
                else
                {
                    Console.WriteLine($"Error: {input[i]} is not a valid numeral");
                    throw new ArgumentException($"Error: {input[i]} is not a valid numeral");
                }
            }
            return intArray;
        }

        private static int Calculateint(int[] intArray)
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
                if (i < intArray.Length - 1 && intArray[i] < intArray[i + 1])
                {
                    result += intArray[i] * intArray[i + 1];
                    //skip the next number since it was already added
                    i++;
                }
                else if (i < intArray.Length - 1 && intArray[i] == intArray[i + 1])
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