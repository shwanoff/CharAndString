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

			Console.WriteLine(char.MinValue); // \0
			Console.WriteLine(char.MaxValue); // \uffff

			Console.WriteLine((int)char.MinValue); // 0
			Console.WriteLine((int)char.MaxValue); // 65535

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

			Console.ReadLine();
		}
	}
}
