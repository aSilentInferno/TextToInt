# Text to Int
### A simple c# program to convert numerals to integers and integers back to numerals

*Note that Numerals refered to numbers written in english like "five" and not roman numerals like "VII"*
It is currently not planned to add suport for roman numerals

## Program Features
The program offers the ability to turn English numerals (like `fourty-two`) into integers (`42`) and back.
### Limitations
The program can only deal with english numerals but no roman or other numerals. it also can only convert to and from natural numbers, although I might add negative number support in the future. There is currently *no* planned support for fractions, as it would make the program a lot more complicated and an entire new class for floating point operations. Support for roman numerals is also not really in the scope of the project.

## For Developers
If you want to integrate this conversion in your own code, the conversion classes `NumralsToInteger` and `IntegerToNumerals` are designed to work on their own. You need to create an instace of said class and give it an `dictonary<string, int>` or `dictonry<int, sting>` depending on the coversion with the name of the numerals and their value (see the [numerals.json](TextToInt/Numerals.json) for reference). Once you created the instance you can use its `convert` method to do the conversion.
### Complexity
Since the program needs to loop over every singe input, it has an average runtime of complexity `O(n)` and and average space complexity of O(n+m) and because m is derived from n `O(n)`
### Info
Lang: `C#`
Dependencies: `none`