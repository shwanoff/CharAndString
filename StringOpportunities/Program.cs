using System;
using System.Text;

namespace StringOpportunities
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;

			CreateString();
			SpecialSymbols();
			ConcatString();


			Console.ReadLine();
		}

		private static void CreateString()
		{
			Console.WriteLine("это литерал"); // Литеральная строка

			//string error = new String("CODE BLOG"); // Ошибка
			string str = "CODE BLOG";
			Console.WriteLine(str);

			unsafe
			{
				fixed (char* pointer = str)
				{
					string strFromPointer = new String(pointer);
					Console.WriteLine(strFromPointer);
				}
			}
		}

		private static void SpecialSymbols()
		{
			var newLine = "CODE\r\nBLOG";
			var rewriteLine = "CODE\rBLOG";
			var tab = "CODE\tBLOG";
			var quotes = "\'CODE\' \"BLOG\"";
			var slash = "CODE\\BLOG";

			Console.WriteLine(newLine);
			Console.WriteLine(rewriteLine);
			Console.WriteLine(tab);
			Console.WriteLine(quotes);
			Console.WriteLine(slash);

			var rightNewLine = "CODE" + Environment.NewLine + "BLOG";
			Console.WriteLine(rightNewLine);
		}

		private static void ConcatString()
		{
			var str = "CODE" + " " + "BLOG";
			Console.WriteLine(str) ;
		}
	}
}
