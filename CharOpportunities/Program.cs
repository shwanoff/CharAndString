using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace CharOpportunities
{
	class Program
	{
		static void Main()
		{
			Console.OutputEncoding = Encoding.Unicode;
			MinMaxChar();
			CharUnicodeCategory();
			CharToUpperCultureInfo();
			EqualsSymbol();
			CompareSymbols();
			ConvertCharAndString();
			SymbolToNumber();
			ConvertChar();

			Console.ReadLine();
		}

		private static void ConvertChar()
		{
			// Приведение типа
			var a = (char)65; // Буква А
			Console.WriteLine($"a = {a}");

			var number = (int)'A'; // Число 65
			Console.WriteLine($"number = {number}");

			var number2 = (int)a; // Число 65
			Console.WriteLine($"number2 = {number2}");

			var negativeNumber = -3;
			var tooBigNumber = 65601;
			var d = 2.573;

			var negativeDefault = (char)negativeNumber; // \uFFFD � 
			Console.WriteLine($"negativeDefault = {negativeDefault}");

			var tooBigDefault = (char)tooBigNumber; // Буква А
			Console.WriteLine($"tooBigDefault = {tooBigDefault}");

			var tooBigUnchecked = unchecked((char)tooBigNumber); // Буква А
			Console.WriteLine($"tooBigUnchecked = {tooBigUnchecked}");

			//var tooBigChecked = checked((char)tooBigNumber); // Ошибка
			// Console.WriteLine(tooBigChecked);

			//var negativeChecked = checked((char)negativeNumber); // Ошибка
			//Console.WriteLine(negativeChecked);

			var doubleConvert = (char)d; // \u0002 ☻ - дробная часть числа игнорируется
			Console.WriteLine($"doubleConvert = {doubleConvert}");


			// Тип Convert
			var convertNumber = Convert.ToChar(65); // Буква А
			Console.WriteLine($"convertNumber = {convertNumber}");

			var convertChar = Convert.ToInt32('A'); // Число 65
			Console.WriteLine($"convertChar = {convertChar}");

			//var tooBigConvert = Convert.ToChar(tooBigNumber); // Ошибка
			//Console.WriteLine(tooBigConvert);

			// Интерфейс IConvertible
			var iConvertibleNumber = ((IConvertible)65).ToChar(null); // Буква А
			Console.WriteLine($"iConvertibleNumber = {iConvertibleNumber}");

			var iConvertivleChar = ((IConvertible)'A').ToInt32(null); // Число 65
			Console.WriteLine($"iConvertivleChar = {iConvertivleChar}");
		}

		private static void SymbolToNumber()
		{
			var three = char.GetNumericValue('\u0033'); // цифра 3
			Console.WriteLine(three); // 3
			Console.WriteLine((int)'\u0033');

			var quarter = char.GetNumericValue('\u00bc'); // дробь одна четвертая ¼
			Console.WriteLine(quarter); // 0.25
			Console.WriteLine((int)'\u00bc');

			var letter = char.GetNumericValue('a'); // не число
			Console.WriteLine(letter); // -1
			Console.WriteLine((int)'a');
		}

		private static void ConvertCharAndString()
		{
			var str = "CODE BLOG";
			var oneSymbolString = "A";

			// var error = char.Parse(str); // Строка обязана состоять из одного символа
			var result = char.Parse(oneSymbolString);
			Console.WriteLine(result);

			if (char.TryParse(str, out char symbol))
			{
				Console.WriteLine(symbol);
			}
			else
			{
				Console.WriteLine($"Преобразовать строку [{str}] в символ не удалось");
			}

			var c = 'G';
			var s = c.ToString();
			Console.WriteLine(s);
		}

		private static void CompareSymbols()
		{
			Console.WriteLine((int)'I');
			Console.WriteLine((int)'İ');

			Console.WriteLine('I'.CompareTo('İ')); // -231
		}

		private static void EqualsSymbol()
		{
			var s1 = 'μ';
			var s2 = 'µ';

			Console.WriteLine('μ'.Equals(s1)); // true
			Console.WriteLine(s1.Equals(s2)); // false

			Console.WriteLine((int)s1); // 956
			Console.WriteLine((int)s2); // 181
		}

		private static void CharToUpperCultureInfo()
		{
			var symbol = 'i';
			Console.WriteLine(char.ToUpperInvariant(symbol)); // I

			var cultureInfo = CultureInfo.GetCultureInfo("tr"); // Turkish
			Console.WriteLine(char.ToUpper(symbol, cultureInfo)); // İ
		}

		private static void CharUnicodeCategory()
		{
			char symbol = 'A';
			Console.WriteLine(char.GetUnicodeCategory(symbol)); // UppercaseLetter

			if (char.IsLetter(symbol))
			{
				Console.WriteLine("This is a letter");
			}
			else
			{
				Console.WriteLine("It is definitely not a letter");
			}
		}

		private static void MinMaxChar()
		{
			Console.WriteLine(char.MinValue); // \0
			Console.WriteLine(char.MaxValue); // \uffff

			Console.WriteLine((int)char.MinValue); // 0
			Console.WriteLine((int)char.MaxValue); // 65535
		}
	}
}
