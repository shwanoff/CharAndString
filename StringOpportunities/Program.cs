using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
			CompareString();
			CompareInfo();
			CompareDifferentCultureInfo();

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

		private static void CompareString()
		{
			var str1 = "code blog";
			var str2 = "CODE BLOG";

			// Проверка на равенство
			Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
			Console.WriteLine(string.Equals(str1, str2, StringComparison.Ordinal));

			// Сравнение для упорядочивания системных строк
			Console.WriteLine(string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase));

			// Сравнение для упорядочивания при демонстрации пользователю
			Console.WriteLine(string.Compare(str1, str2, StringComparison.CurrentCulture));
		}

		private static void CompareInfo()
		{
			var s1 = "Strasse";
			var s2 = "Straße";
			
			// CompareOrdinal возвращает ненулевое значение
			var ordianlCompareResult = string.Compare(s1, s2, StringComparison.Ordinal);
			var ordianEquals = ordianlCompareResult == 0 ? "==" : "!=";

			Console.WriteLine($"Ordinal сравнение: '{s1}' {ordianEquals} '{s2}'");

			// Сортировка строк для немецкого языка (de) в Германии (DE)
			var culture = new CultureInfo("de-DE");

			// Compare возвращает нуль
			var compareResult = string.Compare(s1, s2, true, culture);
			var equals = compareResult == 0 ? "==" : "!=";

			Console.WriteLine($"Cultural сравнение: '{s1}' {equals} '{s2}'");
		}

		private static void CompareDifferentCultureInfo()
		{
			var s1 = "coté";
			var s2 = "côte";

			// Сортировка строк для французского языка (Франция)
			var french = new CultureInfo("fr-FR");
			CompareTwoStrings(s1, s2, french);

			// Сортировка строк для японского языка (Япония)
			var japan = new CultureInfo("ja-JP");
			CompareTwoStrings(s1, s2, japan);


			// Сортировка строк по региональным стандартам потока
			var current = Thread.CurrentThread.CurrentCulture;
			CompareTwoStrings(s1, s2, current);

			// Следующий код демонстрирует использование дополнительных возможностей
			// метода CompareInfo.Compare при работе с двумя строками на японском языке 
			// Эти строки представляют слово "shinkansen" (название высокоскоростного поезда) 
			// в разных вариантах письма: хирагане и катакане
			var s3 = "\u3057\u3093\u304b\u3093\u305b\u3093"; 
			var s4 = "\u30b7\u30f3\u30ab\u30f3\u30bb\u30f3"; 

			// Результат сравнения по умолчанию
			CompareTwoStrings(s3, s4, japan);

			// Результат сравнения, который игнорирует тип каны
			CompareTwoStrings(s3, s4, japan, CompareOptions.IgnoreKanaType);
			}

		private static void CompareTwoStrings(string s1, string s2, CultureInfo cultureInfo, CompareOptions compareOptions = CompareOptions.None)
		{
			var symbols = new string[] { "<", "=", ">" };
			var x = Math.Sign(cultureInfo.CompareInfo.Compare(s1, s2, compareOptions));
			var result = $"{cultureInfo.Name} Compare: {s1} {symbols[x + 1]} {s2}";
			Console.WriteLine(result);
			MessageBox.Show(result, "Comparing Strings For Sorting");
		}
	}
}
