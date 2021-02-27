using System;
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

			Console.ReadLine();
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
