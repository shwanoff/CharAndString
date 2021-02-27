using System;
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

			Console.WriteLine((int)char.MinValue); // \0
			Console.WriteLine((int)char.MaxValue); // \uffff

			Console.ReadLine();
		}
	}
}
