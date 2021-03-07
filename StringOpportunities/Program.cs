using System;

namespace StringOpportunities
{
	class Program
	{
		static void Main(string[] args)
		{
			CreateString();

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
	}
}
