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

			Console.ReadLine();
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
