﻿using System;
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
			VerbatimString();
			StringImmutability();


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

		private static void VerbatimString()
		{
			// var path = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe"; // Error
			var path = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\Common7\\IDE\\devenv.exe";
			var verbatimStringPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe";

			Console.WriteLine(path);
			Console.WriteLine(verbatimStringPath);
		}

		private static void StringImmutability()
		{
			var path = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe";
			
			if(path.ToUpperInvariant().Substring(40, 30).EndsWith("COMMON7"))
			{
				Console.WriteLine("Подстрока содержит 'common7' на конце");
			}
			else
			{
				Console.WriteLine("Указанная подстрока заканчивается не на 'common7'");
			}
		}
	}
}
