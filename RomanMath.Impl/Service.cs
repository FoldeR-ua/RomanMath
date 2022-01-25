using System;
using System.Collections.Generic;

namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>

		public static int Evaluate(string expression)
		{
			List<char> operations = ExtractOperations(expression);
			List<int> numbers = ExtractNumbers(expression);

			int value = Operation(numbers[0], numbers[1], operations[0]);
			
			for (int i = 2; i < numbers.Count; i++)
				value = Operation(value, numbers[i], operations[i - 1]);

			return value;
		}

		public static int Operation(int a, int b, char operation)
        {
            switch (operation)
            {
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
				default:
					return 0;
            }
        }
		public static List<char> ExtractOperations(string expression)
        {
			List<char> oper = new List<char>();
            for(int i = 0; i < expression.Length; i++)
            {
                switch (expression[i]) 
				{
					case '+':
						oper.Add(expression[i]);
						break;
					case '-':
						oper.Add(expression[i]);
						break;
					case '*':
						oper.Add(expression[i]);
						break;
				}
            }
			return oper;
        }
		public static List<int> ExtractNumbers(string expression)
        {
			Dictionary<string, int> DictNumbers = new Dictionary<string, int>() {
				{ "I" , 1},
				{ "II", 2},
				{ "III", 3},
				{ "IV", 4},
				{ "V", 5},
				{ "VI", 6},
				{ "VII", 7},
				{ "VIII", 8 },
				{ "IX", 9},
				{ "X", 10},
				{ "L", 50},
				{ "C", 100},
				{ "D", 500},
				{ "M", 1000}
			};
			string[] romanNumbers = expression.Split('+', '-', '*');
			List<int> numbers = new List<int>();
			for (int iter = 0; iter < romanNumbers.Length; iter++)
				numbers[iter] = DictNumbers[romanNumbers[iter]];
            

			return numbers;
        }
	}
}
